namespace SupportHub.Mvc.Models.Requests.Tickets;

public record RequestAddTicketComment(Guid TicketId, string Message);