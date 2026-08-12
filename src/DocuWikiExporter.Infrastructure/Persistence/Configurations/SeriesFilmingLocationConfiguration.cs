using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die bestehende Tabelle "Series_FilmingLocation".</summary>
public sealed class SeriesFilmingLocationConfiguration : IEntityTypeConfiguration<SeriesFilmingLocation>
{
    public void Configure(EntityTypeBuilder<SeriesFilmingLocation> builder)
    {
        // Niemals Migrationen auf die produktive Datenbank anwenden: diese Konfiguration dient ausschließlich dem Lesen.
        builder.ToTable("Series_FilmingLocation");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.LocationID).HasColumnName("LocationID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_FilmingLocation.LocationID -> Location.ID
        builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_FilmingLocation.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany()
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_FilmingLocation.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
