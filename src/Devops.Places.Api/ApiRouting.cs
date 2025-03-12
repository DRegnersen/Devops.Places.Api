using Devops.Places.Api.Endpoints;
using Devops.Places.Api.Models.CreatePlace;
using Devops.Places.Api.Models.GetPlaces;
using Microsoft.AspNetCore.Mvc;

namespace Devops.Places.Api;

internal static class ApiRouting
{
    public static void ConfigureEndpoints(IEndpointRouteBuilder builder)
    {
        var routeBuilder = builder
            .MapGroup("/api")
            .WithTags("Places API")
            .WithOpenApi();

        routeBuilder
            .MapPost("/place", (
                    [FromBody] CreatePlaceRequest request,
                    [FromServices] CreatePlaceEndpoint endpoint,
                    CancellationToken cancellationToken)
                => endpoint.InvokeAsync(request, cancellationToken))
            .WithName("Create Place");

        routeBuilder
            .MapGet("/all-places", (
                    [FromQuery] int? maxPlaces,
                    [FromServices] GetPlacesEndpoint endpoint,
                    CancellationToken cancellationToken)
                => endpoint.InvokeAsync(new GetPlacesRequest { MaxPlaces = maxPlaces }, cancellationToken))
            .WithName("Get Places");
    }
}