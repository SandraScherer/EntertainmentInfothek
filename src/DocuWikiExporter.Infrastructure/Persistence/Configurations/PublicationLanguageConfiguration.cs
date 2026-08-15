using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Publication_Language".</summary>
public sealed class PublicationLanguageConfiguration : IEntityTypeConfiguration<PublicationLanguage>
{
    public void Configure(EntityTypeBuilder<PublicationLanguage> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Publication_Language");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationID).HasColumnName("PublicationID");
        builder.Property(x => x.LanguageID).HasColumnName("LanguageID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_Language.LanguageID -> Language.ID
        builder.HasOne(x => x.Language)
            .WithMany(x => x.PublicationLanguageByLanguageID)
            .HasForeignKey(x => x.LanguageID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Language.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication)
            .WithMany(x => x.PublicationLanguageByPublicationID)
            .HasForeignKey(x => x.PublicationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Language.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.PublicationLanguageByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
