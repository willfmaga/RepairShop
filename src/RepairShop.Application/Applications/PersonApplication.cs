using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Application.Validations;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Services;
using Document = RepairShop.Domain.Entities.Document;


namespace RepairShop.Application.Applications
{
    public class PersonApplication : Base, IPersonApplication
    {
        private readonly IPersonService _personService;
        private readonly IDocumentService _documentService;
        private IMapper _mapper = MapperConfig.MapperConfig.Mapper;

        public PersonApplication(IPersonService personService,
                                 IDocumentService documentService)
        {
            _personService = personService;
            _documentService = documentService;
        }

        public PersonDocumentDTO Add(PersonDocumentDTO personDTO)
        {
            Validar(personDTO);

            if (Status == ApplicationStatus.ErroNegocio)
            {
                ErrorMessage = ErrorsToString();
                return null;
            }

            var entity = _mapper.Map<Person>(personDTO);


            // verify document already exists
            var document = _documentService.GetByValue(personDTO.Document.Value);

            if (document is null)
            {
                var documentEntity = _mapper.Map<Document>(personDTO.Document);
                documentEntity = _documentService.Add(documentEntity);
                entity.DocumentId = documentEntity.Id;

            }
            else
                entity.DocumentId = document.Id;


            entity = _personService.Add(entity);

            return _mapper.Map<PersonDocumentDTO>(entity);
        }

        public IEnumerable<PersonDocumentDTO> GetByBirthDay(DateTime birthdate)
        {
            throw new NotImplementedException();
        }

        public PersonDocumentDTO GetByDocument(string documentValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonDocumentDTO> GetByName(string name)
        {
            var dto = _mapper.Map<IEnumerable<PersonDocumentDTO>>(_personService.GetByName(name));

            return dto;
        }

        public IEnumerable<PersonDocumentDTO> GetBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonUpdateDTO personDto)
        {
            try
            {
                var entity = _personService.GetByDocument(personDto.DocumentValue);

                if (entity is not null)
                {

                    entity.TypeId = (Domain.Entities.PersonType)personDto.TypeId;

                    _personService.Update(entity);
                }
                else
                {
                    Status = ApplicationStatus.ErroNegocio;
                }
            }
            catch (Exception e)
            {

                Status = ApplicationStatus.Erro;
                ErrorMessage = e.Message;

            }

        }

        public void Validar(PersonDocumentDTO personDTO)
        {
            //Validations 
            var validationResult = new PersonDocumentValidator().Validate(personDTO);

            if (validationResult != null && !validationResult.IsValid)
            {
                Status = ApplicationStatus.ErroNegocio;
                ValidationsFailure = validationResult?.Errors;
            }
        }

    }
}
