using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Series_PrintedFilmFormat".</summary>
public sealed class SeriesPrintedFilmFormatConfiguration : IEntityTypeConfiguration<SeriesPrintedFilmFormat>
{
    public void Configure(EntityTypeBuilder<SeriesPrintedFilmFormat> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Series_PrintedFilmFormat");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.FilmFormatID).HasColumnName("FilmFormatID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_PrintedFilmFormat.FilmFormatID -> FilmFormat.ID
        builder.HasOne(x => x.FilmFormat)
            .WithMany(x => x.SeriesPrintedFilmFormatByFilmFormatID)
            .HasForeignKey(x => x.FilmFormatID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_PrintedFilmFormat.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany(x => x.SeriesPrintedFilmFormatBySeriesID)
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_PrintedFilmFormat.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.SeriesPrintedFilmFormatByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
