using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class ApiClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) : IApiClient
{
    private const string AccessTokenClaimType = "access_token";
    public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
    {
        AddBearerTokenIfExists();
        var response = await httpClient.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        AddBearerTokenIfExists();
        var response = await httpClient.PostAsJsonAsync(endpoint, request);
        if (!response.IsSuccessStatusCode)
            return default;
            
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
    
    private void AddBearerTokenIfExists()
    {
        var accessToken = httpContextAccessor
            .HttpContext?
            .User
            .FindFirst(AccessTokenClaimType)?
            .Value;

        if (string.IsNullOrWhiteSpace(accessToken))
            return;

        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    }
}
