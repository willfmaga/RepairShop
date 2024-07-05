using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class OrderOfService
    {
        public Int64 Id { get; set; }

        public Shop Shop { get; set; }

        public Person Client { get; set; }
        public Vehicle Vehicle { get; set; }

        public IEnumerable<String> GeneralObservations { get; set; }

        public IEnumerable<ServiceItem> Items { get; set; }
        public Person Mechanic { get; set; }
        public Decimal AmountItems { get; set; }
        public Decimal AmountService { get; set; }

        public Decimal Discount {  get; set; }
        public Decimal Total {  get; set; }

        public DateTime InitialDate { get; set; }
        public DateTime DeliveryDate { get;set; }
    }
}
