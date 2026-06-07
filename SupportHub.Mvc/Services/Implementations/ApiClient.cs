using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class ApiClient(HttpClient httpClient) : IApiClient
{
    public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
    {
        var response = await httpClient.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}