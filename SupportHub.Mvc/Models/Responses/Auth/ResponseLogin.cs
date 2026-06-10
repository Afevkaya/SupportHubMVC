namespace SupportHub.Mvc.Models.Responses.Auth;

public record ResponseLogin(string AccessToken, DateTime ExpirationAt, Guid UserId, string Email, string FullName);