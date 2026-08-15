using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die unveränderte SQLite-Tabelle "Series_AnimationDepartment".</summary>
public sealed class SeriesAnimationDepartmentConfiguration : IEntityTypeConfiguration<SeriesAnimationDepartment>
{
    public void Configure(EntityTypeBuilder<SeriesAnimationDepartment> builder)
    {
        // Bestehende produktive Tabelle: EF Core darf hier keine Schemaänderungen auslösen.
        builder.ToTable("Series_AnimationDepartment");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesID).HasColumnName("SeriesID");
        builder.Property(x => x.PersonID).HasColumnName("PersonID");
        builder.Property(x => x.Role).HasColumnName("Role");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_AnimationDepartment.PersonID -> Person.ID
        builder.HasOne(x => x.Person)
            .WithMany(x => x.SeriesAnimationDepartmentByPersonID)
            .HasForeignKey(x => x.PersonID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_AnimationDepartment.SeriesID -> Series.ID
        builder.HasOne(x => x.Series)
            .WithMany(x => x.SeriesAnimationDepartmentBySeriesID)
            .HasForeignKey(x => x.SeriesID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Series_AnimationDepartment.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany(x => x.SeriesAnimationDepartmentByStatusID)
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
