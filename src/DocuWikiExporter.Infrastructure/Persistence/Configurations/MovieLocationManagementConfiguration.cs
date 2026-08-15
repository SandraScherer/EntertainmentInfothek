using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_LocationManagement".</summary>
public sealed class MovieLocationManagementConfiguration : IEntityTypeConfiguration<MovieLocationManagement>
{
    public void Configure(EntityTypeBuilder<MovieLocationManagement> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_LocationManagement");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_LocationManagement.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieLocationManagementByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_LocationManagement.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.MovieLocationManagementByPersonID)
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_LocationManagement.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieLocationManagementByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
