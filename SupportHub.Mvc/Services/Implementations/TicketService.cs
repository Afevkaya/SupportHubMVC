using SupportHub.Mvc.Common.Constants;
using SupportHub.Mvc.Models.Requests.Tickets;
using SupportHub.Mvc.Models.Responses.Tickets;
using SupportHub.Mvc.Models.ViewModels.Tickets;
using SupportHub.Mvc.Models.ViewModels.Tickets.TicketComments;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Services.Implementations;

public class TicketService(IApiClient apiClient) : ITicketService
{
    public async Task<List<TicketListItemViewModel>> GetMyTicketsAsync()
    {
        var defaultQuery = "?page=1&pageSize=10&&search=ticket&priority=0&sortBy=createdDate&sortDirection=asc";
        var result = await apiClient.GetAsync<TicketListViewModel>(ApiEndpoints.GetTickets + defaultQuery);
        if (result == null || result.Items.Count == 0)
            return [];
        
        return result.Items;
    }
    public async Task<TicketDetailViewModel?> GetTicketDetailAsync(Guid id)
    {
        var response = await apiClient.GetAsync<ResponseTicketDetail?>(ApiEndpoints.GetTicketDetail + id);
        if (response is null)
            return null;
        return new TicketDetailViewModel(
            Id: response.Id,
            Title: response.Title,
            Description: response.Description,
            Status: response.Status,
            Priority: response.Priority,
            CreatedDate: response.CreatedDate,
            UpdatedDate: response.UpdatedDate,
            Comments: response.Comments.Select(c => new TicketCommentListViewModel(AuthorName: c.AuthorName, Message: c.Message)).ToList(),
            AddComment: new AddTicketCommentViewModel(
                TicketId: response.Id,
                Message: string.Empty));
    }

    public async Task<ResponseCreateTicket> CreateTicketAsync(CreateTicketViewModel model)
    {
        var request = new RequestCreateTicket(
            Title: model.Title,
            Description: model.Description,
            Priority: model.Priority);

        return await apiClient.PostAsync<RequestCreateTicket, ResponseCreateTicket>(
            ApiEndpoints.CreateTicket,
            request);
    }

    public async Task<AddTicketCommentViewModel?> AddCommentAsync(AddTicketCommentViewModel model)
    {
        var request = new RequestAddTicketComment(model.TicketId, model.Message);
        
        var response = await apiClient.PostAsync<RequestAddTicketComment, ResponseAddTicketComment?>(
            ApiEndpoints.AddTicketComment(model.TicketId),
            request);

        if (response is null)
            return null;

        return new AddTicketCommentViewModel(
            TicketId: response.TicketId,
            Message: response.Message);
    }
}
