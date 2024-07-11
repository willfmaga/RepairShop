using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Int64? DocumentId { get; set; }
        
        public string Phone {  get; set; }
        public bool? Active { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }


}
