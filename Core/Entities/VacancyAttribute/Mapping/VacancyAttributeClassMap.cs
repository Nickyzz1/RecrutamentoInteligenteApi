using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class VacancyAttributeClassMap : IEntityTypeConfiguration<VacancyAttribute>
{
    public void Configure(EntityTypeBuilder<VacancyAttribute> builder)
    {
        builder.HasKey(vacancy_attribute => vacancy_attribute.Id)
            .HasName("PK_____VacancyAttribute");

        builder.Property(vacancy_attribute => vacancy_attribute.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(vacancy_attribute => vacancy_attribute.Vacancy)
            .WithMany(vacancy => vacancy.Attributes)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_vacancy_attribute");

        builder.Property(vacancy_attribute => vacancy_attribute.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(vacancy_attribute => vacancy_attribute.Type)
            .HasColumnName("type");
    }
}
