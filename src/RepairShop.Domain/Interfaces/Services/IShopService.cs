using RepairShop.Domain.Entities;

namespace RepairShop.Domain.Interfaces.Services
{
    public interface IShopService
    {
        public IEnumerable<Shop> GetAll();

        public IEnumerable<Shop> GetByName(string name);

        public IEnumerable<Shop> GetByDocument(string documentValue);

        public Shop Add(Shop shop);
        public Shop GetById(Int64 id);

        public void Update(Shop shop);
    }
}
