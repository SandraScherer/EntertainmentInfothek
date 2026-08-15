using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Book_User".</summary>
public sealed class BookUserConfiguration : IEntityTypeConfiguration<BookUser>
{
    public void Configure(EntityTypeBuilder<BookUser> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Book_User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookID).HasColumnName("BookID");
        builder.Property(x => x.UserID).HasColumnName("UserID");
        builder.Property(x => x.PublicationID).HasColumnName("PublicationID");
        builder.Property(x => x.UserStatusID).HasColumnName("UserStatusID");
        builder.Property(x => x.PriorityID).HasColumnName("PriorityID");
        builder.Property(x => x.Explanation).HasColumnName("Explanation");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_User.BookID -> Book.ID
        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookUserByBookID)
            .HasForeignKey(x => x.BookID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority)
            .WithMany(x => x.BookUserByPriorityID)
            .HasForeignKey(x => x.PriorityID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication)
            .WithMany(x => x.BookUserByPublicationID)
            .HasForeignKey(x => x.PublicationID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.BookUserByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.UserID -> User.ID
        builder.HasOne(x => x.User)
            .WithMany(x => x.BookUserByUserID)
            .HasForeignKey(x => x.UserID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.StatusByUserStatusID)
            .WithMany(x => x.BookUserByUserStatusID)
            .HasForeignKey(x => x.UserStatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
