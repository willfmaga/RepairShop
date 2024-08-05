using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;


namespace RepairShop.Application.MapperConfig.Profilers
{
    public class PersonProfiler : Profile
    {

        public PersonProfiler()
        {
            CreateMap<Person, PersonDocumentDTO>().ReverseMap();
   
        }
    }
}
