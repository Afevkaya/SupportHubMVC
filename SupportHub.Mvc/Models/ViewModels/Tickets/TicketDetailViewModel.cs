using SupportHub.Mvc.Models.ViewModels.Tickets.TicketComments;

namespace SupportHub.Mvc.Models.ViewModels.Tickets;

public record TicketDetailViewModel(
    Guid Id, 
    string Title, 
    string Description, 
    string Status, 
    string Priority, 
    DateTime CreatedDate, 
    DateTime? UpdatedDate, 
    List<TicketCommentListViewModel> Comments,
    AddTicketCommentViewModel AddComment);