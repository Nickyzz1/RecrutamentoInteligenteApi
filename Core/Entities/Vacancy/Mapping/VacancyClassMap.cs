using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class VacancyClassMap : IEntityTypeConfiguration<Vacancy>
{
    public void Configure(EntityTypeBuilder<Vacancy> builder)
    {
        builder.HasKey(vacancy => vacancy.Id)
            .HasName("PK_____Vacancy");

        builder.Property(vacancy => vacancy.IsActive)
            .HasColumnName("is_active");

        builder.ToTable("tb_vacancy");

        builder.Property(vacancy => vacancy.Title)
            .HasColumnName("title")
            .HasMaxLength(100);

        builder.Property(vacancy => vacancy.Description)
            .HasColumnName("description");

        builder.Property(vacancy => vacancy.WorkDays)
            .HasColumnName("work_days");

        builder.Property(vacancy => vacancy.WorkStart)
            .HasColumnName("work_start");

        builder.Property(vacancy => vacancy.WorkEnd)
            .HasColumnName("work_end");

        builder.Property(vacancy => vacancy.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(vacancy => vacancy.CanApply)
            .HasColumnName("can_apply");
    }
}
