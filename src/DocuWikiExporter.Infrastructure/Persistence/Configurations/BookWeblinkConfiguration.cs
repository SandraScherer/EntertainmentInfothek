using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Book_Weblink".</summary>
public sealed class BookWeblinkConfiguration : IEntityTypeConfiguration<BookWeblink>
{
    public void Configure(EntityTypeBuilder<BookWeblink> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Book_Weblink");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookID).HasColumnName("BookID");
        builder.Property(x => x.WeblinkID).HasColumnName("WeblinkID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Weblink.BookID -> Book.ID
        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookWeblinkByBookID)
            .HasForeignKey(x => x.BookID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.BookWeblinkByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Weblink.WeblinkID -> Weblink.ID
        builder.HasOne(x => x.Weblink)
            .WithMany(x => x.BookWeblinkByWeblinkID)
            .HasForeignKey(x => x.WeblinkID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
