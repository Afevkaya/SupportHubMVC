using SupportHub.Mvc.Common.Enums;

namespace SupportHub.Mvc.Models.Requests.Tickets;

public record RequestCreateTicket(string Title, string Description, TicketPriorityType? Priority);