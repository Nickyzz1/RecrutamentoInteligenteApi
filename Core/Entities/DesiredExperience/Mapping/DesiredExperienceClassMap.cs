using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class DesiredExperienceClassMap : IEntityTypeConfiguration<DesiredExperience>
{
    public void Configure(EntityTypeBuilder<DesiredExperience> builder)
    {
        builder.HasKey(desired_experience => desired_experience.Id)
            .HasName("PK_____DesiredExperience");

        builder.Property(desired_experience => desired_experience.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(desired_experience => desired_experience.Vacancy)
            .WithMany(vacancy => vacancy.DesiredExperiences)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_desired_experience");

        builder.Property(desired_experience => desired_experience.Name)
            .HasColumnName("name")
            .HasMaxLength(80);

        builder.Property(desired_experience => desired_experience.Time)
            .HasColumnName("time");

        builder.Property(desired_experience => desired_experience.Required)
            .HasColumnName("required");
    }
}
