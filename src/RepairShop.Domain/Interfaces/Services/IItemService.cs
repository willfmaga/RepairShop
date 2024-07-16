using RepairShop.Domain.Entities;


namespace RepairShop.Domain.Interfaces.Services
{
    public interface IItemService
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
