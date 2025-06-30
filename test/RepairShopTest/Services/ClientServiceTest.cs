using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using RepairShop.Domain.Services;
using RepairShop.Infrastructure.Repositories;

using RepairShopTest;

namespace Services
{
    public class A_ClientServiceTest
    {
        private IClientService _service;
        private IClientRepository _personRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            _personRepository = new ClientRepositoryDapper(UtilForTest.connectionString);

            _service = new ClientService(_personRepository);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var client = new Client
            {
                Name = "William",
                Surname = "Fernandes",
                BirthDate = new DateTime(1980, 05, 08),
                Document = "73748752075"
            };

            //act 
            var result = _service.Add(client);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void GetByNameWhenExists()
        {
            //arrange
            var name = "William";

            //act 
            var result = _service.GetByName(name);


            //assert 
            Assert.IsNotNull(result);
            Assert.Greater(result.Count(), 0);

        }


        [Test]
        public void GetBySurnameWhenExists()
        {
            //arrange
            var name = "Fern";

            //act 
            var result = _service.GetBySurname(name);


            //assert 
            Assert.IsNotNull(result);
            Assert.IsTrue(result.First().Surname.Contains(name));
            Assert.Greater(result.Count(), 0);

        }

        [Test]
        public void GetByBirthDateWhenExists()
        {
            //arrange
            DateTime birthdate = new DateTime(1980, 05, 08);

            //act 
            var result = _service.GetByBirthDay(birthdate);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.First().BirthDate.Value.Date, Is.EqualTo(birthdate.Date));
            Assert.That(result.Count(), Is.AtLeast(1));

        }

        [Test]
        public void GetByDocumentWhenObjectExists()
        {
            //arrange
            var document = "73748752075";

            //act 
            var result = _service.GetByDocument(document);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var person = new Client
            {
                Id = 1,
                Name = "Gisele",
                Surname = "Magalhaes",
                BirthDate = new DateTime(1981, 09, 18),
                Document = "73748752075",
                Active = false
            };

            //act 
            _service.Update(person);


            //assert 
            var result = _service.GetById(person.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(person.Name));
            Assert.That(result.Surname, Is.EqualTo(person.Surname));

        }

        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange
            var id = 1;

            //act 
            var result = _service.GetById(id);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }



    }
}
