using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DMS.Shared;
using VNPT.Framework.Cache;
using VNPT.Framework.CommonType;

namespace DMS.Workflows
{
    public class RemoveKeyCacheStepHandler : BaseStepHandler
    {
        private readonly string _key;
        private readonly ICache _cache;
        public RemoveKeyCacheStepHandler(string key)
        {
            _key = key;
            _cache = DependencyResolution.Resolve<ICache>();
        }
        public override bool Required => true;

        public override Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            _cache.Remove(_key);
            return Task.FromResult(FunctionResult.Success);
        }
    }
}
