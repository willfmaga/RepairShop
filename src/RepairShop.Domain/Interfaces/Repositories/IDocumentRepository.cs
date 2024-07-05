using Document = RepairShop.Domain.Entities.Document;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        public Document Add (Document document);
        public void Update(Document document);
        public Document Get(Int64 id);
        public Document GetByValue(string value);
    }
}
