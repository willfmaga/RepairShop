namespace RepairShop.Application.DTOs
{
    public class DocumentUpdateDTO
    {
        public DocumentType? TypeId { get; set; }
        public string Value { get; set; }

        public bool Active { get; set; } = true;

    }
}
