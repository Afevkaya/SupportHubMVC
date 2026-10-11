namespace SupportHub.Mvc.Models.ViewModels.AgentTickets;

public record AgentTicketListViewModel(
    IReadOnlyList<AgentTicketListItemViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages);
