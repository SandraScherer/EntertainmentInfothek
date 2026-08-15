using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Episode_TransportationDepartment".</summary>
public sealed class EpisodeTransportationDepartmentConfiguration : IEntityTypeConfiguration<EpisodeTransportationDepartment>
{
    public void Configure(EntityTypeBuilder<EpisodeTransportationDepartment> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Episode_TransportationDepartment");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeID).HasColumnName("EpisodeID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_TransportationDepartment.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode)
            .WithMany(x => x.EpisodeTransportationDepartmentByEpisodeID)
            .HasForeignKey(x => x.EpisodeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_TransportationDepartment.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.EpisodeTransportationDepartmentByPersonID)
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_TransportationDepartment.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.EpisodeTransportationDepartmentByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
