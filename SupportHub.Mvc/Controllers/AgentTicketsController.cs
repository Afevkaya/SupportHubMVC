using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportHub.Mvc.Services.Abstractions;

namespace SupportHub.Mvc.Controllers;

[Authorize(Roles = "SupportAgent,Admin")]
[Route("agent/tickets")]
public class AgentTicketsController(IAgentTicketService agentTicketService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        var model = await agentTicketService.GetDashboardAsync();
        return View(model);
    }

    [HttpGet("assigned")]
    public async Task<IActionResult> AssignedTickets(int page = 1, int pageSize = 10)
    {
        var model = await agentTicketService.GetAssignedTicketsAsync(page, pageSize);
        return View(model);
    }

    [HttpGet("open")]
    public async Task<IActionResult> OpenTickets(int page = 1, int pageSize = 10)
    {
        var model = await agentTicketService.GetOpenTicketsAsync(page, pageSize);
        return View(model);
    }
}
