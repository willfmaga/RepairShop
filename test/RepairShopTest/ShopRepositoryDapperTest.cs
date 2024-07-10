using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopTest
{
    public class ShopRepositoryDapperTest
    {
        private ShopRepositoryDapper _repo;
        private object _name;

        [SetUp]
        public void Setup()
        {
            _repo = new ShopRepositoryDapper(UtilForTest.connectionString);
            _name = "William Shop";

        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var shop = new Shop
            {
                Name = "William Shop",
                Description = "Mechanic Repair Shop for Motocycles",
                Address = "Rua Pedro Lessa, 1980 Embare - Santos, SP CEP 11040-020",
                Phone = "5513988173763",
                DocumentId = 1
            };

            //act 
            var result = _repo.Add(shop);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void GetAllWhenExists()
        {
            //act 
            var result = _repo.GetAll();

            var resultlist = result.ToList();
            //assert 
            Assert.IsNotNull(result);
            Assert.Greater(result.Count(), 0);
            Assert.That(resultlist[0].Phone, Is.EqualTo("5513988173763"));
            Assert.That(resultlist[0].Active, Is.EqualTo(true));
            Assert.That(resultlist[0].Name, Is.EqualTo("William Shop"));

        }


        [Test]
        public void GetByNameWhenExists()
        {
            //arrange
            var name = "Will";

            ////act 
            var result = _repo.GetByName(name);


            ////assert 
            Assert.IsNotNull(result);
            Assert.IsTrue(result.First().Name.Contains(name));
            Assert.Greater(result.Count(), 0);

        }


        [Test]
        public void GetByDocumentWhenObjectExists()
        {
            //arrange
            var document = "18701886088";

            ////act 
            var result = _repo.GetByDocument(document);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.First().Name, Is.EqualTo("William Shop"));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var shop = new Shop
            {
                Id = 1,
                Name = "Gisele Repair Shop for Bikes",
                Description = "Repair Bike Shop for ladies and their bikes",
                Address = "Pedro Lessa, 1509 Street Embare Santos - SP CEP 11040000",
                DocumentId = 1,
                Phone = "5513911111122",
                Active = false
            };

            //act 
            _repo.Update(shop);


            //assert 
            var result = _repo.GetById(shop.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Id , Is.EqualTo(shop.Id));
            Assert.That(result.Name, Is.EqualTo(shop.Name));
            Assert.That(result.Address , Is.EqualTo(shop.Address));

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
            Assert.That(result.Name, Is.EqualTo(_name));

        }



    }
}
