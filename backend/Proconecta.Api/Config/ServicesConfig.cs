namespace Proconecta.Api
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Proconecta.Core;
    // using Proconecta.Core;
    using Proconecta.Data;
    using Proconecta.Middleware.Interfaces;
    using Proconecta.Middleware.Services;

    public static class ServicesConfig
    {
        public static void ConfigureServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Add Singletons.
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IJsonService, JsonService>();

            // Unit Work.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Scopes.
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<IPreOrderBL, PreOrderBL>();
            services.AddScoped<IPreOrderDetailBL, PreOrderDetailBL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IProjectBL, ProjectBL>();
            services.AddScoped<IProviderBL, ProviderBL>();
            services.AddScoped<IReviewBL, ReviewBL>();
            services.AddScoped<ITagBL, TagBL>();
            services.AddScoped<IUserBL, UserBL>();

        }
    }
}
