using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Publication_Publisher".</summary>
public sealed class PublicationPublisherConfiguration : IEntityTypeConfiguration<PublicationPublisher>
{
    public void Configure(EntityTypeBuilder<PublicationPublisher> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Publication_Publisher");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationID).HasColumnName("PublicationID");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_Publisher.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.PublicationPublisherByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Publisher.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication)
            .WithMany(x => x.PublicationPublisherByPublicationID)
            .HasForeignKey(x => x.PublicationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Publisher.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.PublicationPublisherByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
