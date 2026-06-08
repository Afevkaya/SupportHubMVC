using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Controllers;

[Authorize]
public class TicketsController(ITicketService ticketService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {        
        var tickets = await ticketService.GetTicketsAsync();
        return View(tickets);
    }
}