using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Application.Validations;
using RepairShop.Domain.Entities;
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
            Validar(document);

            if (Status == ApplicationStatus.Erro || Status == ApplicationStatus.ErroNegocio)
                return null;

            var entity = _mapper.Map<Document>(document);

            entity = _service.Add(entity);

            return _mapper.Map<DocumentDTO>(entity);
                
        }

        public DocumentDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public DocumentDTO GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(DocumentDTO document)
        {
            throw new NotImplementedException();
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
