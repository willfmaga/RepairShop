using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public Vehicle Add(Vehicle vehicle)
        {
            return _repository.Add(vehicle);
        }

        public Vehicle GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Vehicle GetByPlate(string plate)
        {
            return _repository.GetByPlate(plate);
        }

        public IEnumerable<Vehicle> GetByTypeAndBrand(VehicleType? vehicleType, VehicleBrand? vehicleBrand)
        {
            return _repository.GetByTypeAndBrand(vehicleType, vehicleBrand);
        }

        public void Update(Vehicle vehicle)
        {
            _repository.Update(vehicle);
        }
    }
}
