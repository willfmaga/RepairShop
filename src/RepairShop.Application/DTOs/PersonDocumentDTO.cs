using System.ComponentModel.DataAnnotations;

namespace RepairShop.Application.DTOs
{
    public class PersonDocumentDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public PersonType? TypeId { get; set; }

        public DocumentDTO Document { get; set; }
    }

    public enum PersonType
    {
        None = 0,
        [Display(Name = "Cliente")]
        Client = 1,
        [Display(Name = "Mecanico")]
        Mechanic = 2,
        [Display(Name = "Proprietario")]
        Owner = 3

    }

}
