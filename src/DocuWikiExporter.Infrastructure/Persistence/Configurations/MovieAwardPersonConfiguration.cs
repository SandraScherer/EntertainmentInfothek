using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_Award_Person".</summary>
public sealed class MovieAwardPersonConfiguration : IEntityTypeConfiguration<MovieAwardPerson>
{
    public void Configure(EntityTypeBuilder<MovieAwardPerson> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_Award_Person");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Movie_AwardID).HasColumnName("Movie_AwardID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Award_Person.Movie_AwardID -> Movie_Award.ID
        builder.HasOne(x => x.MovieAward)
            .WithMany(x => x.MovieAwardPersonByMovie_AwardID)
            .HasForeignKey(x => x.Movie_AwardID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Award_Person.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.MovieAwardPersonByPersonID)
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Award_Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieAwardPersonByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
