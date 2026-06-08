using SupportHub.Mvc.Models.Requests.Auth;
using SupportHub.Mvc.Models.Responses.Auth;

namespace SupportHub.Mvc.Services.Abstractions;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest loginRequest);
}