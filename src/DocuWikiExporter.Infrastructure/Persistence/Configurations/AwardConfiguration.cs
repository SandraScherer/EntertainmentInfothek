using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Award".</summary>
public sealed class AwardConfiguration : IEntityTypeConfiguration<Award>
{
    public void Configure(EntityTypeBuilder<Award> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Award");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.PresenterID).HasColumnName("PresenterID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Award.PresenterID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.AwardByPresenterID)
            .HasForeignKey(x => x.PresenterID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Award.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.AwardByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
