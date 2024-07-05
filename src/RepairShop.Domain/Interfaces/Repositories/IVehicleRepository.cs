using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository
    {

        public IEnumerable<Vehicle> GetAll();
        public Vehicle GetById(Int64 id);

        public Vehicle GetByPlate(string plate);

        public Vehicle Add (Vehicle vehicle);

        public Vehicle Update (Vehicle vehicle);

        public Vehicle Delete (Vehicle vehicle);

        public IEnumerable<Vehicle> GetByType(Type type);

    }
}
