using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification_MultiplayerGameMode".</summary>
public sealed class TechnicalSpecificationMultiplayerGameModeConfiguration : IEntityTypeConfiguration<TechnicalSpecificationMultiplayerGameMode>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationMultiplayerGameMode> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification_MultiplayerGameMode");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationID).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.MultiplayerGameModeID).HasColumnName("MultiplayerGameModeID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_MultiplayerGameMode.MultiplayerGameModeID -> MultiplayerGameMode.ID
        builder.HasOne(x => x.MultiplayerGameMode)
            .WithMany(x => x.TechnicalSpecificationMultiplayerGameModeByMultiplayerGameModeID)
            .HasForeignKey(x => x.MultiplayerGameModeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MultiplayerGameMode.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationMultiplayerGameModeByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MultiplayerGameMode.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification)
            .WithMany(x => x.TechnicalSpecificationMultiplayerGameModeByTechnicalSpecificationID)
            .HasForeignKey(x => x.TechnicalSpecificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
