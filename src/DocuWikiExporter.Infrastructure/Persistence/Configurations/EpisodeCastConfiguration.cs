using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die bestehende Tabelle "Episode_Cast".</summary>
public sealed class EpisodeCastConfiguration : IEntityTypeConfiguration<EpisodeCast>
{
    public void Configure(EntityTypeBuilder<EpisodeCast> builder)
    {
        // Niemals Migrationen auf die produktive Datenbank anwenden: diese Konfiguration dient ausschließlich dem Lesen.
        builder.ToTable("Episode_Cast");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeID).HasColumnName("EpisodeID");
        builder.Property(x => x.ActorID).HasColumnName("ActorID");
        builder.Property(x => x.GermanDubberID).HasColumnName("GermanDubberID");
        builder.Property(x => x.Character).HasColumnName("Character");
        builder.Property(x => x.CharacterID).HasColumnName("CharacterID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_Cast.ActorID -> Person.ID
        builder.HasOne(x => x.Actor)
            .WithMany()
            .HasForeignKey(x => x.ActorID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.Character)
            .WithMany()
            .HasForeignKey(x => x.CharacterID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Cast.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode)
            .WithMany()
            .HasForeignKey(x => x.EpisodeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Cast.GermanDubberID -> Person.ID
        builder.HasOne(x => x.GermanDubber)
            .WithMany()
            .HasForeignKey(x => x.GermanDubberID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
