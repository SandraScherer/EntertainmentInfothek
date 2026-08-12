namespace DocuWikiExporter.Domain.Entities;

/// <summary>
/// Gemeinsame technische Felder der bestehenden SQLite-Tabellen.
/// Die Datenbank verwendet TEXT für IDs und auch für Datumsfelder; deshalb
/// wird LastUpdated bewusst als string abgebildet, um keine implizite
/// Konvertierung in einer produktiven Bestandsdatenbank zu erzwingen.
/// </summary>
public abstract class EntityBase
{
    public string Id { get; set; } = null!;
    public string? Details { get; set; }
    public string? Notes { get; set; }
    public string? StatusId { get; set; }
    public string? LastUpdated { get; set; }
}
