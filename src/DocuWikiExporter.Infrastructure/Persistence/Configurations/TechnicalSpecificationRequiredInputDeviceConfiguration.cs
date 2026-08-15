using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification_RequiredInputDevice".</summary>
public sealed class TechnicalSpecificationRequiredInputDeviceConfiguration : IEntityTypeConfiguration<TechnicalSpecificationRequiredInputDevice>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationRequiredInputDevice> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification_RequiredInputDevice");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationID).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.InputDeviceID).HasColumnName("InputDeviceID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_RequiredInputDevice.InputDeviceID -> InputDevice.ID
        builder.HasOne(x => x.InputDevice)
            .WithMany(x => x.TechnicalSpecificationRequiredInputDeviceByInputDeviceID)
            .HasForeignKey(x => x.InputDeviceID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_RequiredInputDevice.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationRequiredInputDeviceByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_RequiredInputDevice.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification)
            .WithMany(x => x.TechnicalSpecificationRequiredInputDeviceByTechnicalSpecificationID)
            .HasForeignKey(x => x.TechnicalSpecificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
