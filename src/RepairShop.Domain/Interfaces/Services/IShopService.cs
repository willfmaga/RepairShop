using RepairShop.Domain.Entities;

namespace RepairShop.Domain.Interfaces.Services
{
    public interface IShopService
    {
        public IEnumerable<Shop> GetAll();

        public IEnumerable<Shop> GetByName(string name);

        public Shop GetByDocument(string document);

        public Shop Add(Shop shop);
        public Shop GetById(Int64 id);

        public void Update(Shop shop);
    }
}
