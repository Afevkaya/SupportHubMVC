using SupportHub.Mvc.Models.Responses.Auth;

namespace SupportHub.Mvc.Models.Responses.Tickets;

public record ResponseAddTicketComment(
    Guid Id, 
    Guid TicketId, 
    string Message, 
    DateTime CreatedDate,
    ResponseGetAuth? Author);
