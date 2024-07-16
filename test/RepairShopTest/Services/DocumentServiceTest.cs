using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using RepairShop.Domain.Services;
using RepairShop.Infrastructure.Repositories;
using RepairShopTest;

namespace Services
{
    [TestFixture]
    public class A_DocumentServiceTest
    {
        private IDocumentService _service;
        private IDocumentRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            UtilForTest.TruncateTables();


            _repository = new DocumentRepositoryDapper(UtilForTest.connectionString);
            _service = new DocumentService(_repository);
        }


        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var document = new Document { TypeId = DocumentType.CPF, Value = "18701886088" };

            //act 
            var result = _service.Add(document);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(1));

        }

        [Test]
        public void GetByValueWhenObjectExists()
        {
            //arrange
            var document = new Document { TypeId = DocumentType.CPF, Value = "18701886088" };

            //act 
            var result = _service.GetByValue(document.Value);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo(document.Value));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var document = new Document
            {
                Id = 1,
                TypeId = DocumentType.CNPJ,
                Active = false
            };

            //act 
            _service.Update(document);


            //assert 
            var result = _service.GetById(document.Id);

            Assert.IsNotNull(result);
            Assert.That(result.TypeId, Is.EqualTo(document.TypeId));
            Assert.That(result.Active, Is.EqualTo(document.Active));

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