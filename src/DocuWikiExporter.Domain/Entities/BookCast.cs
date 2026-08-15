namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book_Cast".</summary>
public class BookCast : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "BookID".</summary>
    public string? BookID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Character".</summary>
    public string? Character { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CharacterID".</summary>
    public string? CharacterID { get; set; }

    /// <summary>Navigation über FK BookID → Book.ID.</summary>
    public Book? Book { get; set; }

    /// <summary>Navigation über FK CharacterID → Person.ID.</summary>
    public Person? Person { get; set; }

}
