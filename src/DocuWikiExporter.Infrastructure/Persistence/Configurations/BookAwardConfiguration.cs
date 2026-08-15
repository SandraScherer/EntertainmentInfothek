using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Book_Award".</summary>
public sealed class BookAwardConfiguration : IEntityTypeConfiguration<BookAward>
{
    public void Configure(EntityTypeBuilder<BookAward> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Book_Award");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookID).HasColumnName("BookID");
        builder.Property(x => x.AwardID).HasColumnName("AwardID");
        builder.Property(x => x.Category).HasColumnName("Category");
        builder.Property(x => x.Year).HasColumnName("Year");
        builder.Property(x => x.Winner).HasColumnName("Winner");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Award.AwardID -> Award.ID
        builder.HasOne(x => x.Award)
            .WithMany(x => x.BookAwardByAwardID)
            .HasForeignKey(x => x.AwardID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Award.BookID -> Book.ID
        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookAwardByBookID)
            .HasForeignKey(x => x.BookID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Award.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.BookAwardByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
