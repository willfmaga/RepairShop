using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;

namespace Repositories
{
    [TestFixture]
    public class F_OrderRepositoryDapperTest
    {
        private OrderRepositoryDapper _repo;
        private DateTime _deliveryDate;
        private DateTime _initialDate;

        [OneTimeSetUp]
        public void Setup()
        {

            _repo = new OrderRepositoryDapper(UtilForTest.connectionString);
            _deliveryDate = DateTime.Now.AddDays(2);
            _initialDate = DateTime.Now;
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var orderOfService = new Order
            {
                ShopId = 1,
                ClientId = 1,
                MechanicId = 1,
                VehicleId = 1,
                GeneralObservations = "VERIFICAR MOTO ESTOURANDO, VERIFICAR SETA QUE NAO ESTA FUNCIONANDO",
                AmountItem = 500m,
                AmountService = 250m,
                InitialDate = _initialDate,
                DeliveryDate = _deliveryDate,
                Discount = 100,
                Active = true
            };


            //act 
            var result = _repo.Add(orderOfService);

            orderOfService = new Order
            {
                ShopId = 1,
                ClientId = 1,
                MechanicId = 1,
                VehicleId = 1,
                GeneralObservations = "VERIFICAR PAINEL APAGADO",
                AmountItem = 100m,
                AmountService = 150m,
                InitialDate = _initialDate,
                DeliveryDate = _deliveryDate.AddDays(-1),
                Discount = 20,
                Active = true
            };
            var result2 = _repo.Add(orderOfService);

            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

            Assert.IsNotNull(result2);
            Assert.That(result2.Id, Is.AtLeast(1));
        }

        [Test]
        public void GetByClientWhenExists()
        {
            //arrange
            var cliendId = 1;

            //act 
            var result = _repo.GetByClient(cliendId);


            //assert
            Assert.IsNotNull(result);
            Assert.Greater(result.Count(), 0);

        }


        [Test]
        public void GetByMechanicWhenExists()
        {
            //arrange
            var cliendId = 1;

            //act 
            var result = _repo.GetByMechanic(cliendId);


            //assert
            Assert.IsNotNull(result);
            Assert.Greater(result.Count(), 0);

        }

        [Test]
        public void GetByInitialDateWhenExists()
        {
            //arrange


            //act 
            var result = _repo.GetByInitialDate(_initialDate);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(2));



        }

        [Test]
        public void GetByDeliveryDateWhenExists()
        {
            //arrange

            //act 
            var result = _repo.GetByDeliveryDate(_deliveryDate);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));



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

        [Test]
        public void GetByVehicleWhenObjectExists()
        {
            //arrange
            var vehicleId = 1;

            //act 
            var result = _repo.GetByVehicle(vehicleId);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));

        }

        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var order = new Order
            {
                Id = 1,
                ShopId = 1,
                ClientId = 1,
                MechanicId = 1,
                VehicleId = 1,
                GeneralObservations = "VERIFICAR VAZAMENTO DE GASOLINA",
                AmountItem = 200m,
                AmountService = 950m,
                InitialDate = _initialDate.AddDays(-1),
                DeliveryDate = DateTime.Now.AddDays(8),
                Discount = 40M,
                Active = false
            };

            //act 
            _repo.Update(order);


            ////assert 
            var result = _repo.GetById(order.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Discount, Is.EqualTo(order.Discount));
            Assert.That(result.Active, Is.EqualTo(order.Active));
            Assert.That(result.AmountItem, Is.EqualTo(order.AmountItem));

        }


    }
}
