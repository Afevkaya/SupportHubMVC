using SupportHub.Mvc.Models.Responses.Tickets.TicketComments;

namespace SupportHub.Mvc.Models.Responses.Tickets;

public record ResponseTicketDetail(
    Guid Id, 
    string Title, 
    string Description, 
    string Status, 
    string Priority, 
    DateTime CreatedDate, 
    DateTime? UpdatedDate, 
    List<ResponseTicketComment> Comments);