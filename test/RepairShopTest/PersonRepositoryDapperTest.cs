using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopTest
{
    public class PersonRepositoryDapperTest
    {
        private PersonRepositoryDapper _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new PersonRepositoryDapper(UtilForTest.connectionString);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var person = new Person
            {
                Type = PersonType.Client,
                Name = "William",
                Surname = "Fernandes",
                BirthDate = new DateTime(1980, 05, 08),
                DocumentId = 1
            };

            //act 
            var result = _repo.Add(person);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(0));

        }

        [Test]
        public void GetByNameWhenExists()
        {
            //arrange
            var name = "William";

            //act 
            var result = _repo.GetByName(name);


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
            var result = _repo.GetBySurname(name);


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
            var result = _repo.GetByBirthDay(birthdate);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.First().BirthDate.Value.Date, Is.EqualTo(birthdate.Date));
            Assert.Greater(result.Count(), 0);

        }

        [Test]
        public void GetByDocumentWhenObjectExists()
        {
            //arrange
            var document = "18701886088";

            //act 
            var result = _repo.GetByDocument(document);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(0));

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
                Type = PersonType.Client,
                Active = false
            };

            //act 
            _repo.Update(person);


            //assert 
            var result = _repo.GetById(person.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Type, Is.EqualTo(person.Type));
            Assert.That(result.Name, Is.EqualTo(person.Name));
            Assert.That(result.Surname, Is.EqualTo(person.Surname));

        }

        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange
            var id = 1;

            //act 
            var result = _repo.GetById(id);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(0));

        }



    }
}
