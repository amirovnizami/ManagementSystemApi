using ManagementSystem.Application.CQRS.Customers.Commands.Request;
using ManagementSystem.Application.CQRS.Customers.Queries.Request;
using ManagementSystem.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentSystem.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task<IActionResult>Create([FromBody] CreateCustomerRequest customer)
    {
        return Ok(await _sender.Send(customer));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerRequest request)
    {
        return Ok(await _sender.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request)
    {
        return Ok(await _sender.Send(request));
    }
}