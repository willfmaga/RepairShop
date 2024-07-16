using RepairShop.Domain.Entities;

namespace RepairShop.Domain.Interfaces.Services
{
    public interface IVehicleService
    {


        public Vehicle GetById(Int64 id);

        public Vehicle GetByPlate(string plate);

        public Vehicle Add(Vehicle vehicle);

        public void Update(Vehicle vehicle);

        public IEnumerable<Vehicle> GetByTypeAndBrand(VehicleType? vehicleType, VehicleBrand? vehicleBrand);
        
    }
}
