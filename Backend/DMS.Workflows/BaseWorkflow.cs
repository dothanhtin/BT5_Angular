using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DMS.Shared;
using VNPT.Framework.Cache;
using VNPT.Framework.CommonType;

namespace DMS.Workflows
{
    public abstract class BaseWorkflow
    {
        protected List<BaseStepHandler> _listHandlers;
        public virtual bool Required => true;
        public virtual string CacheKey { get; protected set; }
        private readonly ICache _cache;

        protected BaseWorkflow()
        {
            CacheKey = string.Empty;
            _listHandlers = new List<BaseStepHandler>();
            _cache = DependencyFactory.Instance.DependencyResolution.Resolve<ICache>();
        }

        private UseCacheAttribute GetCacheAttribute()
        {
            var type = this.GetType();
            var customAttribute = type.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(UseCacheAttribute));
            return customAttribute as UseCacheAttribute;
        }

        private (FunctionResult lastestResult, List<FunctionResult> details) GetCache(UseCacheAttribute attribute)
        {
            var result = _cache.Get<(FunctionResult, List<FunctionResult>)>(CacheKey);
            return result;
        }

        private async Task<(FunctionResult lastestResult, List<FunctionResult> details)> ExecuteStepHandlersAsync(string type, string token, CancellationToken cancellationToken)
        {
            var lastestResult = FunctionResult.Success;
            var details = new List<FunctionResult>();
            foreach (var handler in _listHandlers)
            {
                var handlerResult = await handler.ExecuteWithCacheAsync(type, token, lastestResult, cancellationToken);
                lastestResult = handlerResult;
                details.Add(handlerResult);
                if (handlerResult.Failed && handler.Required) break;
            }
            return (lastestResult, details);
        }

        public virtual async Task<(FunctionResult lastestResult, List<FunctionResult> details)> ExecuteAsync(string type,string token, CancellationToken cancellationToken)
        {
            var lastestResult = FunctionResult.Success;
            var details = new List<FunctionResult>();

            var attribute = GetCacheAttribute();

            if (attribute != null && CacheKey.IsNullOrEmpty() == false)
            {
                var exist = _cache.Exist(CacheKey);
                if (exist) return GetCache(attribute);
            }

            (lastestResult, details) = await ExecuteStepHandlersAsync(type, token, cancellationToken);

            SetCache(lastestResult, details, attribute);

            return (lastestResult, details);
        }

        private void SetCache(FunctionResult lastestResult, List<FunctionResult> details, UseCacheAttribute attribute)
        {
            if (attribute != null) _cache.Add(CacheKey, (lastestResult, details), DateTime.UtcNow.AddSeconds(attribute.Seconds));
        }

        public void AddHandler(BaseStepHandler handler)
        {
            _listHandlers.Add(handler);
        }

        public void AddHandlers(params BaseStepHandler[] listHandlers)
        {
            _listHandlers.AddRange(listHandlers);
        }
    }
}
