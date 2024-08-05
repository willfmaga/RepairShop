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
    public class B_PersonApplicationTest
    {
        private IPersonService _service;
        private IPersonRepository _repository;
        private IPersonApplication _application;
        private IDocumentService _documentService;
        private PersonDocumentDTO _personDto;
        private IDocumentRepository _repositoryDocument;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables(); 
            _repository = new PersonRepositoryDapper(UtilForTest.connectionString);
            _repositoryDocument = new DocumentRepositoryDapper(UtilForTest.connectionString);

            _service = new PersonService(_repository);
            _documentService = new DocumentService(_repositoryDocument);

            _application = new PersonApplication(_service, _documentService);

            _personDto = new PersonDocumentDTO
            {
                TypeId = PersonType.Mechanic,
                BirthDate = DateTime.Now.AddYears(-19),
                Name = "William",
                Surname = "Fernandes Magalhaes",
                Document = new DocumentDTO
                {
                    Value = "73748752075",
                    TypeId = DocumentType.CNPJ
                }
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
            _personDto.TypeId = PersonType.None;

            //act 
            var result = _application.Add(_personDto);

            var status = _application.Status;
            string errors = _application.ErrorsToString();

            //assert 
            Assert.IsTrue(errors.Contains("Tipo de documento nao pode ser 0 - None"));
            Assert.IsTrue(status == ApplicationStatus.ErroNegocio);
            Assert.IsNull(result);



        }

        //[Test]
        //public void NotAddWhenObjectIsNull()
        //{
        //    //arrange


        //    //act 
        //    var result = _application.Add(null!);

        //    var status = _application.Status;


        //    //assert 
        //    Assert.IsTrue(status == ApplicationStatus.Erro);
        //    Assert.IsNull(result);



        //}

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

            var personUpdateDTO = new PersonUpdateDTO
            {
                TypeId = PersonType.Client,
                BirthDate = DateTime.Now.AddYears(-15),
                Name = "Gisele",
                Surname = "Simoes",
                DocumentValue = "73748752075"

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