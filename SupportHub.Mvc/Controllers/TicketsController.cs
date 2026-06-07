using Microsoft.AspNetCore.Mvc;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Controllers;

public class TicketsController(ITicketService ticketService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {        
        var tickets = await ticketService.GetTicketsAsync();
        return View(tickets);
    }
}