using Microsoft.AspNetCore.Mvc.Rendering;
using SupportHub.Mvc.Common.Enums;
using SupportHub.Mvc.Common.Helpers;

namespace SupportHub.Mvc.Models.ViewModels.Tickets;

public class CreateTicketViewModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriorityType? Priority { get; set; }
    public List<SelectListItem> PriorityOptions { get; set; } = EnumSelectListHelper.Create<TicketPriorityType>();
}
