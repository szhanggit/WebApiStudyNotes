using Common.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Data.TenantDbConnection
{
    public class TenantDbConnection : ITenantDbConnection, IDisposable
    {
        public async Task<Response<IDbConnection>> GetTenantDbConnection(string tenantId, bool isReadReplica, CancellationToken cancellationToken)
        {
            return await GetTenantDbConnection(isReadReplica, cancellationToken);
        }

        public async Task<Response<IDbConnection>> GetTenantDbConnection(bool isReadReplica, CancellationToken cancellationToken)
        {
            // otherwise, use normal sharding
            try
            {
                return Response.Success<IDbConnection>("Success", new SqlConnection(""));
            }
            catch (Exception ex)
            {
                return Response.Fail<IDbConnection>(ex.Message, null);
            }
        }

        public void Dispose()
        {

        }
    }
}
