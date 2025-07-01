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
        private ClientDTO _clientDto;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables(); 
            _repository = new ClientRepositoryDapper(UtilForTest.connectionString);

            _service = new ClientService(_repository);

            _application = new ClientApplication(_service);

            _clientDto = new ClientDTO
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
            var result = _application.Add(_clientDto);

            var status = _application.Status;


            //assert 
            Assert.IsTrue(status == ApplicationStatus.Sucesso);
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(_clientDto.Name));
            Assert.That(result.Surname, Is.EqualTo(_clientDto.Surname));


        }

        [Test]
        public void NotAddWhenObjectIsInvalid()
        {
            //arrange
            _clientDto.Name = "Wi";
            //act 
            var result = _application.Add(_clientDto);

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
            var result = _application.GetByName(_clientDto.Name);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.GreaterThan(0));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            var newName = "William";
            var newSurname = "F. Magalhaes";
            var newBirth = DateTime.Now.AddYears(-15);
            //arrange
            _application.Add(_clientDto);

            var personUpdateDTO = new ClientUpdateDTO
            {
                BirthDate = newBirth,
                Name = newName,
                Surname = newSurname,
                Document = "73748752075",
            };

            //act 
            _application.Update(personUpdateDTO);

            //assert 
            var result = _application.GetByDocument(personUpdateDTO.Document);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(newName));
            Assert.That(result.Surname, Is.EqualTo(newSurname));
            Assert.That(result.BirthDate, Is.EqualTo(newBirth.Date));
          

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