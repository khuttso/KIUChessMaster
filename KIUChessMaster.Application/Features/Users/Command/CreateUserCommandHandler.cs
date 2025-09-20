using KIUChessMaster.Application.Common.Interfaces;
using KIUChessMaster.Domain.Entities;
using KIUChessMaster.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KIUChessMaster.Application.Features.Users.Command;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(IApplicationDbContext context, ILogger<CreateUserCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Guid userId = request.UserId ?? Guid.NewGuid();

        var user = new User
        {
            UserId = userId,
            Firstname = request.Firstname!,
            Lastname = request.Lastname!,
            Email = request.Email!,
            DoB = request.Dob ?? DateTime.MinValue,
            Gender = request.Gender ?? GenderType.Other,
        };

        try
        {
            _logger.LogInformation($"Creating new user {user.Firstname} {user.Lastname} with email {user.Email}");

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"User {user.Firstname} {user.Lastname} has been created");

            return user.UserId;
        }
        catch
        {
            _logger.LogError($"User {user.Firstname} {user.Lastname} with Id = {user.UserId} could not be created");
            throw;
        }
    }
}