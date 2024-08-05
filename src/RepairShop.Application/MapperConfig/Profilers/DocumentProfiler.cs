using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;

namespace RepairShop.Application.MapperConfig.Profilers
{
    public class DocumentProfiler : Profile
    {

        public DocumentProfiler()
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<Document, DocumentUpdateDTO>().ReverseMap();
            
            
        }
    }
}
