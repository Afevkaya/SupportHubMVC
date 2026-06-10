using SupportHub.Mvc.Models.Responses.Auth;

namespace SupportHub.Mvc.Models.Responses.Tickets;

public record ResponseCreateTicket(
    Guid Id, 
    string Title, 
    string Description, 
    string Status, 
    string Priority, 
    DateTime CreatedDate,
    ResponseGetAuth? Author = null);