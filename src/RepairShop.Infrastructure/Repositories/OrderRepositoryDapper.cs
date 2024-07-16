using Dapper;
using MySqlX.XDevAPI;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Infrastructure.Database.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Infrastructure.Repositories
{
    public class OrderRepositoryDapper : CrudBaseDapper<Order>, IOrderRepository
    {
        public OrderRepositoryDapper(string connectionString) : base(connectionString) { }

        public Order Add(Order orderOfService)
        {
            string script = AllQueries.OrderOfService_Add;
            var param = new DynamicParameters();


            param.Add("@ShopId", orderOfService.ShopId, DbType.Int64);
            param.Add("@ClientId", orderOfService.ClientId, DbType.Int64);
            param.Add("@MechanicId", orderOfService.MechanicId, DbType.Int64);
            param.Add("@VehicleId", orderOfService.VehicleId, DbType.Int64);
            param.Add("@GeneralObservations", orderOfService.GeneralObservations, DbType.String, size: 2500);
            param.Add("@AmountItem", orderOfService.AmountItem, DbType.Decimal);
            param.Add("@AmountService", orderOfService.AmountService, DbType.Decimal);
            param.Add("@Discount", orderOfService.Discount, DbType.Decimal);
            param.Add("@Total", orderOfService.Total, DbType.Decimal);
            param.Add("@InitialDate", orderOfService.InitialDate, DbType.DateTime);
            param.Add("@DeliveryDate", orderOfService.DeliveryDate, DbType.DateTime);
            param.Add("@CreationDate", orderOfService.CreationDate, DbType.DateTime);

            orderOfService.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return orderOfService; ;
        }

        public IEnumerable<Order> GetByClient(long clientId)
        {
            string script = AllQueries.OrderOfService_GetByClientId;
            var param = new DynamicParameters();


            param.Add("@ClientId", clientId, DbType.Int64);

            return ExecuteScriptWithTransactionList<Order>(script, param);


        }

        public IEnumerable<Order> GetByDeliveryDate(DateTime deliveryDate)
        {
            string script = AllQueries.OrderOfService_GetByDeliveryDate;
            var param = new DynamicParameters();


            param.Add("@DeliveryDate", deliveryDate, DbType.DateTime);


            return ExecuteScriptWithTransactionList<Order>(script, param);
        }

        public Order GetById(long id)
        {
            string script = AllQueries.OrderOfService_GetById;
            var param = new DynamicParameters();


            param.Add("@Id", id, DbType.Int64);

            return ExecuteScriptWithTransactionSingle<Order>(script, param);
        }

        public IEnumerable<Order> GetByInitialDate(DateTime initialDate)
        {
            string script = AllQueries.OrderOfService_GetByInitialDate;
            var param = new DynamicParameters();


            param.Add("@InitialDate", initialDate, DbType.DateTime);

            return ExecuteScriptWithTransactionList<Order>(script, param);
        }

        public IEnumerable<Order> GetByMechanic(long mechanicId)
        {
            string script = AllQueries.OrderOfService_GetByMechanicId;
            var param = new DynamicParameters();


            param.Add("@MechanicId", mechanicId, DbType.Int64);

            return ExecuteScriptWithTransactionList<Order>(script, param);
        }

        public IEnumerable<Order> GetByVehicle(Int64 vehicleId)
        {
            string script = AllQueries.OrderOfService_GetByVehicleId;
            var param = new DynamicParameters();


            param.Add("@VehicleId", vehicleId, DbType.Int64);

            return ExecuteScriptWithTransactionList<Order>(script, param);
        }

        public void Update(Order orderOfService)
        {
            string script = AllQueries.OrderOfService_Update;
            var param = new DynamicParameters();


            param.Add("@Id", orderOfService.Id, DbType.Int64);

            param.Add("@ShopId", orderOfService.ShopId, DbType.Int64);
            param.Add("@ClientId", orderOfService.ClientId, DbType.Int64);
            param.Add("@MechanicId", orderOfService.MechanicId, DbType.Int64);
            param.Add("@VehicleId", orderOfService.VehicleId, DbType.Int64);
            param.Add("@GeneralObservations", orderOfService.GeneralObservations, DbType.String, size: 2500);
            param.Add("@AmountItem", orderOfService.AmountItem, DbType.Decimal);
            param.Add("@AmountService", orderOfService.AmountService, DbType.Decimal);
            param.Add("@Discount", orderOfService.Discount, DbType.Decimal);
            param.Add("@Total", orderOfService.Total, DbType.Decimal);
            param.Add("@InitialDate", orderOfService.InitialDate, DbType.DateTime);
            param.Add("@DeliveryDate", orderOfService.DeliveryDate, DbType.DateTime);
            param.Add("@Active", orderOfService.Active, DbType.Boolean);

            ExecuteScriptWithTransaction(script, param);

        }
    }
}
