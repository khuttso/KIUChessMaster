using KIUChessMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KIUChessMaster.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}