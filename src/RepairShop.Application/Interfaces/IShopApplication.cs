using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;


namespace RepairShop.Application.Interfaces
{
    public interface IShopApplication : IBase
    {
        public IEnumerable<ShopDTO> GetAll();

        public IEnumerable<ShopDTO> GetByName(string name);

        public ShopDTO GetByDocument(string document);

        public ShopDTO Add(ShopDTO shopDTO);
        public ShopDTO GetById(Int64 id);

        public void Update(ShopUpdateDTO shopUpdateDTO);
    }
}
