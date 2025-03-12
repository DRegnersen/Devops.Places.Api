using Devops.Places.Api;
using Devops.Places.Api.Extensions;
using Devops.Places.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints(configuration);
builder.Services.AddDataAccess(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMongoDbInitialization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(ApiRouting.ConfigureEndpoints);
app.Run();