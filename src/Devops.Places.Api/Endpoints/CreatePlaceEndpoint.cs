using Devops.Places.Api.Endpoints.Abstractions;
using Devops.Places.Api.Models.CreatePlace;

namespace Devops.Places.Api.Endpoints;

public sealed class CreatePlaceEndpoint : IEndpoint<CreatePlaceRequest, CreatePlaceResponse>
{
    public ValueTask<CreatePlaceResponse> InvokeAsync(CreatePlaceRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}