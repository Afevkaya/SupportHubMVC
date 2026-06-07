namespace SupportHub.Mvc.Services.Abstractions;

public interface IApiClient
{
    Task<TResponse?> GetAsync<TResponse>(string endpoint);
}