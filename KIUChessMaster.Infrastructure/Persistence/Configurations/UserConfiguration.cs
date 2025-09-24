using KIUChessMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KIUChessMaster.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Primary Key
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        // Firstname
        builder.Property(u => u.Firstname)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(50);

        // Lastname
        builder.Property(u => u.Lastname)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(50);

        // Email
        builder.Property(u => u.Email)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(100);

        // Gender (enum)
        builder.Property(u => u.Gender)
            .HasConversion<int>() // store enum as int
            .IsRequired();

        // Date of Birth
        builder.Property(u => u.DoB)
            .HasColumnType("datetime2")
            .IsRequired();
    }
}