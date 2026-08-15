namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book_Description".</summary>
public class BookDescription : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "BookID".</summary>
    public string? BookID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TextID".</summary>
    public string? TextID { get; set; }

    /// <summary>Navigation über FK BookID → Book.ID.</summary>
    public Book? Book { get; set; }

    /// <summary>Navigation über FK TextID → Text.ID.</summary>
    public Text? Text { get; set; }

}
