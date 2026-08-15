using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_Image".</summary>
public sealed class VideoGameImageConfiguration : IEntityTypeConfiguration<VideoGameImage>
{
    public void Configure(EntityTypeBuilder<VideoGameImage> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_Image");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.ImageID).HasColumnName("ImageID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Image.ImageID -> Image.ID
        builder.HasOne(x => x.Image)
            .WithMany(x => x.VideoGameImageByImageID)
            .HasForeignKey(x => x.ImageID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Image.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameImageByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Image.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.VideoGameImageByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
