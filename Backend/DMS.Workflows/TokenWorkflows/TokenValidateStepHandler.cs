using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DMS.Core.Models;
using DMS.Core.Services;
using DMS.Shared;
using VNPT.Framework.CommonType;

namespace DMS.Workflows
{
    [UseCache]
    public class TokenValidateStepHandler : BaseStepHandler
    {
        private readonly ITokenService _tokenService;
        private readonly string _token;
        private readonly string _pathApi;
        public TokenValidateStepHandler(string pathApi, string token)
        {
            //CacheKey = $"TokenValidateStepHandler_{token}";
            _tokenService = DependencyResolution.Resolve<ITokenService>();
            _token = token;
            _pathApi = pathApi;
        }
        public override bool Required => true;


        public async override Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var sessiontoken = await _tokenService.GetTokenInfoAsync(_pathApi, _token, cancellationToken);

            if (sessiontoken == null) return result.Error(ErrorCodeCollection.AccountError.TokenInvalid);
            if (sessiontoken.OrgDecentral == ErrorCodeCollection.AccountError.YouDoNotHavePermission) return result.Error(ErrorCodeCollection.AccountError.YouDoNotHavePermission);
            if (sessiontoken.ExpiredOn <= DateTime.UtcNow) return result.Error(ErrorCodeCollection.AccountError.TokenInvalid);

            result.SetData(sessiontoken);
            return result;
        }
    }
}
