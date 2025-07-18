using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class EducationClassMap : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.HasKey(education => education.Id)
            .HasName("PK_____Education");

        builder.Property(education => education.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(education => education.User)
            .WithMany(user => user.Educations)
            .HasForeignKey("user_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_education");

        builder.Property(education => education.Institution)
            .HasColumnName("institution")
            .HasMaxLength(80);

        builder.Property(education => education.Course)
            .HasColumnName("course")
            .HasMaxLength(80);

        builder.Property(education => education.Status)
            .HasColumnName("status");

        builder.Property(education => education.StartDate)
            .HasColumnName("start_date");

        builder.Property(education => education.EndDate)
            .HasColumnName("end_date");

        builder.Property(education => education.Type)
            .HasColumnName("type");
    }
}
