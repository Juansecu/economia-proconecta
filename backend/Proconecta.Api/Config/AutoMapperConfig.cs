namespace Proconecta.Api
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Proconecta.Data.Models;

    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Entity, EntityVM>()
            //   .ReverseMap();
        }
    }
}
