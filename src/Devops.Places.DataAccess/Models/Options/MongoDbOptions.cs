namespace Devops.Places.DataAccess.Models.Options;

internal sealed class MongoDbOptions
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Database { get; set; } = default!;
}