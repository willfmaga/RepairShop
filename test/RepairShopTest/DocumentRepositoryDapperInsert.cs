using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;

namespace RepairShopTest
{
    public class DocumentoRepositoryDapper
    {
        private string _connectionString;
        private DocumentRepositoryDapper _repo;

        [SetUp]
        public void Setup()
        {
            _connectionString = UtilForTest.connectionString;
            _repo = new DocumentRepositoryDapper(_connectionString);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var document = new Document { Type = DocumentType.CPF, Value = "18701886088" };

            //act 
            var result = _repo.Add(document);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.AtLeast(0));

        }

        [Test]
        public void GetByValueWhenObjectExists()
        {
            //arrange
            var document = new Document { Type = DocumentType.CPF, Value = "18701886088" };

            //act 
            var result = _repo.GetByValue(document.Value);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo(document.Value));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var document = new Document { Id = 1, Type = DocumentType.CNPJ, Active = false };
            
            //act 
            _repo.Update(document);


            //assert 
            var result = _repo.Get(document.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Type, Is.EqualTo(document.Type));
            Assert.That(result.Active, Is.EqualTo(document.Active));

        }

        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange
            var document = new Document { Id = 1 };

            //act 
            var result = _repo.Get(document.Id);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(document.Id));

        }

    }
}