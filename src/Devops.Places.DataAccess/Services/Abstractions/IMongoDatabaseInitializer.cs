namespace Devops.Places.DataAccess.Services.Abstractions;

public interface IMongoDatabaseInitializer
{
    Task InitializeAsync();
}