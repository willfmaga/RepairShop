using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;


namespace RepairShop.Application.Interfaces
{
    public interface IClientApplication : IBase
    {
        public ClientDTO Add(ClientDTO client);
        public void Update(ClientUpdateDTO clientUpdate);
        public ClientDTO GetById(Int64 id);
        public IEnumerable<ClientDTO> GetByName(string name);
        public IEnumerable<ClientDTO> GetBySurname(string surname);
        public IEnumerable<ClientDTO> GetByBirthDay(DateTime birthdate);
        public ClientDTO GetByDocument(string documentValue);
    }
}
