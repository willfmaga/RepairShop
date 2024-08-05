using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Application.Validations;
using RepairShop.Domain.Interfaces.Services;


namespace RepairShop.Application.Applications
{
    public class DocumentApplication : Base, IDocumentApplication
    {
        private IDocumentService _service;
        private IMapper _mapper = MapperConfig.MapperConfig.Mapper;
        public DocumentApplication(IDocumentService service)
        {
            _service = service;
        }

        public DocumentDTO Add(DocumentDTO document)
        {
            try
            {
                Validar(document);

                if (Status == ApplicationStatus.ErroNegocio)
                {
                    ErrorMessage = ErrorsToString();
                    return null!;
                }

                var entity = _mapper.Map<Domain.Entities.Document>(document);

                entity = _service.Add(entity);

                return _mapper.Map<DocumentDTO>(entity);
            }
            catch (Exception e)
            {
                Status = ApplicationStatus.Erro;
                ErrorMessage = e.Message;
                return null!;
            }
        }

        public DocumentDTO GetById(long id)
        {
            try
            {
                var entity = _service.GetById(id);
                var dto = _mapper.Map<DocumentDTO>(entity);

                return dto;
            }
            catch (Exception e)
            {

                Status = ApplicationStatus.Erro;
                ErrorMessage = e.Message;
                return null!;
            }
        }

        public DocumentDTO GetByValue(string value)
        {
            try
            {
                var entity = _service.GetByValue(value);
                var dto = _mapper.Map<DocumentDTO>(entity);

                return dto;
            }
            catch (Exception e)
            {

                Status = ApplicationStatus.Erro;
                ErrorMessage = e.Message;
                return null!;
            }
        }

        public void Update(DocumentUpdateDTO document)
        {
            try
            {
                var entity = _service.GetByValue(document.Value);


                if (entity is not null)
                {
                    entity.Active = document.Active;
                    entity.TypeId = (Domain.Entities.DocumentType)document.TypeId;

                    _service.Update(entity);
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

        public void Validar(DocumentDTO document)
        {
            //Validations 
            var validationResult = new DocumentValidator().Validate(document);

            if (validationResult != null && !validationResult.IsValid)
            {
                Status = ApplicationStatus.ErroNegocio;
                ValidationsFailure = validationResult?.Errors;
             }
        }

    }
}
