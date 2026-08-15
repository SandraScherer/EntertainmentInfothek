using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Episode_OtherCompany".</summary>
public sealed class EpisodeOtherCompanyConfiguration : IEntityTypeConfiguration<EpisodeOtherCompany>
{
    public void Configure(EntityTypeBuilder<EpisodeOtherCompany> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Episode_OtherCompany");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeID).HasColumnName("EpisodeID");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_OtherCompany.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.EpisodeOtherCompanyByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_OtherCompany.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode)
            .WithMany(x => x.EpisodeOtherCompanyByEpisodeID)
            .HasForeignKey(x => x.EpisodeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_OtherCompany.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.EpisodeOtherCompanyByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
