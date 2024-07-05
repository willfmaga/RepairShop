using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Document Document { get; set; }

        public PersonType Type { get; set; }

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
