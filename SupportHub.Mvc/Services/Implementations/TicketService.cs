using SupportHub.Mvc.Common.Constants;
using SupportHub.Mvc.Models.ViewModels.Tickets;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class TicketService(IApiClient apiClient) : ITicketService
{
    public async Task<List<TicketListItemViewModel>> GetTicketsAsync()
    {
        var result = await apiClient.GetAsync<TicketListViewModel>(ApiEndpoints.GetTickets);
        if (result == null || result.Items.Count == 0)
            return [];
        
        return result.Items;
    }
}