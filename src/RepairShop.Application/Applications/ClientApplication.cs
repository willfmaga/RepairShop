using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Application.Validations;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Services;


namespace RepairShop.Application.Applications
{
    public class ClientApplication : Base, IClientApplication
    {
        private readonly IClientService _clientService;
        private IMapper _mapper = MapperConfig.MapperConfig.Mapper;

        public ClientApplication(IClientService clientService)
        {
            _clientService = clientService;
        }

        public ClientDTO Add(ClientDTO clientDTO)
        {
            Validar(clientDTO);

            if (Status == ApplicationStatus.ErroNegocio)
            {
                ErrorMessage = ErrorsToString();
                return null;
            }

            var entity = _mapper.Map<Client>(clientDTO);

            entity = _clientService.Add(entity);

            return _mapper.Map<ClientDTO>(entity);
        }

        public IEnumerable<ClientDTO> GetByBirthDay(DateTime birthdate)
        {
            var entities = _clientService.GetByBirthDay(birthdate);

            return _mapper.Map<IEnumerable<ClientDTO>>(entities);  
        }

        public ClientDTO GetByDocument(string documentValue)
        {
            var entity = _clientService.GetByDocument(documentValue);

            return _mapper.Map<ClientDTO>(entity);
        }

        public ClientDTO GetById(long id)
        {
            var entity = _clientService.GetById(id);

            return _mapper.Map<ClientDTO>(entity);
        }

        public IEnumerable<ClientDTO> GetByName(string name)
        {
            var dto = _mapper.Map<IEnumerable<ClientDTO>>(_clientService.GetByName(name));

            return dto;
        }

        public IEnumerable<ClientDTO> GetBySurname(string surname)
        {
            var entities = _clientService.GetBySurname(surname);

            return _mapper.Map<IEnumerable<ClientDTO>>(entities);
        }

        public void Update(ClientUpdateDTO entityUpdate)
        {
            try
            {
                var entity = _clientService.GetByDocument(entityUpdate.Document);

                if (entity is not null)
                {
                    _clientService.Update(entity);
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

        public void Validar(ClientDTO personDTO)
        {
            //Validations 
            var validationResult = new ClientValidator().Validate(personDTO);

            if (validationResult != null && !validationResult.IsValid)
            {
                Status = ApplicationStatus.ErroNegocio;
                ValidationsFailure = validationResult?.Errors;
            }
        }

    }
}
