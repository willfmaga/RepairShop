using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;

namespace RepairShop.Domain.Services
{
    public class ShopService : IShopService
    {
        private IShopRepository _repository;

        public ShopService(IShopRepository repository)
        {
            _repository = repository;
        }

        public Shop Add(Shop shop)
        {
            return _repository.Add(shop);
        }

        public IEnumerable<Shop> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Shop> GetByDocument(string documentValue)
        {
            return _repository.GetByDocument(documentValue);
        }

        public Shop GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Shop> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public void Update(Shop shop)
        {
            _repository.Update(shop);
        }
    }
}
