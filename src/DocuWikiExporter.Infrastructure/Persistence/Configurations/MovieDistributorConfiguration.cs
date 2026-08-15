using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_Distributor".</summary>
public sealed class MovieDistributorConfiguration : IEntityTypeConfiguration<MovieDistributor>
{
    public void Configure(EntityTypeBuilder<MovieDistributor> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_Distributor");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.CountryID).HasColumnName("CountryID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Distributor.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.MovieDistributorByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Distributor.CountryID -> Country.ID
        builder.HasOne(x => x.Country)
            .WithMany(x => x.MovieDistributorByCountryID)
            .HasForeignKey(x => x.CountryID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Distributor.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieDistributorByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Distributor.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieDistributorByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
