using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportHub.Mvc.Models.ViewModels.Tickets;
using SupportHub.Mvc.Models.ViewModels.Tickets.TicketComments;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Controllers;

[Authorize]
public class TicketsController(ITicketService ticketService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {        
        var tickets = await ticketService.GetMyTicketsAsync();
        return View(tickets);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Details(Guid id)
    {
        var ticket = await ticketService.GetTicketDetailAsync(id);
        if (ticket == null)
            return NotFound();
        return View(ticket);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View(new CreateTicketViewModel());
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateTicketViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        var result = await ticketService.CreateTicketAsync(model);
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("{id:guid}/comments")]
    public async Task<IActionResult> AddComment(Guid id, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return BadRequest("Mesaj boş olamaz");
        
        var ticketComment = new AddTicketCommentViewModel(TicketId: id, Message: message);
        
        var result = await ticketService.AddCommentAsync(ticketComment);
        if (result is null) return NotFound("Ticket not found.");
        return RedirectToAction(nameof(Details), new { id });
    }

}
