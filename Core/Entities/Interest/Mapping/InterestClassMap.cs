using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class InterestClassMap : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        builder.HasKey(interest => interest.Id)
            .HasName("PK_____Interest");

        builder.Property(interest => interest.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(interest => interest.User)
            .WithMany(user => user.Interests)
            .HasForeignKey("user_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_interest");

        builder.Property(interest => interest.Name)
            .HasColumnName("name")
            .HasMaxLength(50);
    }
}
