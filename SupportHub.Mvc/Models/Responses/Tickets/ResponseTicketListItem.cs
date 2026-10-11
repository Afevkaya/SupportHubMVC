namespace SupportHub.Mvc.Models.Responses.Tickets;

public record ResponseTicketListItem(
    Guid Id,
    string Title,
    string Status,
    string Priority,
    DateTime CreatedDate,
    DateTime? UpdatedDate);
