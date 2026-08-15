using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Weblink".</summary>
public sealed class WeblinkConfiguration : IEntityTypeConfiguration<Weblink>
{
    public void Configure(EntityTypeBuilder<Weblink> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Weblink");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.URL).HasColumnName("URL");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.LanguageID).HasColumnName("LanguageID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Weblink.LanguageID -> Language.ID
        builder.HasOne(x => x.Language)
            .WithMany(x => x.WeblinkByLanguageID)
            .HasForeignKey(x => x.LanguageID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.WeblinkByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
