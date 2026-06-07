namespace SupportHub.Mvc.Models.ViewModels.Tickets;

public record TicketListItemViewModel(
    Guid Id,
    string Title,
    string Status,
    string Priority,
    DateTime CreatedDate);