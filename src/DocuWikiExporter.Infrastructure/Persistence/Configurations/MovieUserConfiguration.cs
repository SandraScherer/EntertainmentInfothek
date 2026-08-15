using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Movie_User".</summary>
public sealed class MovieUserConfiguration : IEntityTypeConfiguration<MovieUser>
{
    public void Configure(EntityTypeBuilder<MovieUser> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Movie_User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieID).HasColumnName("MovieID");
        builder.Property(x => x.UserID).HasColumnName("UserID");
        builder.Property(x => x.EditionID).HasColumnName("EditionID");
        builder.Property(x => x.UserStatusID).HasColumnName("UserStatusID");
        builder.Property(x => x.PriorityID).HasColumnName("PriorityID");
        builder.Property(x => x.Explanation).HasColumnName("Explanation");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_User.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition)
            .WithMany(x => x.MovieUserByEditionID)
            .HasForeignKey(x => x.EditionID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieUserByMovieID)
            .HasForeignKey(x => x.MovieID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority)
            .WithMany(x => x.MovieUserByPriorityID)
            .HasForeignKey(x => x.PriorityID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.MovieUserByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.UserID -> User.ID
        builder.HasOne(x => x.User)
            .WithMany(x => x.MovieUserByUserID)
            .HasForeignKey(x => x.UserID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.StatusByUserStatusID)
            .WithMany(x => x.MovieUserByUserStatusID)
            .HasForeignKey(x => x.UserStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
