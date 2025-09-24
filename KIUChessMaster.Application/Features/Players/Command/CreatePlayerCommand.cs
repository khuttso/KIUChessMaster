using KIUChessMaster.Domain.Entities;
using KIUChessMaster.Domain.Enums;
using MediatR;

namespace KIUChessMaster.Application.Features.Players.Command;

public record CreatePlayerCommand(Guid? Id, Guid? UserId, string? Username, ChessLevel? ChessLevel, FideTitle? FideTitle, KiuTitle? KiuTitle, decimal? KiuRating, decimal? FideRating, string? FideProfileLink)
    : IRequest<Guid?>;
