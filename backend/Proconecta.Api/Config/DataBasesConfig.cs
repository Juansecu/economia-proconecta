namespace Proconecta.Api
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Proconecta.Data.Contexts;

    public static class DataBasesConfig
    {
        public static void ConfigureDataBases(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Get connection string.
            var connection = configuration.GetConnectionString("db_Proconecta");
            // Use sql server and change migrations directory.
            services.AddDbContext<ProconectaContext>(options => options.UseMySql(connection,
                        x => x.MigrationsAssembly("Proconecta.Data")));
        }
    }
}
