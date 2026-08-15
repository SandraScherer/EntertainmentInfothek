using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_Distributor".</summary>
public sealed class VideoGameDistributorConfiguration : IEntityTypeConfiguration<VideoGameDistributor>
{
    public void Configure(EntityTypeBuilder<VideoGameDistributor> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_Distributor");

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

        // FK: VideoGame_Distributor.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.VideoGameDistributorByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Distributor.CountryID -> Country.ID
        builder.HasOne(x => x.Country)
            .WithMany(x => x.VideoGameDistributorByCountryID)
            .HasForeignKey(x => x.CountryID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Distributor.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform)
            .WithMany(x => x.VideoGameDistributorByPlatformID)
            .HasForeignKey(x => x.PlatformID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Distributor.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameDistributorByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
