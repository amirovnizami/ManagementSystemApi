using ManagmentSystem.Application.CQRS.Users.Handlers.Commands;
using ManagmentSystem.Application.CQRS.Users.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentSystem.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetByEmailAsync([FromQuery]string email)
    {
        var request = new GetByEmail.Query() { Email = email };
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var request = new Delete.Command() {Id = id};
        return Ok(await _mediator.Send(request));
    }
 
}