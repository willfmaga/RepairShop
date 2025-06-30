using System.ComponentModel.DataAnnotations;

namespace RepairShop.Application.DTOs
{
    public class ClientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Document { get; set; }

    }
}
