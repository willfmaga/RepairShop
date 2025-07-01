using RepairShop.Application.Applications;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using RepairShop.Domain.Services;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;

namespace Application
{
    [TestFixture]
    public class B_ShopApplicationTest
    {
        private IShopService _service;
        private IShopRepository _repository;
        private IShopApplication _application;
        private ShopDTO _shopDTO;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables(); 
            _repository = new ShopRepositoryDapper(UtilForTest.connectionString);

            _service = new ShopService(_repository);

            _application = new ShopApplication(_service);

            _shopDTO = new ShopDTO
            {
                Name = "Motorcycle Repair Store",
                Document = "59134485000159",
                Address = "Rua Pedro Lessa, 1980 Embare - Santos, SP CEP 11040-020",
                Phone = "5513988173763",
                Description = "Mechanic Repair Shop for Motocycles",
                CreationDate = DateTime.Now
            };
        }


        [Test]
        public void AddWhenObjectIsValid()
        {
            //act 
            var result = _application.Add(_shopDTO);

            var status = _application.Status;


            //assert 
            Assert.IsTrue(status == ApplicationStatus.Sucesso);
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(_shopDTO.Name));
            Assert.That(result.Document , Is.EqualTo(_shopDTO.Document));
            Assert.That(result.Address, Is.EqualTo(_shopDTO.Address));
            Assert.That(result.Phone, Is.EqualTo(_shopDTO.Phone));
            Assert.That(result.Description, Is.EqualTo(_shopDTO.Description));
            Assert.That(result.CreationDate, Is.EqualTo(_shopDTO.CreationDate));



        }

        [Test]
        public void NotAddWhenObjectIsInvalid()
        {
            //arrange
            _shopDTO.Name = "Sh";
            //act 
            var result = _application.Add(_shopDTO);

            var status = _application.Status;
            string errors = _application.ErrorsToString();

            //assert 
            Assert.IsTrue(errors.Contains("Campo Name deve ter no minimo 3 digitos."));
            Assert.IsTrue(status == ApplicationStatus.ErroNegocio);
            Assert.IsNull(result);



        }


        [Test]
        public void GetByNameWhenObjectExists()
        {
            //arrange

            //act 
            var result = _application.GetByName(_shopDTO.Name);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.AtLeast(1));
            Assert.That(result.First().Name, Is.EqualTo(_shopDTO.Name));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange
            _application.Add(_shopDTO);

            var shopUpdate = new ShopUpdateDTO
            {
                Name = "Mechanics Shop Will",
                Document = "59134485000159",
                Active = false,
                Address = "Rua Pedro Lessa, 1888 Embare - Santos, SP CEP 11040-020",
            };

            //act 
            _application.Update(shopUpdate);


            //assert 
            

        }

        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange


            //act 
            var result = _service.GetById(1);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Active, Is.EqualTo(true));
        }

    }
}