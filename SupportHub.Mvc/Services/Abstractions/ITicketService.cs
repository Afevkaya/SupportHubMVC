using SupportHub.Mvc.Models.ViewModels.Tickets;

namespace SupportHub.Mvc.Services.Abstractions;

public interface ITicketService
{
    Task<List<TicketListItemViewModel>> GetTicketsAsync();
}