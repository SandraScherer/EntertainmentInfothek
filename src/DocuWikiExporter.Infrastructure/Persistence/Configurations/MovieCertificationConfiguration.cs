using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_Certification".</summary>
public sealed class MovieCertificationConfiguration : IEntityTypeConfiguration<MovieCertification>
{
    public void Configure(EntityTypeBuilder<MovieCertification> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_Certification");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.CertificationID).HasColumnName("CertificationID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification)
            .WithMany(x => x.MovieCertificationByCertificationID)
            .HasForeignKey(x => x.CertificationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Certification.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieCertificationByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieCertificationByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
