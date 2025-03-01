using ManagementSystem.Application.CQRS.Categories.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentSystem.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task <IActionResult> Create ([FromBody] CreateCategoryRequest request)
    {
        return Ok(await _sender.Send(request));
    }

    [HttpGet]
    public async  Task<IActionResult> GetAll([FromQuery] GetAllCategoryRequest request)
    {
        return Ok(await _sender.Send(request));
    }
}