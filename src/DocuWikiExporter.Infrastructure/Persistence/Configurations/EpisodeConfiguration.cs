using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Episode".</summary>
public sealed class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Episode");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.SeasonNo).HasColumnName("SeasonNo");
        builder.Property(x => x.EpisodeNo).HasColumnName("EpisodeNo");
        builder.Property(x => x.CastStatusID).HasColumnName("CastStatusID");
        builder.Property(x => x.CrewStatusID).HasColumnName("CrewStatusID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode.CastStatusID -> Status.ID
        builder.HasOne(x => x.StatusByCastStatusID)
            .WithMany(x => x.EpisodeByCastStatusID)
            .HasForeignKey(x => x.CastStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode.CrewStatusID -> Status.ID
        builder.HasOne(x => x.StatusByCrewStatusID)
            .WithMany(x => x.EpisodeByCrewStatusID)
            .HasForeignKey(x => x.CrewStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany(x => x.EpisodeBySeriesID)
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.EpisodeByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
