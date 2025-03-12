using Devops.Places.Api.Endpoints.Abstractions;
using Devops.Places.Api.Models.GetPlaces;
using Microsoft.Extensions.Options;

namespace Devops.Places.Api.Endpoints;

public sealed class GetPlacesEndpoint(IOptions<GetPlacesOptions> options) : IEndpoint<GetPlacesRequest, GetPlacesResponse>
{
    public ValueTask<GetPlacesResponse> InvokeAsync(GetPlacesRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}