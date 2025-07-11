using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class ExperienceClassMap : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.HasKey(experience => experience.Id)
            .HasName("PK_____Experience");

        builder.Property(experience => experience.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(experience => experience.User)
            .WithMany(user => user.Experiences)
            .HasForeignKey("user_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_experience");

        builder.Property(experience => experience.Company)
            .HasColumnName("company")
            .HasMaxLength(80);

        builder.Property(experience => experience.Role)
            .HasColumnName("role")
            .HasMaxLength(80);

        builder.Property(experience => experience.Description)
            .HasColumnName("description");

        builder.Property(experience => experience.Location)
            .HasColumnName("location")
            .HasMaxLength(30);

        builder.Property(experience => experience.StartDate)
            .HasColumnName("start_date");

        builder.Property(experience => experience.EndDate)
            .HasColumnName("end_date");
    }
}
