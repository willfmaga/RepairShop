using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using RepairShop.Domain.Services;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;

namespace Services
{
    public class B_PersonServiceTest
    {
        private IPersonService _service;
        private IPersonRepository _personRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            _personRepository = new PersonRepositoryDapper(UtilForTest.connectionString);

            _service = new PersonService(_personRepository);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var person = new Person
            {
                TypeId = PersonType.Client,
                Name = "William",
                Surname = "Fernandes",
                BirthDate = new DateTime(1980, 05, 08),
                DocumentId = 1
            };

            //act 
            var result = _service.Add(person);


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
            var document = "18701886088";

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
            var person = new Person
            {
                Id = 1,
                Name = "Gisele",
                Surname = "Magalhaes",
                BirthDate = new DateTime(1981, 09, 18),
                DocumentId = 1,
                TypeId = PersonType.Client,
                Active = false
            };

            //act 
            _service.Update(person);


            //assert 
            var result = _service.GetById(person.Id);

            Assert.IsNotNull(result);
            Assert.That(result.TypeId, Is.EqualTo(person.TypeId));
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
