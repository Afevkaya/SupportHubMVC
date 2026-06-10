namespace SupportHub.Mvc.Common.Constants;

public static class ApiEndpoints
{
    public const string GetTickets = "/api/tickets";
    public const string GetTicketDetail = "/api/tickets/";
    public const string CreateTicket = "/api/tickets";
    public static string AddTicketComment(Guid ticketId) => $"/api/tickets/{ticketId}/comments";
    public const string Login = "/api/auths/login";
}
