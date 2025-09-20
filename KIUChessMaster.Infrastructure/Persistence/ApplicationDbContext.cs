using KIUChessMaster.Application.Common.Interfaces;
using KIUChessMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KIUChessMaster.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }  = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}