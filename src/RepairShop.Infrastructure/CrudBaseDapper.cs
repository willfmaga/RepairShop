using Dapper;
using MySql.Data.MySqlClient;
using RepairShop.Infrastructure.Interfaces;
using System.Data;

namespace RepairShop.Infrastructure
{
    public class CrudBaseDapper<TEntity> : ICrudBaseDapper<TEntity> where TEntity : class
    {
        private readonly string _connectionString;
        private readonly MySqlConnection _mysqlConnection;

        public CrudBaseDapper(string connectionString)
        {
            _connectionString = connectionString;
            _mysqlConnection = new MySqlConnection(connectionString);

        }

        public void OpenConnection()
        {
            if (!(_mysqlConnection.State == ConnectionState.Open))
                _mysqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (_mysqlConnection.State != ConnectionState.Closed) _mysqlConnection.Close();
        }

        public void ExecuteScriptWithTransaction(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text)
        {
            try
            {
                OpenConnection();

                using (var transaction = _mysqlConnection.BeginTransaction())
                {
                    _mysqlConnection.Execute(commandText, parameters, transaction, commandType: cmdType);
                    transaction.Commit();
                }

            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<T> ExecuteScriptWithoutransactionList<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text)
        {
            try
            {
                OpenConnection();

                return _mysqlConnection.Query<T>(commandText, parameters, commandType: cmdType).AsEnumerable();

            }
            finally
            {

                CloseConnection();
            }
        }

        public IEnumerable<T> ExecuteScriptWithTransactionList<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text)
        {
            try
            {
                OpenConnection();
                IEnumerable<T> returnList;

                using (var transaction = _mysqlConnection.BeginTransaction())
                {
                    returnList = _mysqlConnection.Query<T>(commandText, parameters, transaction, commandType: cmdType).AsEnumerable();
                    transaction.Commit();
                }

                return returnList;


            }
            finally
            {
                CloseConnection();
            }
        }

        public T ExecuteScriptWithoutransactionSingle<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text)
        {
            try
            {
                OpenConnection();

                return _mysqlConnection.Query<T>(commandText, parameters, commandType: cmdType).FirstOrDefault();
            }
            finally
            {
                CloseConnection();
            }
        }

        public T ExecuteScriptWithTransactionSingle<T>(string commandText, DynamicParameters parameters, CommandType cmdType = CommandType.Text)
        {
            try
            {
                OpenConnection();
                T retorno;

                using (var transaction = _mysqlConnection.BeginTransaction())
                {
                    retorno = _mysqlConnection.Query<T>(commandText, parameters, transaction, commandType: cmdType).FirstOrDefault();
                    transaction.Commit();
                }

                return retorno;


            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
