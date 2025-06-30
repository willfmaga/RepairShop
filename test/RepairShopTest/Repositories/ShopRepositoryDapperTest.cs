using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;

namespace Repositories
{
    public class B_ShopRepositoryDapperTest
    {
        private ShopRepositoryDapper _repo;
        private object _name;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables();
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
                Document = "59134485000159"
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
            var document = "59134485000159";

            ////act 
            var result = _repo.GetByDocument(document);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("William Shop"));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var shop = new Shop
            {
                Name = "Gisele Repair Shop for Bikes",
                Description = "Repair Bike Shop for ladies and their bikes",
                Address = "Pedro Lessa, 1509 Street Embare Santos - SP CEP 11040000",
                Document = "59134485000159",
                Phone = "5513911111122",
                Active = false
            };

            //act 
            _repo.Update(shop);


            //assert 
            var result = _repo.GetByDocument(shop.Document);

            Assert.IsNotNull(result);
            Assert.Greater(result.Id, 0);
            Assert.That(result.Name, Is.EqualTo(shop.Name));
            Assert.That(result.Address, Is.EqualTo(shop.Address));
            Assert.That(result.Phone, Is.EqualTo(shop.Phone));
            Assert.That(result.Description , Is.EqualTo(shop.Description));
            Assert.That(result.Active  , Is.EqualTo(shop.Active));

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
