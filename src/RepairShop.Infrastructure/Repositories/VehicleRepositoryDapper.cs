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
            string script = AllQueries.Shop_Add;
            var param = new DynamicParameters();


            param.Add("@Id", vehicle.Id, DbType.Int64);
            param.Add("@Plate", vehicle.Plate, DbType.String, size: 7);
            param.Add("@Name", vehicle.Name, DbType.String, size: 50);
            param.Add("@Type", vehicle.Type, DbType.Int16);
            param.Add("@Brand", vehicle.Brand, DbType.Int16);
            param.Add("@Model", vehicle.Model, DbType.String, size: 50);
            param.Add("@Color", vehicle.Color, DbType.Int16);
            param.Add("@ManufacturingYear", vehicle.ManufacturingYear, DbType.Int16);
            param.Add("@Year", vehicle.Year, DbType.Int16);
            param.Add("@Active", vehicle.Active, DbType.Boolean);


            vehicle.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return vehicle;
        }

        public Vehicle Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetByPlate(string plate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetByType(Type type)
        {
            throw new NotImplementedException();
        }

        public Vehicle Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
