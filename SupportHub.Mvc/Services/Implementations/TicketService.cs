using SupportHub.Mvc.Common.Constants;
using SupportHub.Mvc.Models.ViewModels.Tickets;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class TicketService(IApiClient apiClient) : ITicketService
{
    public async Task<List<TicketListItemViewModel>> GetTicketsAsync()
    {
        var result = await apiClient.GetAsync<List<TicketListItemViewModel>>(ApiEndpoints.GetTickets);
        return result ?? [];
    }
}