using Common.Data.Core;
using Common.Data.TenantDbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class ServiceHandlerBase
    {
        protected readonly ITenantDbConnection _tenantDbConnection;
        protected readonly IDapperOperation _dapperOperation;

        public ServiceHandlerBase(ITenantDbConnection tenantDbConnection, IDapperOperation dapperOperation)
        {
            _tenantDbConnection = tenantDbConnection;
            _dapperOperation = dapperOperation;
        }
    }
}
