using Dapper;
using Google.Protobuf.Compiler;
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
    public class ItemRepositoryDapper : CrudBaseDapper<Item>, IItemRepository
    {
        public ItemRepositoryDapper(string connectionString) : base(connectionString) { }

        public Item Add(Item item)
        {
            string script = AllQueries.Item_Add;
            var param = new DynamicParameters();


            param.Add("@Name", item.Name, DbType.String, size: 250);
            param.Add("@Price", item.Price, DbType.Decimal);
            param.Add("@CostPrice", item.CostPrice, DbType.Decimal);
            param.Add("@TypeId", item.TypeId, DbType.Int16);
            param.Add("@CreationDate", item.CreationDate, DbType.DateTime);
            param.Add("@OnlyDisplay", item.OnlyDisplay, DbType.Boolean);

            item.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return item;
        }

        public IEnumerable<Item> GetAllForDisplay()
        {
            string script = AllQueries.Item_GetAllForDisplay;
            var param = new DynamicParameters();

            return ExecuteScriptWithoutTransactionList<Item>(script, param);
        }

        public Item GetById(long id)
        {
            string script = AllQueries.Item_GetById;
            var param = new DynamicParameters();


            param.Add("@Id", id , DbType.Int64);

            return ExecuteScriptWithoutTransactionSingle<Item>(script, param);
        }

        public IEnumerable<Item> GetByName(string name)
        {
            string script = AllQueries.Item_GetByName;
            var param = new DynamicParameters();


            param.Add("@Name", name, DbType.String, size:250);

            return ExecuteScriptWithoutTransactionList<Item>(script, param);
        }

        public IEnumerable<Item> GetByPriceAndCostPrice(decimal? price, decimal? costprice)
        {
            string script = AllQueries.Item_GetByPriceAndCostPrice;
            var param = new DynamicParameters();


            param.Add("@Price", price, DbType.Decimal);
            param.Add("@CostPrice", costprice, DbType.Decimal);

            return ExecuteScriptWithoutTransactionList<Item>(script, param);
        }

        public IEnumerable<Item> GetByType(ItemType itemType)
        {
            string script = AllQueries.Item_GetByType;
            var param = new DynamicParameters();


            param.Add("@TypeId", itemType, DbType.Int16);

            return ExecuteScriptWithoutTransactionList<Item>(script, param);
        }

        public void Update(Item item)
        {
            string script = AllQueries.Item_Update;
            var param = new DynamicParameters();


            param.Add("@Id", item.Id, DbType.Int64);
            param.Add("@Name", item.Name, DbType.String, size: 250);
            param.Add("@Price", item.Price, DbType.Decimal);
            param.Add("@CostPrice", item.CostPrice, DbType.Decimal);
            param.Add("@TypeId", item.TypeId, DbType.Int16);
            param.Add("@OnlyDisplay", item.OnlyDisplay, DbType.Boolean);

            ExecuteScriptWithTransaction(script, param);
        }
    }
}
