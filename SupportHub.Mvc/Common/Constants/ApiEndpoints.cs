namespace SupportHub.Mvc.Common.Constants;

public static class ApiEndpoints
{
    public const string GetTickets = "/api/tickets";
    public const string GetTicketDetail = "/api/tickets/";
    public const string CreateTicket = "/api/tickets";
    public static string GetTicketsQuery(
        int page = 1,
        int pageSize = 10,
        string? status = null,
        string? search = null,
        string? priority = null,
        string? sortBy = "createdDate",
        string? sortDirection = "desc")
    {
        var queryParameters = new List<string>
        {
            $"page={page}",
            $"pageSize={pageSize}"
        };

        AddQueryParameter(queryParameters, "status", status);
        AddQueryParameter(queryParameters, "search", search);
        AddQueryParameter(queryParameters, "priority", priority);
        AddQueryParameter(queryParameters, "sortBy", sortBy);
        AddQueryParameter(queryParameters, "sortDirection", sortDirection);

        return $"{GetTickets}?{string.Join("&", queryParameters)}";
    }

    public static string AddTicketComment(Guid ticketId) => $"/api/tickets/{ticketId}/comments";
    public const string Login = "/api/auths/login";

    private static void AddQueryParameter(List<string> queryParameters, string name, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return;

        queryParameters.Add($"{name}={Uri.EscapeDataString(value)}");
    }
}
