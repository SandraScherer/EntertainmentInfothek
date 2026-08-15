using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification_RequiredAdditionalHardware".</summary>
public sealed class TechnicalSpecificationRequiredAdditionalHardwareConfiguration : IEntityTypeConfiguration<TechnicalSpecificationRequiredAdditionalHardware>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationRequiredAdditionalHardware> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification_RequiredAdditionalHardware");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationID).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.HardwareID).HasColumnName("HardwareID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_RequiredAdditionalHardware.HardwareID -> Hardware.ID
        builder.HasOne(x => x.Hardware)
            .WithMany(x => x.TechnicalSpecificationRequiredAdditionalHardwareByHardwareID)
            .HasForeignKey(x => x.HardwareID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_RequiredAdditionalHardware.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationRequiredAdditionalHardwareByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_RequiredAdditionalHardware.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification)
            .WithMany(x => x.TechnicalSpecificationRequiredAdditionalHardwareByTechnicalSpecificationID)
            .HasForeignKey(x => x.TechnicalSpecificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
