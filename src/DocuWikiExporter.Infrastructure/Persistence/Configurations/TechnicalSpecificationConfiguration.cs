using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "TechnicalSpecification".</summary>
public sealed class TechnicalSpecificationConfiguration : IEntityTypeConfiguration<TechnicalSpecification>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecification> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("TechnicalSpecification");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.PlatformID).HasColumnName("PlatformID");
        builder.Property(x => x.BusinessModelID).HasColumnName("BusinessModelID");
        builder.Property(x => x.MinimumCPUClassID).HasColumnName("MinimumCPUClassID");
        builder.Property(x => x.MinimumOSClassID).HasColumnName("MinimumOSClassID");
        builder.Property(x => x.MinimumRAMID).HasColumnName("MinimumRAMID");
        builder.Property(x => x.MinimumDirectXID).HasColumnName("MinimumDirectXID");
        builder.Property(x => x.MinimumCDRomDriveSpeedID).HasColumnName("MinimumCDRomDriveSpeedID");
        builder.Property(x => x.MinimumVideoRAMID).HasColumnName("MinimumVideoRAMID");
        builder.Property(x => x.NoOfPlayersOffline).HasColumnName("NoOfPlayersOffline");
        builder.Property(x => x.NoOfPlayersOfflineMultitap).HasColumnName("NoOfPlayersOfflineMultitap");
        builder.Property(x => x.NoOfPlayersOnline).HasColumnName("NoOfPlayersOnline");
        builder.Property(x => x.Annotation).HasColumnName("Annotation");
        builder.Property(x => x.MiscAttributes).HasColumnName("MiscAttributes");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification.BusinessModelID -> BusinessModel.ID
        builder.HasOne(x => x.BusinessModel)
            .WithMany(x => x.TechnicalSpecificationByBusinessModelID)
            .HasForeignKey(x => x.BusinessModelID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumCDRomDriveSpeedID -> CDROMDriveSpeed.ID
        builder.HasOne(x => x.CDROMDriveSpeed)
            .WithMany(x => x.TechnicalSpecificationByMinimumCDRomDriveSpeedID)
            .HasForeignKey(x => x.MinimumCDRomDriveSpeedID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumCPUClassID -> CPU.ID
        builder.HasOne(x => x.CPU)
            .WithMany(x => x.TechnicalSpecificationByMinimumCPUClassID)
            .HasForeignKey(x => x.MinimumCPUClassID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumDirectXID -> DirectX.ID
        builder.HasOne(x => x.DirectX)
            .WithMany(x => x.TechnicalSpecificationByMinimumDirectXID)
            .HasForeignKey(x => x.MinimumDirectXID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumOSClassID -> OperatingSystem.ID
        builder.HasOne(x => x.OperatingSystem)
            .WithMany(x => x.TechnicalSpecificationByMinimumOSClassID)
            .HasForeignKey(x => x.MinimumOSClassID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumRAMID -> RAM.ID
        builder.HasOne(x => x.RAMByMinimumRAMID)
            .WithMany(x => x.TechnicalSpecificationByMinimumRAMID)
            .HasForeignKey(x => x.MinimumRAMID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumVideoRAMID -> RAM.ID
        builder.HasOne(x => x.RAMByMinimumVideoRAMID)
            .WithMany(x => x.TechnicalSpecificationByMinimumVideoRAMID)
            .HasForeignKey(x => x.MinimumVideoRAMID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform)
            .WithMany(x => x.TechnicalSpecificationByPlatformID)
            .HasForeignKey(x => x.PlatformID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TechnicalSpecificationByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.TechnicalSpecificationByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
