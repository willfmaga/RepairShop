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

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables();


            _repository = new DocumentRepositoryDapper(UtilForTest.connectionString);
            _service = new DocumentService(_repository);
            _application = new DocumentApplication(_service);
        }


        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            DocumentDTO document = new() { TypeId = DocumentType.CPF, 
                                           Value = "18701886088" };

            //act 
            var result = _application.Add(document);

            var status = _application.Status;

            
            //assert 
            Assert.IsTrue(status == ApplicationStatus.Sucesso);
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo(document.Value));
            

        }

        [Test]
        public void NotAddWhenObjectIsInvalid()
        {
            //arrange
            DocumentDTO document = new()
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

        //[Test]
        //public void GetByValueWhenObjectExists()
        //{
        //    //arrange
        //    var document = new Document { TypeId = DocumentType.CPF, Value = "18701886088" };

        //    //act 
        //    var result = _service.GetByValue(document.Value);


        //    //assert 
        //    Assert.IsNotNull(result);
        //    Assert.That(result.Value, Is.EqualTo(document.Value));

        //}



        //[Test]
        //public void UpdateWhenObjectExists()
        //{
        //    //arrange 
        //    var document = new Document
        //    {
        //        Id = 1,
        //        TypeId = DocumentType.CNPJ,
        //        Active = false
        //    };

        //    //act 
        //    _service.Update(document);


        //    //assert 
        //    var result = _service.GetById(document.Id);

        //    Assert.IsNotNull(result);
        //    Assert.That(result.TypeId, Is.EqualTo(document.TypeId));
        //    Assert.That(result.Active, Is.EqualTo(document.Active));

        //}

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