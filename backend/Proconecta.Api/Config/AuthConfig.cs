namespace Proconecta.Api
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class AuthOwnSalfaConfig
    {
        public static void ConfigAuth(this IServiceCollection services,
            IConfiguration config)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = config["Authentication:JwtBearer:Authority"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = config["Authentication:JwtBearer:TokenValidation:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = config["Authentication:JwtBearer:TokenValidation:Audience"],
                        ValidateLifetime = true
                    };
                });
        }
    }
}
