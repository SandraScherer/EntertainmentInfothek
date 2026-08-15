using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Publication".</summary>
public sealed class PublicationConfiguration : IEntityTypeConfiguration<Publication>
{
    public void Configure(EntityTypeBuilder<Publication> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Publication");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.ISBN13).HasColumnName("ISBN13");
        builder.Property(x => x.ISBN10).HasColumnName("ISBN10");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.FormatID).HasColumnName("FormatID");
        builder.Property(x => x.EditionID).HasColumnName("EditionID");
        builder.Property(x => x.NoOfPages).HasColumnName("NoOfPages");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition)
            .WithMany(x => x.PublicationByEditionID)
            .HasForeignKey(x => x.EditionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication.FormatID -> Type.ID
        builder.HasOne(x => x.Type)
            .WithMany(x => x.PublicationByFormatID)
            .HasForeignKey(x => x.FormatID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.PublicationByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
