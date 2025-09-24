using KIUChessMaster.Application.Features.Players.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KIUChessMaster.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayersController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpPost("CreatePlayer")]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerCommand command,
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