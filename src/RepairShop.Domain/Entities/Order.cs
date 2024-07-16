using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Order
    {
        public Int64 Id { get; set; }

        public Int64? ShopId { get; set; }

        public Int64? ClientId { get; set; }
        public Int64? VehicleId { get; set; }

        public String? GeneralObservations { get; set; }

        public Int64? MechanicId { get; set; }
        public Decimal? AmountItem { get; set; }
        public Decimal? AmountService { get; set; }

        public Decimal? Discount { get; set; }
        public Decimal? Total
        {
            get 
            {
                return (AmountItem + AmountService) - Discount;
            }
        }

        public DateTime? InitialDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool Active { get; set; }

        private IEnumerable<Item> Items { get; set; }
    }
}
