using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Item
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? CostPrice { get; set; }

        public ItemType? TypeId { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

        public bool? OnlyDisplay { get; set; } 
    }

    public enum ItemType
    {
        none = 0,
        [Display(Name  = "Serviço")]
        Service = 1,
        [Display(Name = "Peças")]
        Parts = 2
    }
       
}
