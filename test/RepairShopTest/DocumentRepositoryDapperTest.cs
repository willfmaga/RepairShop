using RepairShop.Domain.Entities;
using RepairShop.Infrastructure.Repositories;

namespace RepairShopTest
{
    public class A_DocumentRepositoryDapperTest
    {
        private DocumentRepositoryDapper _repo;

        [SetUp]
        public void Setup()
        {
           
            _repo = new DocumentRepositoryDapper(UtilForTest.connectionString);
        }

        [Test]
        public void AddWhenObjectIsValid()
        {
            //arrange
            var document = new Document { TypeId = DocumentType.CPF, Value = "18701886088" };

            //act 
            var result = _repo.Add(document);


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
            var result = _repo.GetByValue(document.Value);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo(document.Value));

        }



        [Test]
        public void UpdateWhenObjectExists()
        {
            //arrange 
            var document = new Document { Id = 1, 
                                        TypeId = DocumentType.CNPJ, 
                                        Active = false 
                                        };
            
            //act 
            _repo.Update(document);


            //assert 
            var result = _repo.Get(document.Id);

            Assert.IsNotNull(result);
            Assert.That(result.TypeId, Is.EqualTo(document.TypeId));
            Assert.That(result.Active, Is.EqualTo(document.Active));

        }

        [Test]
        public void GetByIdWhenObjectExists()
        {
            //arrange
            

            //act 
            var result = _repo.Get(1);


            //assert 
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Active, Is.EqualTo(false));
        }

    }
}