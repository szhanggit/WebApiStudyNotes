using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data.Core
{
    public interface IExecuteOperation<TOut>
    {
        //public Task<TOut> Execute(IDapperParameter parameter);
        public Task<TOut> Execute(IDbConnection dbConnection, CommandDefinition commandDefinition);
        public Task<TOut> Execute(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}
