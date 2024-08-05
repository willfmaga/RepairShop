using AutoMapper;
using RepairShop.Application.MapperConfig.Profilers;


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
                        cfg.AddProfile<PersonProfiler>();
                    });

                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }

        }
    }
}
