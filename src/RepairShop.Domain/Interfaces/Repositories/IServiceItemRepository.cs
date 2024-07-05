using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IServiceItemRepository
    {
        public IEnumerable<ServiceItem> GetAll();
        public ServiceItem GetById(Int64 id);
        
        public ServiceItem GetByName(string name);
        public ServiceItem GetByPrice(decimal price);

        public ServiceItem Add(ServiceItem ServiceItem);

        public ServiceItem Update(ServiceItem ServiceItem);

        public ServiceItem Delete(ServiceItem ServiceItem);

        public IEnumerable<ServiceItem> GetByType(Type type);

    }
}
