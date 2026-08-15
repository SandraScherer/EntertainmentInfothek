using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Text_Source".</summary>
public sealed class TextSourceConfiguration : IEntityTypeConfiguration<TextSource>
{
    public void Configure(EntityTypeBuilder<TextSource> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Text_Source");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TextID).HasColumnName("TextID");
        builder.Property(x => x.CompanyID).HasColumnName("CompanyID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Text_Source.CompanyID -> Company.ID
        builder.HasOne(x => x.Company)
            .WithMany(x => x.TextSourceByCompanyID)
            .HasForeignKey(x => x.CompanyID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Text_Source.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.TextSourceByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Text_Source.TextID -> Text.ID
        builder.HasOne(x => x.Text)
            .WithMany(x => x.TextSourceByTextID)
            .HasForeignKey(x => x.TextID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
