namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Text_Author".</summary>
public class TextAuthor : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TextID".</summary>
    public string? TextID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation über FK TextID → Text.ID.</summary>
    public Text? Text { get; set; }

}
