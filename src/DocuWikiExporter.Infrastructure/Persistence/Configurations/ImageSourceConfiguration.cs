using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Image_Source".</summary>
public sealed class ImageSourceConfiguration : IEntityTypeConfiguration<ImageSource>
{
    public void Configure(EntityTypeBuilder<ImageSource> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Image_Source");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.ImageID).HasColumnName("ImageID");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Image_Source.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.ImageSourceByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Image_Source.ImageID -> Image.ID
        builder.HasOne(x => x.Image)
            .WithMany(x => x.ImageSourceByImageID)
            .HasForeignKey(x => x.ImageID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Image_Source.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.ImageSourceByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
