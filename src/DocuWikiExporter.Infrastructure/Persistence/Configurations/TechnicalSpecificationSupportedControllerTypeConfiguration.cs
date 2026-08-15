using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification_SupportedControllerType".</summary>
public sealed class TechnicalSpecificationSupportedControllerTypeConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedControllerType>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedControllerType> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification_SupportedControllerType");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationID).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.ControllerTypeID).HasColumnName("ControllerTypeID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedControllerType.ControllerTypeID -> ControllerType.ID
        builder.HasOne(x => x.ControllerType)
            .WithMany(x => x.TechnicalSpecificationSupportedControllerTypeByControllerTypeID)
            .HasForeignKey(x => x.ControllerTypeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedControllerType.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationSupportedControllerTypeByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedControllerType.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification)
            .WithMany(x => x.TechnicalSpecificationSupportedControllerTypeByTechnicalSpecificationID)
            .HasForeignKey(x => x.TechnicalSpecificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
