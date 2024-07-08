using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Person
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public Int64? DocumentId { get; set; }

        public PersonType? Type { get; set; }

        public bool? Active { get; set; }

    }

    public enum PersonType
    {
        none = 0,
        [Display(Name = "Cliente")]
        Client = 1,
        [Display(Name = "Mecanico")]
        Mechanic = 2,
        [Display(Name = "Proprietario")]
        Owner = 3

    }

}
