using RepairShop.Domain.Entities;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetByInitialDate(DateTime initialDate);
        public IEnumerable<Order> GetByDeliveryDate(DateTime deliveryDate);

        public IEnumerable<Order> GetByClient(Int64 clientId);

        public IEnumerable<Order> GetByMechanic(Int64 mechanicId);

        public IEnumerable<Order> GetByVehicle(Int64 vehicleId);

        public Order GetById(Int64 id);

        public Order Add(Order orderOfService);

        public void Update(Order orderOfService);
    }
}
