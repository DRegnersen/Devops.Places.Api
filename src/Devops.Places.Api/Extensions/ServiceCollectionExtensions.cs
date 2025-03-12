using Devops.Places.Api.Endpoints;
using Devops.Places.Api.Models.GetPlaces;

namespace Devops.Places.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .Configure<GetPlacesOptions>(configuration.GetSection("Services:GetPlacesEndpoint"));

        services
            .AddScoped<CreatePlaceEndpoint>()
            .AddScoped<GetPlacesEndpoint>();

        return services;
    }
}