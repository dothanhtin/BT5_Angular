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
    class RemovePrefixCacheStepHandler : BaseStepHandler
    {
        private readonly string _prefix;
        private readonly ICache _cache;
        public RemovePrefixCacheStepHandler(string prefix)
        {
            _prefix = prefix;
            _cache = DependencyResolution.Resolve<ICache>();
        }
        public override bool Required => true;

        public override Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            _cache.RemovePrefix(_prefix);
            return Task.FromResult(FunctionResult.Success);
        }
    }
}
