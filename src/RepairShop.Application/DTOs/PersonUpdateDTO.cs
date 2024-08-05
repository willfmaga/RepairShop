namespace RepairShop.Application.DTOs
{
    public class PersonUpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public PersonType? TypeId { get; set; }
        public string DocumentValue { get; set; }
    }
}
