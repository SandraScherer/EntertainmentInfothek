using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Image".</summary>
public sealed class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Image");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.FileName).HasColumnName("FileName");
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.Property(x => x.TypeID).HasColumnName("TypeID");
        builder.Property(x => x.CountryID).HasColumnName("CountryID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Image.CountryID -> Country.ID
        builder.HasOne(x => x.Country)
            .WithMany(x => x.ImageByCountryID)
            .HasForeignKey(x => x.CountryID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Image.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.ImageByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Image.TypeID -> Type.ID
        builder.HasOne(x => x.Type)
            .WithMany(x => x.ImageByTypeID)
            .HasForeignKey(x => x.TypeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
