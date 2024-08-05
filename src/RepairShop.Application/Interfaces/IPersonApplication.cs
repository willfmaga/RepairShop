using RepairShop.Application.DTOs;


namespace RepairShop.Application.Interfaces
{
    public interface IPersonApplication : IBase
    {
        public PersonDocumentDTO Add(PersonDocumentDTO personDTO);
        public IEnumerable<PersonDocumentDTO> GetByBirthDay(DateTime birthdate);
        public PersonDocumentDTO GetByDocument(string documentValue);
        public IEnumerable<PersonDocumentDTO> GetByName(string name);
        public IEnumerable<PersonDocumentDTO> GetBySurname(string surname);
        public void Update(PersonUpdateDTO personDTO);
    }
}
