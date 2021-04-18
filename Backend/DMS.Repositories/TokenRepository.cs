using Couchbase;
using Couchbase.N1QL;
using DMS.Core.Models;
//using DMS.Core.Models.ObjectPermission;
using DMS.Core.Repositories;
using DMS.Repositories.Helpers;
using DMS.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Repositories
{
    public class TokenRepository:ITokenRepository
    {
        private static CouchbaseDataAccess dataAccess = CouchbaseDataAccess.Instance;
        private Couchbase.Core.IBucket bucket = dataAccess.TokenBucket;
        public async Task<SessionToken> GetTokenInfoAsync(string pathApi, string token, CancellationToken cancellationToken)
        {
              var statement = $"SELECT bucketname.* FROM {bucket.Name} AS bucketname WHERE `token` = $_token AND  `partition` = $_partition ORDER BY expiredOn DESC LIMIT 1";
            var query = new QueryRequest(statement)
                            .AddNamedParameter("_partition", "SessionToken")
                            .AddNamedParameter("_token", token);

            var result = await bucket.QueryAsync<SessionToken>(query);

            return result.Rows.FirstOrDefault();

        }

        public async Task<SessionToken> GetSessionTokenByAccountAsync(Guid accountId,Guid organizationId, int decentralization,  string source, CancellationToken cancellationToken)
        {
            var statement = $"SELECT bucketname.* FROM {bucket.Name} AS bucketname WHERE accountId = $_accountid AND source =  $_source  AND  `partition` = $_partition";
            var query = new QueryRequest(statement)
                            .AddNamedParameter("$_partition", "SessionToken")
                            .AddNamedParameter("$_accountid", accountId)
                            .AddNamedParameter("$_source", source);
            var result = await bucket.QueryAsync<SessionToken>(query);

            var sessionToken = result.Rows.FirstOrDefault();
            if (sessionToken == null) // if sessionToken is null, return SessionToken equivalent AccountId
            {
                var resultSessionToken = new SessionToken();
                resultSessionToken.AccountId = accountId;
                resultSessionToken.Source = source;
                resultSessionToken.OrgDecentral = organizationId.ToString() + "-" + decentralization.ToString();
                return resultSessionToken;
            }
            else
            {
                sessionToken.OrgDecentral = organizationId.ToString() + "-" + decentralization.ToString();
                return sessionToken;
            }

        }
    }
}
