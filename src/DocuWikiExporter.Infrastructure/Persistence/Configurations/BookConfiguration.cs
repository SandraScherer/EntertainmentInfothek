using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Book".</summary>
public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Book");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.TypeID).HasColumnName("TypeID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.LogoID).HasColumnName("LogoID");
        builder.Property(x => x.CastStatusID).HasColumnName("CastStatusID");
        builder.Property(x => x.ConnectionID).HasColumnName("ConnectionID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book.CastStatusID -> Status.ID
        builder.HasOne(x => x.StatusByCastStatusID)
            .WithMany(x => x.BookByCastStatusID)
            .HasForeignKey(x => x.CastStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book.ConnectionID -> Connection.ID
        builder.HasOne(x => x.Connection)
            .WithMany(x => x.BookByConnectionID)
            .HasForeignKey(x => x.ConnectionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book.LogoID -> Image.ID
        builder.HasOne(x => x.Image)
            .WithMany(x => x.BookByLogoID)
            .HasForeignKey(x => x.LogoID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.BookByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book.TypeID -> Type.ID
        builder.HasOne(x => x.Type)
            .WithMany(x => x.BookByTypeID)
            .HasForeignKey(x => x.TypeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
