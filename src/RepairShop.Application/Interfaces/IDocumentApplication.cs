using RepairShop.Application.Applications;
using RepairShop.Application.DTOs;

namespace RepairShop.Application.Interfaces
{
    public interface IDocumentApplication: IBase
    {
        public DocumentDTO Add(DocumentDTO document);
        public void Update(DocumentUpdateDTO document);
        public DocumentDTO GetById(Int64 id);
        public DocumentDTO GetByValue(string value);

     
    }
}
