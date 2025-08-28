using DevelopmentSucks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevelopmentSucks.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.HasKey(x => x.Id);

        b.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);

        b.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);

        b.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        b.HasIndex(x => x.Email).IsUnique();
        b.HasIndex(x => x.Username).IsUnique();
    }
}
