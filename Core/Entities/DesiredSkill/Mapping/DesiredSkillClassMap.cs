using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class DesiredSkillClassMap : IEntityTypeConfiguration<DesiredSkill>
{
    public void Configure(EntityTypeBuilder<DesiredSkill> builder)
    {
        builder.HasKey(desired_skill => desired_skill.Id)
            .HasName("PK_____DesiredSkill");

        builder.Property(desired_skill => desired_skill.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(desired_skill => desired_skill.Vacancy)
            .WithMany(vacancy => vacancy.DesiredSkills)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_desired_skill");

        builder.Property(desired_skill => desired_skill.Name)
            .HasColumnName("name")
            .HasMaxLength(25);

        builder.Property(desired_skill => desired_skill.Required)
            .HasColumnName("required");
    }
}
