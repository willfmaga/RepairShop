using AutoMapper;

using RepairShop.Application.DTOs;
using RepairShop.Application.Interfaces;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Update(ShopUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
