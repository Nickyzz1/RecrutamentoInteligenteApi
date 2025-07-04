using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class SkillClassMap : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(skill => skill.Id)
            .HasName("PK_____Skill");

        builder.Property(skill => skill.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(skill => skill.User)
            .WithMany(user => user.Skills)
            .HasForeignKey("user_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_skill");

        builder.Property(skill => skill.Name)
            .HasColumnName("name")
            .HasMaxLength(25);
    }
}
