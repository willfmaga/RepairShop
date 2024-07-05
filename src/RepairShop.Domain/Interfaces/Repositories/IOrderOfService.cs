using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IOrderOfService
    {
        public IEnumerable<OrderOfService> GetByInitialDate(DateTime initialDate);
        public IEnumerable<OrderOfService> GetByDeliveryDate(DateTime deliveryDate);

        public IEnumerable<OrderOfService> GetByClient(Int64 clientId);

        public IEnumerable<OrderOfService> GetByMechanic(Int64 mechanicId);

        public IEnumerable<OrderOfService> GetByVehicle(string placa);

        public OrderOfService GetById(Int64 id);
    }
}
