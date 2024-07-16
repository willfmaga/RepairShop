using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IOrderService
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
