using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Infrastructure.Persistance.DBContext;
using NorskApi.Infrastructure.Persistance.Interceptors;
using NorskApi.Infrastructure.Persistance.Repositories;
using NorskApi.Application.Common.Interfaces.Services;
using NorskApi.Infrastructure.Services;

namespace NorskApi.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddDbContext<NorskApiDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<PublishDomainEventsInterceptor>();

            services.AddScoped<ILocalExpressionRepository, LocalExpressionRepository>();
            services.AddScoped<IDiscussionRepository, DiscussionRepository>();

            return services;
        }
    }
}