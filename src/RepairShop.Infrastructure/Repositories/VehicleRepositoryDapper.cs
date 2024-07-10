using Dapper;
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
    public class VehicleRepositoryDapper : CrudBaseDapper<Vehicle>, IVehicleRepository
    {
        public VehicleRepositoryDapper(string connectionString) : base(connectionString) { }

        public Vehicle Add(Vehicle vehicle)
        {
            string script = AllQueries.Vehicle_Add;
            var param = new DynamicParameters();


            param.Add("@Plate", vehicle.Plate, DbType.String, size: 7);
            param.Add("@Name", vehicle.Name, DbType.String, size: 50);
            param.Add("@TypeId", vehicle.TypeId, DbType.Int16);
            param.Add("@BrandId", vehicle.BrandId, DbType.Int16);
            param.Add("@Model", vehicle.Model, DbType.String, size: 50);
            param.Add("@ColorId", vehicle.ColorId, DbType.Int16);
            param.Add("@ManufacturingYear", vehicle.ManufacturingYear, DbType.Int16);
            param.Add("@Year", vehicle.Year, DbType.Int16);
            param.Add("@Active", vehicle.Active, DbType.Boolean);


            vehicle.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return vehicle;
        }

     
        public Vehicle GetById(long id)
        {
            string script = AllQueries.Vehicle_GetById;
            var param = new DynamicParameters();

            param.Add("@Id", id, DbType.Int64);

            return ExecuteScriptWithoutTransactionSingle<Vehicle>(script, param);
        }

        public Vehicle GetByPlate(string plate)
        {
            string script = AllQueries.Vehicle_GetByPlate;
            var param = new DynamicParameters();

            param.Add("@Plate", plate, DbType.String, size:7);

            return ExecuteScriptWithoutTransactionSingle<Vehicle>(script, param);
        }

        public IEnumerable<Vehicle> GetByTypeAndBrand(VehicleType? vehicleType, VehicleBrand? vehicleBrand)
        {
            string script = AllQueries.Vehicle_GetByTypeAndBrand;
            var param = new DynamicParameters();



            param.Add("@TypeId", vehicleType, DbType.Int16);
            param.Add("@BrandId", vehicleBrand, DbType.Int16);

            return ExecuteScriptWithTransactionList<Vehicle>(script, param);
        }

        public void Update(Vehicle vehicle)
        {
            string script = AllQueries.Vehicle_Update;
            var param = new DynamicParameters();


            param.Add("@Id", vehicle.Id, DbType.Int64);

            param.Add("@Plate", vehicle.Plate, DbType.String, size: 7);
            param.Add("@Name", vehicle.Name, DbType.String, size: 50);
            param.Add("@TypeId", vehicle.TypeId, DbType.Int16);
            param.Add("@BrandId", vehicle.BrandId, DbType.Int16);
            param.Add("@Model", vehicle.Model, DbType.String, size: 50);
            param.Add("@ColorId", vehicle.ColorId, DbType.Int16);
            param.Add("@ManufacturingYear", vehicle.ManufacturingYear, DbType.Int16);
            param.Add("@Year", vehicle.Year, DbType.Int16);
            param.Add("@Active", vehicle.Active, DbType.Boolean);

            ExecuteScriptWithTransaction(script, param);
        }
    }
}
