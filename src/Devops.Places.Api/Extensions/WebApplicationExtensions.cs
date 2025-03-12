using Devops.Places.DataAccess.Services.Abstractions;

namespace Devops.Places.Api.Extensions;

internal static class WebApplicationExtensions
{
    public static IApplicationBuilder UseMongoDbInitialization(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        var botSetupService = scope.ServiceProvider.GetRequiredService<IMongoDatabaseInitializer>();
        botSetupService.InitializeAsync().Wait();
        
        return app;
    }
}