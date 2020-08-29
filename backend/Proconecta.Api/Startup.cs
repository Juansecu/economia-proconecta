namespace Proconecta.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Proconecta.Middleware.Extensions;
    using Proconecta.Middleware.Interfaces;

    public class Startup
    {
        #region Attributes
        private readonly string CORS_NAME = "CORS_ALL";
        #endregion

        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add and configure controllers.
            services.ConfigureControllers();

            // AddConfig AutoMapper.
            services.ConfigureAutoMapper();

            // AddConfig Swagger.
            services.ConfigureSwagger();

            // Add Data bases contexts.
            services.ConfigureDataBases(Configuration);

            // Add Salfa Authentication.
            services.ConfigAuth(Configuration);

            // Confifure Polices auth.
            services.ConfigureAuth();

            // Configure all services.
            services.ConfigureServices(Configuration);

            // Compression.
            services.AddResponseCompression();

            // AddConfig CORS.
            services.ConfigureCors(CORS_NAME);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IJsonService jsonService)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.ConfigureSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseApiResponseMiddleware();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseCors(CORS_NAME);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
