using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Book_Description".</summary>
public sealed class BookDescriptionConfiguration : IEntityTypeConfiguration<BookDescription>
{
    public void Configure(EntityTypeBuilder<BookDescription> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Book_Description");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookID).HasColumnName("BookID");
        builder.Property(x => x.TextID).HasColumnName("TextID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Description.BookID -> Book.ID
        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookDescriptionByBookID)
            .HasForeignKey(x => x.BookID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Description.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.BookDescriptionByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Description.TextID -> Text.ID
        builder.HasOne(x => x.Text)
            .WithMany(x => x.BookDescriptionByTextID)
            .HasForeignKey(x => x.TextID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
