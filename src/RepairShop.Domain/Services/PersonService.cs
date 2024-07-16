using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Add(Person person)
        {
            return _repository.Add(person);
        }

        public IEnumerable<Person> GetByBirthDay(DateTime birthdate)
        {
            return _repository.GetByBirthDay(birthdate);
        }

        public Person GetByDocument(string documentValue)
        {
            return _repository.GetByDocument(documentValue);
        }

        public Person GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Person> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public IEnumerable<Person> GetBySurname(string surname)
        {
            return _repository.GetBySurname(surname);
        }

        public void Update(Person person)
        {
            _repository.Update(person);
        }
    }
}
