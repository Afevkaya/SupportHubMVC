using System.ComponentModel.DataAnnotations;

namespace SupportHub.Mvc.Common.Enums;

public enum TicketPriorityType
{
    [Display(Name = "Düşük")]
    Low = 0,
    [Display(Name = "Orta")]
    Medium = 1,
    [Display(Name = "Yüksek")]
    High = 2,
    [Display(Name = "Kritik")]
    Critical = 3
}