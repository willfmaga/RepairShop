using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Add(Order orderOfService)
        {
            return _repository.Add(orderOfService);
        }

        public IEnumerable<Order> GetByClient(long clientId)
        {
            return _repository.GetByClient(clientId);
        }

        public IEnumerable<Order> GetByDeliveryDate(DateTime deliveryDate)
        {
            return _repository.GetByDeliveryDate(deliveryDate);
        }

        public Order GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Order> GetByInitialDate(DateTime initialDate)
        {
            return _repository.GetByDeliveryDate(initialDate);
        }

        public IEnumerable<Order> GetByMechanic(long mechanicId)
        {
            return _repository.GetByMechanic(mechanicId);
        }

        public IEnumerable<Order> GetByVehicle(long vehicleId)
        {
            return _repository.GetByVehicle(vehicleId);
        }

        public void Update(Order orderOfService)
        {
            _repository.Update(orderOfService);
        }
    }
}
