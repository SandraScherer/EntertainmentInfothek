using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification_SupportedVideoResolution".</summary>
public sealed class TechnicalSpecificationSupportedVideoResolutionConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedVideoResolution>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedVideoResolution> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification_SupportedVideoResolution");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationID).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.VideoResolutionID).HasColumnName("VideoResolutionID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedVideoResolution.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationSupportedVideoResolutionByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedVideoResolution.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification)
            .WithMany(x => x.TechnicalSpecificationSupportedVideoResolutionByTechnicalSpecificationID)
            .HasForeignKey(x => x.TechnicalSpecificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedVideoResolution.VideoResolutionID -> VideoResolution.ID
        builder.HasOne(x => x.VideoResolution)
            .WithMany(x => x.TechnicalSpecificationSupportedVideoResolutionByVideoResolutionID)
            .HasForeignKey(x => x.VideoResolutionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
