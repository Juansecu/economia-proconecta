namespace Proconecta.Api
{
    using Microsoft.Extensions.DependencyInjection;
    using Proconecta.Data;

    public static class AuthorizationConfig
    {
        public static void ConfigureAuth(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Provider",
                    authBuilder =>
                    {
                        authBuilder.RequireRole(Roles.Provider);
                    });

            });
        }
    }
}
