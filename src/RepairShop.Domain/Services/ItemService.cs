using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;

namespace RepairShop.Domain.Services
{
    public class ItemService: IItemService
    {

        private IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public Item Add(Item item)
        {
            return _repository.Add(item);
        }

        public IEnumerable<Item> GetAllForDisplay()
        {
            return _repository.GetAllForDisplay();
        }

        public Item GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Item> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public IEnumerable<Item> GetByPriceAndCostPrice(decimal? price, decimal? costprice)
        {
            return _repository.GetByPriceAndCostPrice(price, costprice);
        }

        public IEnumerable<Item> GetByType(ItemType itemtype)
        {
            return _repository.GetByType(itemtype);
        }

        public void Update(Item item)
        {
            _repository.Update(item);
        }
    }
}
