using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopTest
{
    public class F_OrderOfServiceRepositoryDapperTest
    {
        private OrderOfServiceRepositoryDapper _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new OrderOfServiceRepositoryDapper(UtilForTest.connectionString);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var orderOfService = new OrderOfService
            {
                ShopId = 1,
                ClientId = 1,
                MechanicId = 1,
                VehicleId = 1,
                GeneralObservations = "VERIFICAR MOTO ESTOURANDO, VERIFICAR SETA QUE NAO ESTA FUNCIONANDO",
                AmountItem = 500m,
                AmountService = 250m,
                InitialDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(2),
                Discount = 100,
                Active = true
            };


            //act 
            var result = _repo.Add(orderOfService);

            orderOfService = new OrderOfService
            {
                ShopId = 1,
                ClientId = 1,
                MechanicId = 1,
                VehicleId = 1,
                GeneralObservations = "VERIFICAR PAINEL APAGADO",
                AmountItem = 100m,
                AmountService = 150m,
                InitialDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(3),
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
            DateTime birthdate = Convert.ToDateTime("2024-07-12 13:55:20");

            //act 
            var result = _repo.GetByInitialDate(birthdate);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(2));
            
            

        }

        [Test]
        public void GetByDeliveryDateWhenExists()
        {
            //arrange
            DateTime birthdate = Convert.ToDateTime("2024-07-15 13:55:20");

            //act 
            var result = _repo.GetByDeliveryDate(birthdate);


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
            var order = new OrderOfService
            {
                Id = 1,
                ShopId = 1,
                ClientId = 1,
                MechanicId = 1,
                VehicleId = 1,
                GeneralObservations = "VERIFICAR VAZAMENTO DE GASOLINA",
                AmountItem = 200m,
                AmountService = 950m,
                InitialDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(8),
                Discount = 40M,
                Active = false
            };

            //act 
            _repo.Update(order);


            ////assert 
            var result = _repo.GetById(order.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Discount , Is.EqualTo(order.Discount));
            Assert.That(result.Active, Is.EqualTo(order.Active));
            Assert.That(result.AmountItem, Is.EqualTo(order.AmountItem));

        }


    }
}
