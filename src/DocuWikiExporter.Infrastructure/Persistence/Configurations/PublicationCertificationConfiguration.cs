using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Publication_Certification".</summary>
public sealed class PublicationCertificationConfiguration : IEntityTypeConfiguration<PublicationCertification>
{
    public void Configure(EntityTypeBuilder<PublicationCertification> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Publication_Certification");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationID).HasColumnName("PublicationID");
        builder.Property(x => x.CertificationID).HasColumnName("CertificationID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification)
            .WithMany(x => x.PublicationCertificationByCertificationID)
            .HasForeignKey(x => x.CertificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Certification.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication)
            .WithMany(x => x.PublicationCertificationByPublicationID)
            .HasForeignKey(x => x.PublicationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.PublicationCertificationByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
