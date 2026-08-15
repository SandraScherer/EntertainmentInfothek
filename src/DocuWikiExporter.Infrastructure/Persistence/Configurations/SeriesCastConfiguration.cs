using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Series_Cast".</summary>
public sealed class SeriesCastConfiguration : IEntityTypeConfiguration<SeriesCast>
{
    public void Configure(EntityTypeBuilder<SeriesCast> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Series_Cast");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.ActorID).HasColumnName("ActorID");
        builder.Property(x => x.GermanDubberID).HasColumnName("GermanDubberID");
        builder.Property(x => x.Character).HasColumnName("Character");
        builder.Property(x => x.CharacterID).HasColumnName("CharacterID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Cast.ActorID -> Person.ID
        builder.HasOne(x => x.PersonByActorID)
            .WithMany(x => x.SeriesCastByActorID)
            .HasForeignKey(x => x.ActorID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.PersonByCharacterID)
            .WithMany(x => x.SeriesCastByCharacterID)
            .HasForeignKey(x => x.CharacterID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.GermanDubberID -> Person.ID
        builder.HasOne(x => x.PersonByGermanDubberID)
            .WithMany(x => x.SeriesCastByGermanDubberID)
            .HasForeignKey(x => x.GermanDubberID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany(x => x.SeriesCastBySeriesID)
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.SeriesCastByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
