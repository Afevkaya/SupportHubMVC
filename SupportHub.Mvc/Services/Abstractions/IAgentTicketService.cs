using SupportHub.Mvc.Models.ViewModels.AgentTickets;

namespace SupportHub.Mvc.Services.Abstractions;

public interface IAgentTicketService
{
    Task<AgentTicketDashboardViewModel> GetDashboardAsync();
    Task<AgentTicketListViewModel> GetAssignedTicketsAsync(int page = 1, int pageSize = 10);
    Task<AgentTicketListViewModel> GetOpenTicketsAsync(int page = 1, int pageSize = 10);
}
