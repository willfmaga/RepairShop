using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Services
{
    public interface IDocumentService
    {
        public Document Add(Document document);
        public void Update(Document document);
        public Document GetById(Int64 id);
        public Document GetByValue(string value);
    }
}
