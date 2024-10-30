
namespace NorskApi.Api.Common.Mapping;

using Mapster;
using MapsterMapper;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);

        services.AddScoped<IMapper, Mapper>();

        return services;
    }
}