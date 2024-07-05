using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Infrastructure.Interfaces
{
    public interface ICrudBaseDapper<in TEntity> where TEntity : class
    {

        IEnumerable<T> ExecuteScriptWithTransactionList<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text);
        IEnumerable<T> ExecuteScriptWithoutransactionList<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text);

        T ExecuteScriptWithTransactionSingle<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text);
        T ExecuteScriptWithoutransactionSingle<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text);

        void ExecuteScriptWithTransaction(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text);
    }
}
