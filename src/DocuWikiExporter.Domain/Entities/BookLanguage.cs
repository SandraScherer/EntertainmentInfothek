namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book_Language".</summary>
public class BookLanguage : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "BookID".</summary>
    public string? BookID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LanguageID".</summary>
    public string? LanguageID { get; set; }

    /// <summary>Navigation über FK BookID → Book.ID.</summary>
    public Book? Book { get; set; }

    /// <summary>Navigation über FK LanguageID → Language.ID.</summary>
    public Language? Language { get; set; }

}
