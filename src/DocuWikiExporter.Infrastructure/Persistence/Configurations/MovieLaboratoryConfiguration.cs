using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_Laboratory".</summary>
public sealed class MovieLaboratoryConfiguration : IEntityTypeConfiguration<MovieLaboratory>
{
    public void Configure(EntityTypeBuilder<MovieLaboratory> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_Laboratory");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.LaboratoryID).HasColumnName("LaboratoryID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Laboratory.LaboratoryID -> Laboratory.ID
        builder.HasOne(x => x.Laboratory)
            .WithMany(x => x.MovieLaboratoryByLaboratoryID)
            .HasForeignKey(x => x.LaboratoryID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Laboratory.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieLaboratoryByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Laboratory.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieLaboratoryByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
