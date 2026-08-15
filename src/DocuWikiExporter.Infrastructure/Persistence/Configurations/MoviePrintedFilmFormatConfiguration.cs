using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_PrintedFilmFormat".</summary>
public sealed class MoviePrintedFilmFormatConfiguration : IEntityTypeConfiguration<MoviePrintedFilmFormat>
{
    public void Configure(EntityTypeBuilder<MoviePrintedFilmFormat> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_PrintedFilmFormat");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.FilmFormatID).HasColumnName("FilmFormatID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_PrintedFilmFormat.FilmFormatID -> FilmFormat.ID
        builder.HasOne(x => x.FilmFormat)
            .WithMany(x => x.MoviePrintedFilmFormatByFilmFormatID)
            .HasForeignKey(x => x.FilmFormatID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_PrintedFilmFormat.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MoviePrintedFilmFormatByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_PrintedFilmFormat.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MoviePrintedFilmFormatByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
