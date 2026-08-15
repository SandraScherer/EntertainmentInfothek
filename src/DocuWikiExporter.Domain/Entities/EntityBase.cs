namespace DocuWikiExporter.Domain.Entities;

/// <summary>Gemeinsame technische Spalten aller Tabellen der bestehenden Datenbank.</summary>
public abstract class EntityBase
{
    /// <summary>Primärschlüssel der SQLite-Tabelle (TEXT).</summary>
    public string Id { get; set; } = null!;

    /// <summary>Freitext-Feld der Bestandsdatenbank.</summary>
    public string? Details { get; set; }

    /// <summary>Notizen der Bestandsdatenbank.</summary>
    public string? Notes { get; set; }

    /// <summary>Optionaler Verweis auf Status.</summary>
    public string? StatusId { get; set; }

    /// <summary>Unverändert als TEXT abgebildet, weil die produktive Datenbank diesen Datentyp verwendet.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation zum Status; die Beziehung wird per Fluent API konfiguriert.</summary>
    public Status? Status { get; set; }
}
