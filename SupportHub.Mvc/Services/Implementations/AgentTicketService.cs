using SupportHub.Mvc.Common.Constants;
using SupportHub.Mvc.Models.Responses.Tickets;
using SupportHub.Mvc.Models.ViewModels.AgentTickets;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class AgentTicketService(IApiClient apiClient) : IAgentTicketService
{
    public async Task<AgentTicketDashboardViewModel> GetDashboardAsync()
    {
        var assignedTickets = await GetTicketListAsync(ApiEndpoints.GetTicketsQuery(pageSize: 5));
        var openTickets = await GetTicketListAsync(ApiEndpoints.GetTicketsQuery(pageSize: 1, status: "Open"));
        var inProgressTickets = await GetTicketListAsync(ApiEndpoints.GetTicketsQuery(pageSize: 1, status: "InProgress"));
        var waitingTickets = await GetTicketListAsync(ApiEndpoints.GetTicketsQuery(pageSize: 1, status: "WaitingForResponse"));

        return new AgentTicketDashboardViewModel(
            AssignedTicketsCount: assignedTickets.TotalCount,
            OpenTicketsCount: openTickets.TotalCount,
            InProgressTicketsCount: inProgressTickets.TotalCount,
            WaitingTicketsCount: waitingTickets.TotalCount,
            RecentTickets: MapRecentTickets(assignedTickets));
    }

    public async Task<AgentTicketListViewModel> GetAssignedTicketsAsync(int page = 1, int pageSize = 10)
    {
        var response = await GetTicketListAsync(ApiEndpoints.GetTicketsQuery(
            page: page,
            pageSize: pageSize));

        return MapTicketList(response);
    }

    public async Task<AgentTicketListViewModel> GetOpenTicketsAsync(int page = 1, int pageSize = 10)
    {
        var response = await GetTicketListAsync(ApiEndpoints.GetTicketsQuery(
            page: page,
            pageSize: pageSize,
            status: "Open"));

        return MapTicketList(response);
    }

    private async Task<ResponseTicketList> GetTicketListAsync(string endpoint)
    {
        return await apiClient.GetAsync<ResponseTicketList>(endpoint)
               ?? new ResponseTicketList([], 0, 0, 0, 0);
    }

    private static IReadOnlyList<AgentTicketListItemViewModel> MapRecentTickets(ResponseTicketList response)
    {
        return response.Items
            .OrderByDescending(ticket => ticket.UpdatedDate ?? ticket.CreatedDate)
            .Take(5)
            .Select(MapTicketItem)
            .ToList();
    }

    private static IReadOnlyList<AgentTicketListItemViewModel> MapTicketItems(ResponseTicketList response)
    {
        return response.Items
            .Select(MapTicketItem)
            .ToList();
    }

    private static AgentTicketListViewModel MapTicketList(ResponseTicketList response)
    {
        return new AgentTicketListViewModel(
            Items: MapTicketItems(response),
            Page: response.Page,
            PageSize: response.PageSize,
            TotalCount: response.TotalCount,
            TotalPages: response.TotalPages);
    }

    private static AgentTicketListItemViewModel MapTicketItem(ResponseTicketListItem ticket)
    {
        return new AgentTicketListItemViewModel(
            Id: ticket.Id,
            Title: ticket.Title,
            Status: ticket.Status,
            Priority: ticket.Priority,
            CreatedDate: ticket.CreatedDate,
            UpdatedDate: ticket.UpdatedDate);
    }
}
