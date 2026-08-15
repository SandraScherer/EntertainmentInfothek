namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book_Genre".</summary>
public class BookGenre : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "BookID".</summary>
    public string? BookID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GenreID".</summary>
    public string? GenreID { get; set; }

    /// <summary>Navigation über FK BookID → Book.ID.</summary>
    public Book? Book { get; set; }

    /// <summary>Navigation über FK GenreID → Genre.ID.</summary>
    public Genre? Genre { get; set; }

}
