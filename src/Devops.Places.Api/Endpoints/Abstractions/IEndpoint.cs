namespace Devops.Places.Api.Endpoints.Abstractions;

public interface IEndpoint<in TRequest, TResponse>
{
    ValueTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken);
}