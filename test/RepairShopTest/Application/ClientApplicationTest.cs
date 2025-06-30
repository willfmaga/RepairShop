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
    public class A_ClientApplicationTest
    {
        private IClientService _service;
        private IClientRepository _repository;
        private IClientApplication _application;
        private ClientDTO _personDto;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables(); 
            _repository = new ClientRepositoryDapper(UtilForTest.connectionString);

            _service = new ClientService(_repository);

            _application = new ClientApplication(_service);

            _personDto = new ClientDTO
            {
                BirthDate = DateTime.Now.AddYears(-19),
                Name = "Will",
                Surname = "Fernandes Magalhaes",
                Document = "73748752075"
            };
        }


        [Test]
        public void AddWhenObjectIsValid()
        {
            //act 
            var result = _application.Add(_personDto);

            var status = _application.Status;


            //assert 
            Assert.IsTrue(status == ApplicationStatus.Sucesso);
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(_personDto.Name));
            Assert.That(result.Surname, Is.EqualTo(_personDto.Surname));


        }

        [Test]
        public void NotAddWhenObjectIsInvalid()
        {
            //arrange
            _personDto.Name = "Wi";
            //act 
            var result = _application.Add(_personDto);

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
            ////arrange
            _application.GetByName(_personDto.Name);

            ////act 
            var result = _application.GetByName(_personDto.Name);


            ////assert 
            Assert.IsNotNull(result);
            Assert.That(result.First().Name, Is.EqualTo(_personDto.Name));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange
            _application.Add(_personDto);

            var personUpdateDTO = new ClientUpdateDTO
            {
                BirthDate = DateTime.Now.AddYears(-15),
                Name = "Gisele",
                Surname = "Magalhaes"

            };

            //act 
            _application.Update(personUpdateDTO);


            //assert 
            //var result = _application.GetById(1);

            //Assert.IsNotNull(result);
            //Assert.That(result.TypeId, Is.EqualTo(personUpdateDTO.TypeId));
            //Assert.That(false, Is.EqualTo(personUpdateDTO.Active));

        }

        //[Test]
        //public void GetByIdWhenObjectExists()
        //{
        //    //arrange


        //    //act 
        //    var result = _service.GetById(1);


        //    //assert 
        //    Assert.IsNotNull(result);
        //    Assert.That(result.Id, Is.EqualTo(1));
        //    Assert.That(result.Active, Is.EqualTo(true));
        //}

    }
}