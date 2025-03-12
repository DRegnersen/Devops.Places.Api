namespace Devops.Places.DataAccess.Services.Abstractions;

public interface IMongoDbInitializer
{
    Task InitializeAsync();
}