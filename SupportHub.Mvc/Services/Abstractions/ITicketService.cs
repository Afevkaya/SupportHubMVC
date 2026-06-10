using SupportHub.Mvc.Models.Responses.Tickets;
using SupportHub.Mvc.Models.ViewModels.Tickets;
using SupportHub.Mvc.Models.ViewModels.Tickets.TicketComments;

namespace SupportHub.Mvc.Services.Abstractions;

public interface ITicketService
{
    Task<List<TicketListItemViewModel>> GetMyTicketsAsync();
    Task<TicketDetailViewModel?> GetTicketDetailAsync(Guid id);
    Task<ResponseCreateTicket> CreateTicketAsync(CreateTicketViewModel model);
    Task<AddTicketCommentViewModel?> AddCommentAsync(AddTicketCommentViewModel model);
}