using KIUChessMaster.Application.Features.Users.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KIUChessMaster.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserManagementController : ControllerBase
{
    public readonly IMediator _mediator;

    public UserManagementController(IMediator mediator)
    {
        _mediator = mediator ??  throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    } 
}