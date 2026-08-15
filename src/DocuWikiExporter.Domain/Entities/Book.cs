namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book".</summary>
public class Book : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalTitle".</summary>
    public string? OriginalTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LogoID".</summary>
    public string? LogoID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CastStatusID".</summary>
    public string? CastStatusID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ConnectionID".</summary>
    public string? ConnectionID { get; set; }

    /// <summary>Navigation über FK CastStatusID → Status.ID.</summary>
    public Status? StatusByCastStatusID { get; set; }

    /// <summary>Navigation über FK ConnectionID → Connection.ID.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation über FK LogoID → Image.ID.</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation über FK TypeID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookAward> BookAwardByBookID { get; set; } = new List<BookAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookCast> BookCastByBookID { get; set; } = new List<BookCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookCover> BookCoverByBookID { get; set; } = new List<BookCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookDescription> BookDescriptionByBookID { get; set; } = new List<BookDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookGenre> BookGenreByBookID { get; set; } = new List<BookGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookLanguage> BookLanguageByBookID { get; set; } = new List<BookLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookPublication> BookPublicationByBookID { get; set; } = new List<BookPublication>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookReview> BookReviewByBookID { get; set; } = new List<BookReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookUser> BookUserByBookID { get; set; } = new List<BookUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookWeblink> BookWeblinkByBookID { get; set; } = new List<BookWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Book" verweisen.</summary>
    public ICollection<BookWriter> BookWriterByBookID { get; set; } = new List<BookWriter>();

}
