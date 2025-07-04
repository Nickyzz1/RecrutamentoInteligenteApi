using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class DesiredLanguageClassMap : IEntityTypeConfiguration<DesiredLanguage>
{
    public void Configure(EntityTypeBuilder<DesiredLanguage> builder)
    {
        builder.HasKey(desired_language => desired_language.Id)
            .HasName("PK_____DesiredLanguage");

        builder.Property(desired_language => desired_language.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(desired_language => desired_language.Vacancy)
            .WithMany(vacancy => vacancy.DesiredLanguages)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_desired_language");

        builder.Property(desired_language => desired_language.Name)
            .HasColumnName("name")
            .HasMaxLength(20);

        builder.Property(desired_language => desired_language.Level)
            .HasColumnName("level");

        builder.Property(desired_language => desired_language.Required)
            .HasColumnName("required");
    }
}
