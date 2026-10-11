namespace SupportHub.Mvc.Models.Responses.Tickets;

public record ResponseTicketList(
    List<ResponseTicketListItem> Items,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages);
