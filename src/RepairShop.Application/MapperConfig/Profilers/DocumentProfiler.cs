using AutoMapper;
using RepairShop.Application.DTOs;
using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Application.MapperConfig.Profilers
{
    public class DocumentProfiler : Profile
    {

        public DocumentProfiler()
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
        }
    }
}
