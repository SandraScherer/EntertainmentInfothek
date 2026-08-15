using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "InputDeviceFeature".</summary>
public sealed class InputDeviceFeatureConfiguration : IEntityTypeConfiguration<InputDeviceFeature>
{
    public void Configure(EntityTypeBuilder<InputDeviceFeature> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("InputDeviceFeature");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: InputDeviceFeature.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.InputDeviceFeatureByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
