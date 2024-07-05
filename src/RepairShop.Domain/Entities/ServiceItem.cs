using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class ServiceItem
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }

        public ServiceType Type { get; set; }
    }

    public enum ServiceType
    {
        none = 0,
        [Display(Name  = "Serviço")]
        Service = 1,
        [Display(Name = "Peças")]
        Parts = 2
    }
}
