using KIUChessMaster.Application.Common.Interfaces;
using KIUChessMaster.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KIUChessMaster.Application.Features.Players.Command;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Guid?>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreatePlayerCommandHandler> _logger;

    public CreatePlayerCommandHandler(IApplicationDbContext context, ILogger<CreatePlayerCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<Guid?> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        Guid playerId = request.Id ?? Guid.NewGuid();

        var player = new Player()
        {
            Id = playerId,
            UserId = request.UserId ?? Guid.Empty,
            Username = request.Username ?? "Anonymous",
            ChessLevel = request.ChessLevel,
            KiuRating = request.KiuRating ?? 0,
            FideRating = request.FideRating ?? 0,
            KiuTitle = request.KiuTitle ?? KiuTitle.NoTitle,
            FideTitle = request.FideTitle ?? FideTitle.NoTitle,
        };

        try
        {
            _logger.LogInformation(
                $"Creating player with Id = {playerId} and  Username = {request.Username} for user with Id = {request.Id}");

            await _context.Players.AddAsync(player, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Player with Id = {playerId} created");

            return playerId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error creating player with Id = {playerId}");
            throw;
        }
    }
}