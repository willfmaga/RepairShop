using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Client
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Document { get; set; }

        public bool? Active { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

    }
      
}
