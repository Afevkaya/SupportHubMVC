namespace SupportHub.Mvc.Models.ViewModels.AgentTickets;

public record AgentTicketListItemViewModel(
    Guid Id,
    string Title,
    string Status,
    string Priority,
    DateTime CreatedDate,
    DateTime? UpdatedDate);