using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Application.DTOs
{

    public class DocumentUpdateDTO
    {
        public DocumentType? TypeId { get; set; }
        public string Value { get; set; }

        public bool Active { get; set; } = true;

    }

  

}
