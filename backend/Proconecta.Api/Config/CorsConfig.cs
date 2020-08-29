namespace Proconecta.Api
{
    using Microsoft.Extensions.DependencyInjection;

    public static class CorsConfig
    {
        public static void ConfigureCors(this IServiceCollection services, string name)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name, builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                );
            });
        }
    }
}
