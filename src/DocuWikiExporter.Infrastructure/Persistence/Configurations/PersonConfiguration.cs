using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuWikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>Fluent-API-Mapping für die bestehende Tabelle "Person".</summary>
public sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // Niemals Migrationen auf die produktive Datenbank anwenden: diese Konfiguration dient ausschließlich dem Lesen.
        builder.ToTable("Person");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.FirstName).HasColumnName("FirstName");
        builder.Property(x => x.LastName).HasColumnName("LastName");
        builder.Property(x => x.NameAddOn).HasColumnName("NameAddOn");
        builder.Property(x => x.BirthName).HasColumnName("BirthName");
        builder.Property(x => x.DateOfBirth).HasColumnName("DateOfBirth");
        builder.Property(x => x.LocationOfBirthID).HasColumnName("LocationOfBirthID");
        builder.Property(x => x.DateOfDeath).HasColumnName("DateOfDeath");
        builder.Property(x => x.LocationOfDeathID).HasColumnName("LocationOfDeathID");
        builder.Property(x => x.CauseOfDeath).HasColumnName("CauseOfDeath");
        builder.Property(x => x.EmployerID).HasColumnName("EmployerID");
        builder.Property(x => x.TypeID).HasColumnName("TypeID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusID).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person.EmployerID -> Company.ID
        builder.HasOne(x => x.Employer)
            .WithMany()
            .HasForeignKey(x => x.EmployerID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Person.LocationOfBirthID -> Location.ID
        builder.HasOne(x => x.LocationOfBirth)
            .WithMany()
            .HasForeignKey(x => x.LocationOfBirthID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Person.LocationOfDeathID -> Location.ID
        builder.HasOne(x => x.LocationOfDeath)
            .WithMany()
            .HasForeignKey(x => x.LocationOfDeathID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // FK: Person.TypeID -> Type.ID
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeID)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
