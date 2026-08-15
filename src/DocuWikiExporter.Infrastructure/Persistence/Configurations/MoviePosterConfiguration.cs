using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_Poster".</summary>
public sealed class MoviePosterConfiguration : IEntityTypeConfiguration<MoviePoster>
{
    public void Configure(EntityTypeBuilder<MoviePoster> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_Poster");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.ImageID).HasColumnName("ImageID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Poster.ImageID -> Image.ID
        builder.HasOne(x => x.Image)
            .WithMany(x => x.MoviePosterByImageID)
            .HasForeignKey(x => x.ImageID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Poster.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MoviePosterByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Poster.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MoviePosterByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
