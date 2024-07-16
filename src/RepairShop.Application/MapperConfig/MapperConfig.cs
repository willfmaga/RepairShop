using AutoMapper;
using RepairShop.Application.MapperConfig.Profilers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Application.MapperConfig
{
    public static class MapperConfig
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {

            get
            {
                if (_mapper is null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<DocumentProfiler>();
                    });

                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }

        }
    }
}
