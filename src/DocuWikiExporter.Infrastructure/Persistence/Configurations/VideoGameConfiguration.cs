using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame".</summary>
public sealed class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame>
{
    public void Configure(EntityTypeBuilder<VideoGame> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.TypeID).HasColumnName("TypeID");
        builder.Property(x => x.LogoID).HasColumnName("LogoID");
        builder.Property(x => x.Budget).HasColumnName("Budget");
        builder.Property(x => x.WorldwideGross).HasColumnName("WorldwideGross");
        builder.Property(x => x.WorldwideGrossDate).HasColumnName("WorldwideGrossDate");
        builder.Property(x => x.CastStatusID).HasColumnName("CastStatusID");
        builder.Property(x => x.ConnectionID).HasColumnName("ConnectionID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame.CastStatusID -> Status.ID
        builder.HasOne(x => x.StatusByCastStatusID)
            .WithMany(x => x.VideoGameByCastStatusID)
            .HasForeignKey(x => x.CastStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.ConnectionID -> Connection.ID
        builder.HasOne(x => x.Connection)
            .WithMany(x => x.VideoGameByConnectionID)
            .HasForeignKey(x => x.ConnectionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.LogoID -> Image.ID
        builder.HasOne(x => x.Image)
            .WithMany(x => x.VideoGameByLogoID)
            .HasForeignKey(x => x.LogoID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.TypeID -> Type.ID
        builder.HasOne(x => x.Type)
            .WithMany(x => x.VideoGameByTypeID)
            .HasForeignKey(x => x.TypeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
