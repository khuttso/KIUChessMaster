using KIUChessMaster.Domain.Enums;
using MediatR;

namespace KIUChessMaster.Application.Features.Users.Command;
    
public record CreateUserCommand(Guid? UserId, string? Firstname, string? Lastname, string? Email, DateTime? Dob, GenderType? Gender) : IRequest<Guid>;   