using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_Certification".</summary>
public sealed class VideoGameCertificationConfiguration : IEntityTypeConfiguration<VideoGameCertification>
{
    public void Configure(EntityTypeBuilder<VideoGameCertification> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_Certification");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.CertificationID).HasColumnName("CertificationID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification)
            .WithMany(x => x.VideoGameCertificationByCertificationID)
            .HasForeignKey(x => x.CertificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameCertificationByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Certification.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.VideoGameCertificationByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
