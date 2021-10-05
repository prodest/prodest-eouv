using AutoMapper;

namespace Prodest.EOuv.Shared.Configuracao
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });

            return config;
        }
    }
}