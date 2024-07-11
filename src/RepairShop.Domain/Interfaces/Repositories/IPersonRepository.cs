using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        public Person Add(Person Person);
        public void Update(Person Person);
        public Person GetById(Int64 id);
        public IEnumerable<Person> GetByName(string name);
        public IEnumerable<Person> GetBySurname(string surname);

        public IEnumerable<Person> GetByBirthDay(DateTime birthdate);
        public Person GetByDocument(string documentValue);
    }
}
