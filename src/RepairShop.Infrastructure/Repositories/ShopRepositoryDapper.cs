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
    public class ShopRepositoryDapper : CrudBaseDapper<Shop>, IShopRepository
    {
        public ShopRepositoryDapper(string connectionString) : base(connectionString) { }

        public Shop Add(Shop shop)
        {
            string script = AllQueries.Person_Add;
            var param = new DynamicParameters();


            param.Add("@Id", shop.Id, DbType.Int32);
            param.Add("@Name", shop.Name, DbType.String, size: 50);
            param.Add("@Description", shop.Description, DbType.String, size: 250);
            param.Add("@Address", shop.Address, DbType.String, size: 500);
            param.Add("@DocumentId", shop.DocumentId, DbType.Int16);
            param.Add("@Phone", shop.Phone, DbType.String, size:15);


            shop.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return shop;
        }

        public Person Delete(Person Person)
        {
            throw new NotImplementedException();
        }

        public Person Get(Int64 id)
        {
            string script = AllQueries.Person_ById;
            var param = new DynamicParameters();


            param.Add("@Id", id, DbType.Int64);

            return ExecuteScriptWithoutTransactionSingle<Person>(script, param);
        }

        public IEnumerable<Shop> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetByBirthDay(DateTime birthdate)
        {
            string script = AllQueries.Person_ByBirthDate;
            var param = new DynamicParameters();


            param.Add("@BirthDate", birthdate, DbType.Date);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public IEnumerable<Person> GetByDocument(string documentValue)
        {
            string script = AllQueries.Person_ByDocument;
            var param = new DynamicParameters();


            param.Add("@DocumentValue", documentValue, DbType.String, size: 14);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public IEnumerable<Person> GetByName(string name)
        {
            string script = AllQueries.Person_ByName;
            var param = new DynamicParameters();


            param.Add("@Name", name, DbType.String, size: 50);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public IEnumerable<Person> GetBySurname(string surname)
        {
            string script = AllQueries.Person_BySurname;
            var param = new DynamicParameters();


            param.Add("@Surname", surname, DbType.String, size: 100);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public IEnumerable<Shop> GetName(string name)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person Person)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Shop> IShopRepository.GetByDocument(string documentValue)
        {
            throw new NotImplementedException();
        }
    }
}
