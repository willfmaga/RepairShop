using Google.Protobuf.WellKnownTypes;
using RepairShop.Application.Applications;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using RepairShop.Domain.Services;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;
using System.Runtime.ConstrainedExecution;

namespace Application
{
    [TestFixture]
    public class A_DocumentApplicationTest
    {
        private IDocumentService _service;
        private IDocumentRepository _repository;
        private IDocumentApplication _application;
        private DocumentDTO _document;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables();


            _repository = new DocumentRepositoryDapper(UtilForTest.connectionString);
            _service = new DocumentService(_repository);
            _application = new DocumentApplication(_service);
            _document = new DocumentDTO  {
                TypeId = DocumentType.CPF,
                Value = "18701886088"
            };
        }


        [Test]
        public void AddWhenObjectIsValid()
        {
            //act 
            var result = _application.Add(_document);

            var status = _application.Status;

            
            //assert 
            Assert.IsTrue(status == ApplicationStatus.Sucesso);
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo(_document.Value));
            

        }

        [Test]
        public void NotAddWhenObjectIsInvalid()
        {
            //arrange
            var document = new DocumentDTO
            {
                TypeId = DocumentType.None
                
            };

            //act 
            var result = _application.Add(document);

            var status = _application.Status;
            string errors = _application.ErrorsToString();

            //assert 
            Assert.IsTrue(errors.Contains("Campo Value deve ter no maximo 14 digitos."));
            Assert.IsTrue(errors.Contains("Tipo de documento nao pode ser 0 - None"));
            Assert.IsTrue(status == ApplicationStatus.ErroNegocio);
            Assert.IsNull(result);
            


        }

        [Test]
        public void NotAddWhenObjectIsNull()
        {
            //arrange
            

            //act 
            var result = _application.Add(null!);

            var status = _application.Status;
            

            //assert 
            Assert.IsTrue(status == ApplicationStatus.Erro);
            Assert.IsNull(result);



        }

        [Test]
        public void GetByValueWhenObjectExists()
        {
            //arrange
            _application.Add(_document);

            //act 
            var result = _application.GetByValue(_document.Value);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo(_document.Value));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange
            _application.Add(_document);

            var documentoUpdateDTO = new DocumentUpdateDTO
            {
                TypeId = DocumentType.CNPJ,
                Active = false,
                Value = _document.Value 
            };

            //act 
            _application.Update(documentoUpdateDTO);


            //assert 
            var result = _application.GetById(1);

            Assert.IsNotNull(result);
            Assert.That(result.TypeId, Is.EqualTo(documentoUpdateDTO.TypeId));
            Assert.That(false, Is.EqualTo(documentoUpdateDTO.Active));

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