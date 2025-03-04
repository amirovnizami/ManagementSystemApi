using ManagementSystem.Application.CQRS.Users.Handlers.Commands;
using ManagementSystem.Application.CQRS.Users.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetByEmailAsync([FromQuery] string email)
    {
        var request = new GetByEmail.Query() { Email = email };
        return Ok(await _mediator.Send(request));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int Id)
    {
        var request = new GetUserById.Query { Id= Id };
        return Ok(await _mediator.Send(request));
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var request = new Delete.Command() { Id = id };
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] Register.RegisterCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Update.Command request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Login.LoginRequest request)
    {
        return Ok(await _mediator.Send(request));
    }
}