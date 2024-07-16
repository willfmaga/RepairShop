using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public Document Add(Document document)
        {
            return _documentRepository.Add(document);
        }

        public Document GetById(long id)
        {
            return _documentRepository.GetById(id);
        }

        public Document GetByValue(string value)
        {
            return _documentRepository.GetByValue(value);
        }

        public void Update(Document document)
        {
           _documentRepository.Update(document);
        }
    }
}
