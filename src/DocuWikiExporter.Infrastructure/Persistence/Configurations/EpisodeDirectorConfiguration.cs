using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Episode_Director".</summary>
public sealed class EpisodeDirectorConfiguration : IEntityTypeConfiguration<EpisodeDirector>
{
    public void Configure(EntityTypeBuilder<EpisodeDirector> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Episode_Director");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeID).HasColumnName("EpisodeID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_Director.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode)
            .WithMany(x => x.EpisodeDirectorByEpisodeID)
            .HasForeignKey(x => x.EpisodeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Director.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.EpisodeDirectorByPersonID)
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Director.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.EpisodeDirectorByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
