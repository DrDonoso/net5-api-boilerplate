using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Boilerplate.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Boilerplate Api", Version = "v1" });
            });

            return services;
        }
    }
}