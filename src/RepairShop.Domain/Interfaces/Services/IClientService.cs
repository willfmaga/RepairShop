using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Services
{
    public interface IClientService
    {
        public Client Add(Client client);
        public void Update(Client client);
        public Client GetById(Int64 id);
        public IEnumerable<Client> GetByName(string name);
        public IEnumerable<Client> GetBySurname(string surname);

        public IEnumerable<Client> GetByBirthDay(DateTime birthdate);
        public Client GetByDocument(string documentValue);
    }
}
