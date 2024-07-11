using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface ItemRepository
    {
        public IEnumerable<Item> GetAllForDisplay();
        public Item GetById(Int64 id);
        
        public IEnumerable<Item> GetByName(string name);
        public IEnumerable<Item> GetByPriceAndCostPrice(decimal? price, decimal? costprice);

        public Item Add(Item item);

        public void Update(Item item);

        public IEnumerable<Item> GetByType(ItemType itemtype);

    }
}
