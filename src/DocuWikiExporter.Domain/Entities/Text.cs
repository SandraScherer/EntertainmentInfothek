namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Text".</summary>
public class Text : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Content".</summary>
    public string? Content { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LanguageID".</summary>
    public string? LanguageID { get; set; }

    /// <summary>Navigation über FK LanguageID → Language.ID.</summary>
    public Language? Language { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<BookDescription> BookDescriptionByTextID { get; set; } = new List<BookDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<BookReview> BookReviewByTextID { get; set; } = new List<BookReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<EpisodeDescription> EpisodeDescriptionByTextID { get; set; } = new List<EpisodeDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<EpisodeReview> EpisodeReviewByTextID { get; set; } = new List<EpisodeReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<MovieDescription> MovieDescriptionByTextID { get; set; } = new List<MovieDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<MovieReview> MovieReviewByTextID { get; set; } = new List<MovieReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<SeriesDescription> SeriesDescriptionByTextID { get; set; } = new List<SeriesDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<SeriesReview> SeriesReviewByTextID { get; set; } = new List<SeriesReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<TextAuthor> TextAuthorByTextID { get; set; } = new List<TextAuthor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<TextSource> TextSourceByTextID { get; set; } = new List<TextSource>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<VideoGameDescription> VideoGameDescriptionByTextID { get; set; } = new List<VideoGameDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Text" verweisen.</summary>
    public ICollection<VideoGameReview> VideoGameReviewByTextID { get; set; } = new List<VideoGameReview>();

}
