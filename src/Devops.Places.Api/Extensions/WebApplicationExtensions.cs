using Devops.Places.DataAccess.Services.Abstractions;

namespace Devops.Places.Api.Extensions;

internal static class WebApplicationExtensions
{
    public static IApplicationBuilder UseMongoDbInitialization(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        var mongoDbInitializer = scope.ServiceProvider.GetRequiredService<IMongoDbInitializer>();
        mongoDbInitializer.InitializeAsync().Wait();
        
        return app;
    }
}