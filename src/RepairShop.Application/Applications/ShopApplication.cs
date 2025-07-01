using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Application.Validations;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Services;


namespace RepairShop.Application.Applications
{
    public class ShopApplication : Base, IShopApplication
    {
        private readonly IShopService _shopservice;
        private IMapper _mapper = MapperConfig.MapperConfig.Mapper;

        public ShopApplication(IShopService service)
        {
            _shopservice = service;
        }


        public ShopDTO Add(ShopDTO dto)
        {
            //validation 
            Validar(dto);
            if (Status == ApplicationStatus.ErroNegocio)
            {
                ErrorMessage = ErrorsToString();
                return null;
            }

            var entity = _mapper.Map<Shop>(dto);

            var addedEntity = _shopservice.Add(entity);
            return _mapper.Map<ShopDTO>(addedEntity);
        }

        public IEnumerable<ShopDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ShopDTO GetByDocument(string document)
        {
            throw new NotImplementedException();
        }

        public ShopDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopDTO> GetByName(string name)
        {
            var entities = _shopservice.GetByName(name);
            
            var returnDTO = _mapper.Map<IEnumerable<ShopDTO>>(entities);

            return returnDTO;
        }

        public void Update(ShopUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }

        public void Validar(ShopDTO dto)
        {
            //Validations 
            var validationResult = new ShopValidator().Validate(dto);

            if (validationResult != null && !validationResult.IsValid)
            {
                Status = ApplicationStatus.ErroNegocio;
                ValidationsFailure = validationResult?.Errors;
            }
        }
    }
}
