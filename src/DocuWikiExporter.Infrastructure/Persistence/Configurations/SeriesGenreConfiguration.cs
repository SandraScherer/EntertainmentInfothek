using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Series_Genre".</summary>
public sealed class SeriesGenreConfiguration : IEntityTypeConfiguration<SeriesGenre>
{
    public void Configure(EntityTypeBuilder<SeriesGenre> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Series_Genre");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.GenreID).HasColumnName("GenreID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Genre.GenreID -> Genre.ID
        builder.HasOne(x => x.Genre)
            .WithMany(x => x.SeriesGenreByGenreID)
            .HasForeignKey(x => x.GenreID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Genre.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany(x => x.SeriesGenreBySeriesID)
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Genre.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.SeriesGenreByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
