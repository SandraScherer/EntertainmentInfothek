using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die bestehende Tabelle "Episode_Award_Person".</summary>
public sealed class EpisodeAwardPersonConfiguration : IEntityTypeConfiguration<EpisodeAwardPerson>
{
    public void Configure(EntityTypeBuilder<EpisodeAwardPerson> builder)
    {
        // Niemals Migrationen auf die produktive Datenbank anwenden: diese Konfiguration dient ausschließlich dem Lesen.
        builder.ToTable("Episode_Award_Person");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Episode_AwardID).HasColumnName("Episode_AwardID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_Award_Person.Episode_AwardID -> Episode_Award.ID
        builder.HasOne(x => x.Episode_Award)
            .WithMany()
            .HasForeignKey(x => x.Episode_AwardID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Award_Person.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Award_Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
