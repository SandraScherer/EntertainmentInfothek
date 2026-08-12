using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die bestehende Tabelle "Series_User".</summary>
public sealed class SeriesUserConfiguration : IEntityTypeConfiguration<SeriesUser>
{
    public void Configure(EntityTypeBuilder<SeriesUser> builder)
    {
        // Niemals Migrationen auf die produktive Datenbank anwenden: diese Konfiguration dient ausschließlich dem Lesen.
        builder.ToTable("Series_User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.UserID).HasColumnName("UserID");
        builder.Property(x => x.EditionID).HasColumnName("EditionID");
        builder.Property(x => x.UserStatusID).HasColumnName("UserStatusID");
        builder.Property(x => x.PriorityID).HasColumnName("PriorityID");
        builder.Property(x => x.Explanation).HasColumnName("Explanation");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_User.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition)
            .WithMany()
            .HasForeignKey(x => x.EditionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority)
            .WithMany()
            .HasForeignKey(x => x.PriorityID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany()
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.UserID -> User.ID
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.UserStatus)
            .WithMany()
            .HasForeignKey(x => x.UserStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
