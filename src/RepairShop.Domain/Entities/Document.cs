using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public DocumentType? Type { get; set; }
        public string Value { get; set; }

        public bool? Active { get; set; }
    }

    public enum DocumentType
    {
        None = 0,
        CPF = 1,
        CNPJ = 2,
        RG = 3
    }
}
