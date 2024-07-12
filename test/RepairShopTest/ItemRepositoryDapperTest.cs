using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopTest
{
    public class E_ItemRepositoryDapperTest
    {
        private RepairShop.Infrastructure.Repositories.ItemRepositoryDapper _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new RepairShop.Infrastructure.Repositories.ItemRepositoryDapper(UtilForTest.connectionString);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var item = new Item
            {
                TypeId = ItemType.Service,
                Name = "Mao de obra",
                Price = 100.00m,
                CostPrice = 50m,
                OnlyDisplay = true

            };

            //act 
            var result = _repo.Add(item);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void GetByAllForDisplayWhenExists()
        {
            //arrange

            //act 
            var result = _repo.GetAllForDisplay();


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.AtLeast(1));

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
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GetByNameWhenExists()
        {
            //arrange
            var name = "obra";

            //act 
            var result = _repo.GetByName(name);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));


        }

        [Test]
        public void GetByPriceWhenExists()
        {
            //arrange
            decimal price = 100.00m;

            //act 
            var result = _repo.GetByPriceAndCostPrice(price, null);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));

        }

        [Test]
        public void GetByCostPriceWhenExists()
        {
            //arrange
            decimal costprice = 50m;

            //act 
            var result = _repo.GetByPriceAndCostPrice(null, costprice);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));

        }

        [Test]
        public void GetByTypeWhenObjectExists()
        {
            //arrange
            var type = ItemType.Service;

            //act 
            var result = _repo.GetByType(type);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));
            Assert.That(result.First().Id, Is.EqualTo(1));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var item = new Item
            {
                Id = 1,
                Name = "Tampa de Valvula Shadow 600",
                Price = 80m,
                CostPrice = 40m,
                OnlyDisplay  = false,
                TypeId = ItemType.Parts
            };

            //act 
            _repo.Update(item);


            //assert 
            var result = _repo.GetById(item.Id);

            Assert.IsNotNull(result);
            Assert.That(result.TypeId, Is.EqualTo(item.TypeId));
            Assert.That(result.Name, Is.EqualTo(item.Name));
            Assert.That(result.TypeId, Is.EqualTo(item.TypeId));
            Assert.That(result.OnlyDisplay, Is.EqualTo(item.OnlyDisplay));

        }
    }
}
