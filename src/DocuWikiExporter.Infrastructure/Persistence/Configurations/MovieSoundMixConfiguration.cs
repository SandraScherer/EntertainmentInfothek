using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_SoundMix".</summary>
public sealed class MovieSoundMixConfiguration : IEntityTypeConfiguration<MovieSoundMix>
{
    public void Configure(EntityTypeBuilder<MovieSoundMix> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_SoundMix");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.SoundMixID).HasColumnName("SoundMixID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_SoundMix.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieSoundMixByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_SoundMix.SoundMixID -> SoundMix.ID
        builder.HasOne(x => x.SoundMix)
            .WithMany(x => x.MovieSoundMixBySoundMixID)
            .HasForeignKey(x => x.SoundMixID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_SoundMix.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieSoundMixByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
