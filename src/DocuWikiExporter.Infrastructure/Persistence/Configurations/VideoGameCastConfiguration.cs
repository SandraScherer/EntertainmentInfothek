using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_Cast".</summary>
public sealed class VideoGameCastConfiguration : IEntityTypeConfiguration<VideoGameCast>
{
    public void Configure(EntityTypeBuilder<VideoGameCast> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_Cast");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.ActorID).HasColumnName("ActorID");
        builder.Property(x => x.DubberID).HasColumnName("DubberID");
        builder.Property(x => x.Character).HasColumnName("Character");
        builder.Property(x => x.CharacterID).HasColumnName("CharacterID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Cast.ActorID -> Person.ID
        builder.HasOne(x => x.PersonByActorID)
            .WithMany(x => x.VideoGameCastByActorID)
            .HasForeignKey(x => x.ActorID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.PersonByCharacterID)
            .WithMany(x => x.VideoGameCastByCharacterID)
            .HasForeignKey(x => x.CharacterID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.DubberID -> Person.ID
        builder.HasOne(x => x.PersonByDubberID)
            .WithMany(x => x.VideoGameCastByDubberID)
            .HasForeignKey(x => x.DubberID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameCastByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.VideoGameCastByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
