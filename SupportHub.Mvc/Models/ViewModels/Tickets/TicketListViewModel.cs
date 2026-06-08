namespace SupportHub.Mvc.Models.ViewModels.Tickets;

public record TicketListViewModel(List<TicketListItemViewModel> Items, int Page, int PageSize, int TotalCount, int TotalPages);