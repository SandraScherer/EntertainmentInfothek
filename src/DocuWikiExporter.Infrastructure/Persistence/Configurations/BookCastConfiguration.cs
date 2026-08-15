using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Book_Cast".</summary>
public sealed class BookCastConfiguration : IEntityTypeConfiguration<BookCast>
{
    public void Configure(EntityTypeBuilder<BookCast> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Book_Cast");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookID).HasColumnName("BookID");
        builder.Property(x => x.Character).HasColumnName("Character");
        builder.Property(x => x.CharacterID).HasColumnName("CharacterID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Cast.BookID -> Book.ID
        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookCastByBookID)
            .HasForeignKey(x => x.BookID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.BookCastByCharacterID)
            .HasForeignKey(x => x.CharacterID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.BookCastByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
