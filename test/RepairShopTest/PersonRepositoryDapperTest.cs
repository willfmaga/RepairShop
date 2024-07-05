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
            var person = new Person { Type = PersonType.Client, Name = "William", Surname = "Fernandes"
            , BirthDate = new DateTime(1980,05, 08), DocumentId = 1};

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
            Assert.That(result.First().BirthDate.Date, Is.EqualTo(birthdate.Date));
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
            Assert.That("William", Is.EqualTo(result.First().Name));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var document = new Document { Id = 1, Type = DocumentType.CNPJ, Active = false };

            //act 
           // _repo.Update(document);


            //assert 
            //var result = _repo.Get(document.Id);

            //Assert.IsNotNull(result);
            //Assert.That(result.Type, Is.EqualTo(document.Type));
            //Assert.That(result.Active, Is.EqualTo(document.Active));

        }
        
        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange
            var id = 1;

            //act 
            var result = _repo.Get(id);


            //assert 
            Assert.IsNotNull(result);
            Assert.That("William", Is.EqualTo(result.Name));

        }



    }
}
