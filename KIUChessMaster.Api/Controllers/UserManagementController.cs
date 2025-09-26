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
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
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

    [HttpPost("EditUser")]
    public async Task<IActionResult> EditUser()
    {
        throw new NotImplementedException(nameof(EditUser));
    }


    [HttpPost("DeleteUser")]
    public async Task<IActionResult> DeleteUser()
    {
        throw new NotImplementedException(nameof(DeleteUser));
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        throw new NotImplementedException(nameof(GetUsers));
    }

    [HttpGet("GetUser/{id}")]
    public async Task<IActionResult> GetUser(int id)
    { 
        throw new NotImplementedException(nameof(GetUser));
    }
    
    

} 