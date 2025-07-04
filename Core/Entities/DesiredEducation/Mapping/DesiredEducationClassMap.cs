using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class DesiredEducationClassMap : IEntityTypeConfiguration<DesiredEducation>
{
    public void Configure(EntityTypeBuilder<DesiredEducation> builder)
    {
        builder.HasKey(desired_education => desired_education.Id)
            .HasName("PK_____DesiredEducation");

        builder.Property(desired_education => desired_education.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(desired_education => desired_education.Vacancy)
            .WithMany(vacancy => vacancy.DesiredEducations)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_desired_education");

        builder.Property(desired_education => desired_education.Name)
            .HasColumnName("name")
            .HasMaxLength(80);

        builder.Property(desired_education => desired_education.Type)
            .HasColumnName("type");

        builder.Property(desired_education => desired_education.Required)
            .HasColumnName("required");
    }
}
