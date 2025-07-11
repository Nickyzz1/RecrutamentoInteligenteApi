using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class ApplicationClassMap : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(application => application.Id)
            .HasName("PK_____Application");

        builder.Property(application => application.IsActive)
            .HasColumnName("is_active");

        builder.HasOne(application => application.Candidate)
            .WithMany(user => user.Applications)
            .HasForeignKey("candidate_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.HasOne(application => application.Vacancy)
            .WithMany(vacancy => vacancy.Applications)
            .HasForeignKey("vacancy_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.HasOne(application => application.DismissalStage)
            .WithMany()
            .HasForeignKey("dismissal_stage_id")
            .HasPrincipalKey(obj => obj.Id);

        builder.ToTable("tb_application");

        builder.Property(application => application.Status)
            .HasColumnName("status");

        builder.Property(application => application.Note)
            .HasColumnName("note");
        
        builder.Property(application => application.AppliedAt)
            .HasColumnName("applied_at");
    }
}
