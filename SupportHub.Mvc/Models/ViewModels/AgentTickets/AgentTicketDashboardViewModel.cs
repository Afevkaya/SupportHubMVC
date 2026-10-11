namespace SupportHub.Mvc.Models.ViewModels.AgentTickets;

public record AgentTicketDashboardViewModel(
    int AssignedTicketsCount, 
    int OpenTicketsCount,
    int InProgressTicketsCount,
    int WaitingTicketsCount,
    IReadOnlyList<AgentTicketListItemViewModel> RecentTickets);