using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class LinkClassMap : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(link => link.Id)
            .HasName("PK_____Link");

        builder.Property(link => link.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(link => link.User)
            .WithMany(user => user.Links)
            .HasForeignKey("user_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_link");

        builder.Property(link => link.Url)
            .HasColumnName("url")
            .HasMaxLength(255);

        builder.Property(link => link.Description)
            .HasColumnName("description")
            .HasMaxLength(30);
    }
}
