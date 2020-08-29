namespace Proconecta.Middleware.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Proconecta.Middleware.Filters;

    public static class ControllersConfig
    {
        public static void AddModelStateFeatureFilter(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ctx
                        => new ModelStateFeatureFilter();
                });
        }
    }
}

