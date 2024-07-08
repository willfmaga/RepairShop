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
            string script = AllQueries.Shop_Add;
            var param = new DynamicParameters();


            param.Add("@Id", shop.Id, DbType.Int64);
            param.Add("@Name", shop.Name, DbType.String, size: 100);
            param.Add("@Description", shop.Description, DbType.String, size: 500);
            param.Add("@Address", shop.Address, DbType.String, size: 500);
            param.Add("@DocumentId", shop.DocumentId, DbType.Int16);
            param.Add("@Phone", shop.Phone, DbType.String, size:15);


            shop.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return shop;
        }

        public IEnumerable<Shop> GetAll()
        {
            string script = AllQueries.Shop_GetAll;
            var param = new DynamicParameters();


            return ExecuteScriptWithoutTransactionList<Shop>(script, param);
        }

        public IEnumerable<Shop> GetByDocument(string documentValue)
        {
            string script = AllQueries.Shop_ByDocument;
            var param = new DynamicParameters();


            param.Add("@DocumentValue", documentValue, DbType.String, size: 14);

            return ExecuteScriptWithoutTransactionList<Shop>(script, param);
        }

        public IEnumerable<Shop> GetByName(string name)
        {
            string script = AllQueries.Shop_ByName;
            var param = new DynamicParameters();


            param.Add("@Name", name, DbType.String, size: 100);

            return ExecuteScriptWithoutTransactionList<Shop>(script, param);
        }
    }
}
