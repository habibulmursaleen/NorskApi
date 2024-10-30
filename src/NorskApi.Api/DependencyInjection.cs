using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using NorskApi.Api.Common.Mapping;
using NorskApi.Infrastructure.Persistance.DBContext;
namespace NorskApi.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MVC controllers
            services.AddControllers();

            // Register Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Register CORS
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddMapping();


            return services;
        }
    }
}
