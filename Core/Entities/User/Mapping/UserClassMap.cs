using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class UserClassMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.HasKey(user => user.Id)
            .HasName("PK_____User");

        builder.Property(user => user.IsActive)
            .HasColumnName("is_active");

        builder.ToTable("tb_user");

        builder.Property(user => user.Name)
            .HasColumnName("name")
            .HasMaxLength(50);

        builder.Property(user => user.Password)
            .HasColumnName("password")
            .HasMaxLength(100);

        builder.Property(user => user.Email)
            .HasColumnName("email")
            .HasMaxLength(100);

        builder.Property(user => user.Phone)
            .HasColumnName("phone")
            .HasMaxLength(20);

        builder.Property(user => user.Address)
            .HasColumnName("address")
            .HasMaxLength(255);

        builder.Property(user => user.Bio)
            .HasColumnName("bio");

        builder.Property(user => user.Admin)
            .HasColumnName("admin");
    }
}
