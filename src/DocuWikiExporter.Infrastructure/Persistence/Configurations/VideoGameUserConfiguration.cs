using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "VideoGame_User".</summary>
public sealed class VideoGameUserConfiguration : IEntityTypeConfiguration<VideoGameUser>
{
    public void Configure(EntityTypeBuilder<VideoGameUser> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("VideoGame_User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameID).HasColumnName("VideoGameID");
        builder.Property(x => x.UserID).HasColumnName("UserID");
        builder.Property(x => x.EditionID).HasColumnName("EditionID");
        builder.Property(x => x.UserStatusID).HasColumnName("UserStatusID");
        builder.Property(x => x.PriorityID).HasColumnName("PriorityID");
        builder.Property(x => x.Explanation).HasColumnName("Explanation");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_User.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition)
            .WithMany(x => x.VideoGameUserByEditionID)
            .HasForeignKey(x => x.EditionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority)
            .WithMany(x => x.VideoGameUserByPriorityID)
            .HasForeignKey(x => x.PriorityID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.VideoGameUserByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.UserID -> User.ID
        builder.HasOne(x => x.User)
            .WithMany(x => x.VideoGameUserByUserID)
            .HasForeignKey(x => x.UserID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.StatusByUserStatusID)
            .WithMany(x => x.VideoGameUserByUserStatusID)
            .HasForeignKey(x => x.UserStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame)
            .WithMany(x => x.VideoGameUserByVideoGameID)
            .HasForeignKey(x => x.VideoGameID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
