using Dapper;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Infrastructure.Database.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepairShop.Infrastructure.Repositories
{
    public class ClientRepositoryDapper : CrudBaseDapper<Client>, IClientRepository
    {
        public ClientRepositoryDapper(string connectionString) : base(connectionString) { }

        public Client Add(Client client)
        {
            string script = AllQueries.Client_Add;
            var param = new DynamicParameters();


            param.Add("@Id", client.Id, DbType.Int64);
            param.Add("@Name", client.Name, DbType.String, size: 50);
            param.Add("@Surname", client.Surname, DbType.String, size: 100);
            param.Add("@BirthDate", client.BirthDate, DbType.Date);
            param.Add("@Document", client.Document, DbType.String, size: 11);
            param.Add("@CreationDate", client.CreationDate, DbType.DateTime);

            client.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return client;
        }

        
        public Client GetById(Int64 id)
        {
            string script = AllQueries.Client_ById;
            var param = new DynamicParameters();


            param.Add("@Id", id, DbType.Int64);

            return ExecuteScriptWithoutTransactionSingle<Client>(script, param);
        }

        public IEnumerable<Client> GetByBirthDay(DateTime birthdate)
        {
            string script = AllQueries.Client_ByBirthDate;
            var param = new DynamicParameters();


            param.Add("@BirthDate", birthdate, DbType.Date);

            return ExecuteScriptWithoutTransactionList<Client>(script, param);
        }

        public Client GetByDocument(string document)
        {
            string script = AllQueries.Client_ByDocument;
            var param = new DynamicParameters();


            param.Add("@Document", document, DbType.String, size: 11);

            return ExecuteScriptWithoutTransactionSingle<Client>(script, param);
        }

        public IEnumerable<Client> GetByName(string name)
        {
            string script = AllQueries.Client_ByName;
            var param = new DynamicParameters();


            param.Add("@Name", name, DbType.String, size: 50);

            return ExecuteScriptWithoutTransactionList<Client>(script, param);
        }

        public IEnumerable<Client> GetBySurname(string surname)
        {
            string script = AllQueries.Client_BySurname;
            var param = new DynamicParameters();


            param.Add("@Surname", surname, DbType.String, size: 100);

            return ExecuteScriptWithoutTransactionList<Client>(script, param);
        }

        public void Update(Client client)
        {
            string script = AllQueries.Client_Update;
            var param = new DynamicParameters();

            param.Add("@Document", client.Document, DbType.String, size:11);

            param.Add("@Name", client.Name, DbType.String, size: 50);
            param.Add("@Surname", client.Surname, DbType.String, size: 100);
            param.Add("@BirthDate", client.BirthDate, DbType.Date);
            param.Add("@Active", client.Active, DbType.Boolean);

            ExecuteScriptWithTransaction(script, param);
        }
    }
}
