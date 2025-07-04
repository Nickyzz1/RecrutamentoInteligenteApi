using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class LanguageClassMap : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(language => language.Id)
            .HasName("PK_____Language");

        builder.Property(language => language.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(language => language.User)
            .WithMany(user => user.Languages)
            .HasForeignKey("user_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_language");

        builder.Property(language => language.Name)
            .HasColumnName("name")
            .HasMaxLength(20);

        builder.Property(language => language.Level)
            .HasColumnName("level");
    }
}
