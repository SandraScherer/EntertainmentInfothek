using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Country".</summary>
public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Country");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalShortName).HasColumnName("OriginalShortName");
        builder.Property(x => x.OriginalFullName).HasColumnName("OriginalFullName");
        builder.Property(x => x.EnglishShortName).HasColumnName("EnglishShortName");
        builder.Property(x => x.EnglishFullName).HasColumnName("EnglishFullName");
        builder.Property(x => x.GermanShortName).HasColumnName("GermanShortName");
        builder.Property(x => x.GermanFullName).HasColumnName("GermanFullName");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Country.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.CountryByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
