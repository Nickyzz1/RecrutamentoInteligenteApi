using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class StageClassMap : IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
        builder.HasKey(stage => stage.Id)
            .HasName("PK_____Stage");

        builder.Property(stage => stage.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(stage => stage.Vacancy)
            .WithMany(vacancy => vacancy.Stages)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_stage");

        builder.Property(stage => stage.Description)
            .HasColumnName("description")
            .HasMaxLength(50);

        builder.Property(stage => stage.StartDate)
            .HasColumnName("start_date");

        builder.Property(stage => stage.EndDate)
            .HasColumnName("end_date");
    }
}
