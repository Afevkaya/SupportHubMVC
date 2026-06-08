namespace SupportHub.Mvc.Models.Responses.Auth;

public record LoginResponse(string AccessToken, DateTime ExpirationAt, Guid UserId, string Email, string FullName);