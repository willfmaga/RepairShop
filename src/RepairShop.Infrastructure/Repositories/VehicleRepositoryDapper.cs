using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
