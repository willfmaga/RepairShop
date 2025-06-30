namespace RepairShop.Application.DTOs
{
    public class ClientUpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public string Document { get; set; }
    }
}
