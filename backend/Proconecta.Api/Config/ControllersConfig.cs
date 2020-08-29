namespace Proconecta.Api
{
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Proconecta.Middleware.Extensions;

    public static class ControllersConfig
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => // Configure Json input / output.
                {
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DefaultValueHandling =
                        DefaultValueHandling.Include;
                    options.SerializerSettings.NullValueHandling =
                        NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;

                    options.SerializerSettings.DateParseHandling =
                        DateParseHandling.DateTimeOffset;
                    options.SerializerSettings.DateFormatHandling =
                        DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.DateTimeZoneHandling =
                        DateTimeZoneHandling.Utc;
                });

            services.AddModelStateFeatureFilter();
        }
    }
}

