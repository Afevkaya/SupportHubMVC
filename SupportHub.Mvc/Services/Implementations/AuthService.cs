using SupportHub.Mvc.Common.Constants;
using SupportHub.Mvc.Models.Requests.Auth;
using SupportHub.Mvc.Models.Responses.Auth;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class AuthService(IApiClient apiClient) : IAuthService
{
    public async Task<LoginResponse?> LoginAsync(LoginRequest loginRequest)
    {
        return await apiClient.PostAsync<LoginRequest, LoginResponse>(ApiEndpoints.Login, loginRequest);
    }
}