using DMS.Core.Models;
//using DMS.Core.Models.LogStashModel;
using DMS.Repositories.Helpers;
using DMS.Shared;
using NetStash.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.Cache;
using VNPT.Framework.CommonType;
using VNPT.Framework.Logger;

namespace DMS.Workflows
{
    public abstract class BaseStepHandler
    {
        private readonly ICache _cache;
        private readonly ILogger _logger;
        protected BaseStepHandler()
        {
            _cache = DependencyFactory.Instance.DependencyResolution.Resolve<ICache>();
            _logger = DependencyFactory.Instance.DependencyResolution.Resolve<ILogger>();
            CacheKey = string.Empty;


        }
        public virtual string CacheKey { get; protected set; }
        public abstract bool Required { get; }
        public abstract Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken);
        protected IDependencyResolution DependencyResolution => DependencyFactory.Instance.DependencyResolution;
        public async Task<FunctionResult> ExecuteWithCacheAsync(string type, string token, FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;

            var attribute = GetCacheAttribute();

            if (attribute != null && CacheKey.IsNullOrEmpty() == false)
            {
                var exist = _cache.Exist(CacheKey);
                if (exist) return GetCache(attribute);
            }

            //WriteLogExecuting(token,previousResults);
            result = await ExecuteAsync(previousResults, cancellationToken);

            WriteLogExecuted(type, token, result);

            SetCache(result, attribute);

            return result;

        }

        //private async void WriteLogExecuting(string token, FunctionResult previousResult)
        //{
        //    /*var name = GetType().Name;

        //    var getUsername = await RedisDataAccess.GetHash("Account", token);
        //    var username = "";
        //    if (getUsername == null)
        //    {
        //        username = token;
        //    }
        //    else username = getUsername.ToString();

        //    var jsonlog = new LogError
        //    {
        //        Id = Guid.NewGuid(),
        //        application = "sohoa",
        //        className = "log-error",
        //        CreatedOn = DateTime.UtcNow,
        //        UserName = username,
        //        message = $"{username} - Executing error in the handler {name} - {Newtonsoft.Json.JsonConvert.SerializeObject(previousResult.Errors)}"
        //    };

        //    string stringLog = Newtonsoft.Json.JsonConvert.SerializeObject(jsonlog);
        //    CommonUntil.SendTcpLogStash(stringLog);*/


        //}

        private async Task WriteLogExecuted(string type, string token, FunctionResult result)
        {
            if (result != null)
            {
                //if (result.Succeed == false)
                //{
                //    CommonUntil.SendTcpLogStash("");
                //}

            }


        }

        private UseCacheAttribute GetCacheAttribute()
        {
            var type = this.GetType();
            var customAttribute = type.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(UseCacheAttribute));
            return customAttribute as UseCacheAttribute;
        }

        private FunctionResult GetCache(UseCacheAttribute attribute)
        {
            var result = _cache.Get<FunctionResult>(CacheKey);
            return result;
        }

        private void SetCache(FunctionResult result, UseCacheAttribute attribute)
        {
            if (attribute != null) _cache.Add(CacheKey, result, DateTime.UtcNow.AddSeconds(attribute.Seconds));
        }

    }
}
