using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_Score".</summary>
public sealed class VideoGameScoreConfiguration : IEntityTypeConfiguration<VideoGameScore>
{
    public void Configure(EntityTypeBuilder<VideoGameScore> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_Score");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.Score).HasColumnName("Score");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.PlatformID).HasColumnName("PlatformID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Score.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.VideoGameScoreByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Score.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform)
            .WithMany(x => x.VideoGameScoreByPlatformID)
            .HasForeignKey(x => x.PlatformID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Score.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameScoreByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Score.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.VideoGameScoreByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
