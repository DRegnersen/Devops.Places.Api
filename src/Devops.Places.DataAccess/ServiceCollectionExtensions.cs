using Devops.Places.DataAccess.Models.Options;
using Devops.Places.DataAccess.Services;
using Devops.Places.DataAccess.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Devops.Places.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var dbOptions = configuration.GetValue<MongoDbOptions>("MongoDB")!;
        var connectionString = $"mongodb://{dbOptions.Username}:{dbOptions.Password}@mongo:27017/{dbOptions.Database}";
        
        services
            .AddSingleton<IMongoClient>(new MongoClient(connectionString));
        
        services
            .Configure<MongoDbOptions>(configuration.GetSection("MongoDB"));

        services
            .AddSingleton<IMongoDbInitializer, MongoDbInitializer>()
            .AddSingleton<IPlaceRepository, PlaceRepository>();
        
        return services;
    }
}