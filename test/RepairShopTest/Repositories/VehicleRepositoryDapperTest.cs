using RepairShop.Infrastructure.Repositories;
using RepairShop.Domain.Entities;
using RepairShopTest;

namespace Repositories
{
    public class D_VehicleRepositoryDapperTest
    {
        private VehicleRepositoryDapper _repo;
        private string _plate;

        [OneTimeSetUp]
        public void Setup()
        {
            _repo = new VehicleRepositoryDapper(UtilForTest.connectionString);
            _plate = "FAE6A10";

        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var vehicle = new Vehicle
            {
                Plate = "FAE6A10",
                Name = "Sportsters",
                TypeId = VehicleType.Bike,
                BrandId = VehicleBrand.HarleyDavidson,
                Model = "Iron 883N",
                ColorId = VehicleColor.Beige,
                ManufacturingYear = 2015,
                Year = 2015,
                Active = true

            };

            //act 
            var result = _repo.Add(vehicle);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange
            var id = 1;

            //act 
            var result = _repo.GetById(id);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Plate, Is.EqualTo(_plate));

        }

        [Test]
        public void GetByPlateWhenExists()
        {

            //act 
            var result = _repo.GetByPlate(_plate);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.Plate, Is.EqualTo(_plate));

        }

        [Test]
        public void GetByTypeWhenObjectExists()
        {
            //arrange

            var type = VehicleType.Bike;

            //act 
            var result = _repo.GetByTypeAndBrand(type, null);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.AtLeast(1));

        }


        [Test]
        public void GetByBrandWhenObjectExists()
        {
            //arrange
            var brand = VehicleBrand.HarleyDavidson;


            //act 
            var result = _repo.GetByTypeAndBrand(null, brand);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.AtLeast(1));

        }


        [Test]
        public void GetByNameWhenExists()
        {
            //arrange
            var name = "Will";

            ////act 
            //var result = _repo.GetByName(name);


            //////assert 
            //Assert.IsNotNull(result);
            //Assert.IsTrue(result.First().Name.Contains(name));
            //Assert.Greater(result.Count(), 0);

        }




        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var vehicle = new Vehicle
            {
                Id = 1,
                Name = "Shadow",
                BrandId = VehicleBrand.Honda,
                ColorId = VehicleColor.Black,
                ManufacturingYear = 2018,
                Model = "Shadow 600",
                Plate = "FAE7A10",
                TypeId = VehicleType.Car,
                Year = 2018,
                Active = false
            };

            //act 
            _repo.Update(vehicle);


            //assert 
            var result = _repo.GetById(vehicle.Id);

            Assert.IsNotNull(result);
            Assert.That(result.TypeId, Is.EqualTo(vehicle.TypeId));
            Assert.That(result.Active, Is.EqualTo(vehicle.Active));

        }





    }
}
