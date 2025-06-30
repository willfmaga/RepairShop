using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;

namespace RepairShop.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Client Add(Client client)
        {
            return _repository.Add(client);
        }

        public IEnumerable<Client> GetByBirthDay(DateTime birthdate)
        {
            return _repository.GetByBirthDay(birthdate);
        }

        public Client GetByDocument(string documentValue)
        {
            return _repository.GetByDocument(documentValue);
        }

        public Client GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Client> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public IEnumerable<Client> GetBySurname(string surname)
        {
            return _repository.GetBySurname(surname);
        }

        public void Update(Client client)
        {
            _repository.Update(client);
        }
    }
}
