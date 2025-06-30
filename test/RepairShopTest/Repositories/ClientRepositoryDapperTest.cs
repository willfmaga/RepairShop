using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;

namespace Repositories
{
    public class A_ClientRepositoryDapperTest
    {
        private ClientRepositoryDapper _repo;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables(); // Ensure the database is clean before tests
            _repo = new ClientRepositoryDapper(UtilForTest.connectionString);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var person = new Client
            {
                Name = "Will",
                Surname = "Fernandes",
                BirthDate = new DateTime(1981, 05, 08),
                Document = "73748752075"
            };

            //act 
            var result = _repo.Add(person);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void GetByNameWhenExists()
        {
            //arrange
            var name = "Will";

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
            DateTime birthdate = new DateTime(1981, 05, 08);

            //act 
            var result = _repo.GetByBirthDay(birthdate);


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
            var result = _repo.GetByDocument(document);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var client = new Client
            {
                Name = "William",
                Surname = "Magalhaes",
                BirthDate = new DateTime(1981, 09, 18),
                Document = "73748752075"
            };

            //act 
            _repo.Update(client);


            //assert 
            var result = _repo.GetByDocument(client.Document);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(client.Name));
            Assert.That(result.Surname, Is.EqualTo(client.Surname));

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
            Assert.That(result.Id, Is.AtLeast(1));

        }
    }
}
