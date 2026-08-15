using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_Publisher".</summary>
public sealed class VideoGamePublisherConfiguration : IEntityTypeConfiguration<VideoGamePublisher>
{
    public void Configure(EntityTypeBuilder<VideoGamePublisher> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_Publisher");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.PlatformID).HasColumnName("PlatformID");
        builder.Property(x => x.CountryID).HasColumnName("CountryID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Publisher.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.VideoGamePublisherByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Publisher.CountryID -> Country.ID
        builder.HasOne(x => x.Country)
            .WithMany(x => x.VideoGamePublisherByCountryID)
            .HasForeignKey(x => x.CountryID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Publisher.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform)
            .WithMany(x => x.VideoGamePublisherByPlatformID)
            .HasForeignKey(x => x.PlatformID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Publisher.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGamePublisherByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Publisher.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.VideoGamePublisherByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
