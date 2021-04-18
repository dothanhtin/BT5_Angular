using DMS.Core.Models;
using DMS.Core.Repositories;
using DMS.Core.Services;
using DMS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class TokenService: ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
           
        }

        public async Task<SessionToken> GetTokenInfoAsync(string pathApi, string token,  CancellationToken cancellationToken)
        {
            var sessionToken = await _tokenRepository.GetTokenInfoAsync(pathApi, token, cancellationToken);
            return sessionToken;
        }

        public async Task<SessionToken> GetSessionTokenByAccountAsync(Guid accountId, Guid organizationId, int decentralization, string source, CancellationToken cancellationToken)
        {
            var sessionToken = await _tokenRepository.GetSessionTokenByAccountAsync(accountId, organizationId, decentralization, source, cancellationToken);
            return sessionToken;
        }
    }
}
