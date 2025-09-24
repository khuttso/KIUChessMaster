using KIUChessMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KIUChessMaster.Infrastructure.Persistence.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        // Foreign Key (UserId)
        builder.Property(p => p.UserId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        // Username
        builder.Property(p => p.Username)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(100);

        // Enums (stored as int by default)
        builder.Property(p => p.FideTitle)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(p => p.KiuTitle)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(p => p.ChessLevel)
            .HasConversion<int?>(); // nullable enum

        // Ratings
        builder.Property(p => p.KiuRating)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(p => p.FideRating)
            .HasColumnType("decimal(5,2)");

        // Optional Link
        builder.Property(p => p.FideProfileLink)
            .HasColumnType("nvarchar")
            .HasMaxLength(250);
    }
}