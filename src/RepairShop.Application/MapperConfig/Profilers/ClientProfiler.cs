using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;


namespace RepairShop.Application.MapperConfig.Profilers
{
    public class ClientProfiler : Profile
    {

        public ClientProfiler()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Client, ClientUpdateDTO>().ReverseMap();
   
        }
    }
}
