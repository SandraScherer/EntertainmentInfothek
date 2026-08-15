using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification_SupportedInputDeviceFeature".</summary>
public sealed class TechnicalSpecificationSupportedInputDeviceFeatureConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedInputDeviceFeature>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedInputDeviceFeature> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification_SupportedInputDeviceFeature");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationID).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.InputDeviceFeatureID).HasColumnName("InputDeviceFeatureID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedInputDeviceFeature.InputDeviceFeatureID -> InputDeviceFeature.ID
        builder.HasOne(x => x.InputDeviceFeature)
            .WithMany(x => x.TechnicalSpecificationSupportedInputDeviceFeatureByInputDeviceFeatureID)
            .HasForeignKey(x => x.InputDeviceFeatureID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedInputDeviceFeature.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationSupportedInputDeviceFeatureByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedInputDeviceFeature.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification)
            .WithMany(x => x.TechnicalSpecificationSupportedInputDeviceFeatureByTechnicalSpecificationID)
            .HasForeignKey(x => x.TechnicalSpecificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
