using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace DMS.Core.Repositories
{
    public interface ITokenRepository
    {
        Task<SessionToken> GetTokenInfoAsync(string pathApi, string token, CancellationToken cancellationToken);
        Task<SessionToken> GetSessionTokenByAccountAsync(Guid accountId, Guid organizationId ,int decentralization, string source, CancellationToken cancellationToken);
    }
}
