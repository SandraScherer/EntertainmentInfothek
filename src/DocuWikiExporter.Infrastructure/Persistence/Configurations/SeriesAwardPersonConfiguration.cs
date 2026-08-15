using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Series_Award_Person".</summary>
public sealed class SeriesAwardPersonConfiguration : IEntityTypeConfiguration<SeriesAwardPerson>
{
    public void Configure(EntityTypeBuilder<SeriesAwardPerson> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Series_Award_Person");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Series_AwardID).HasColumnName("Series_AwardID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Award_Person.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.SeriesAwardPersonByPersonID)
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Award_Person.Series_AwardID -> Series_Award.ID
        builder.HasOne(x => x.SeriesAward)
            .WithMany(x => x.SeriesAwardPersonBySeries_AwardID)
            .HasForeignKey(x => x.Series_AwardID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Award_Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.SeriesAwardPersonByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
