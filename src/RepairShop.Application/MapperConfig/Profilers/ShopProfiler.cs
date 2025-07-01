using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;


namespace RepairShop.Application.MapperConfig.Profilers
{
    public class ShopProfiler : Profile
    {

        public ShopProfiler()
        {
            CreateMap<Shop, ShopDTO>().ReverseMap();
   
        }
    }
}
