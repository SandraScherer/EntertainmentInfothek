namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Text".</summary>
public class Text : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Content".</summary>
    public string? Content { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "LanguageID".</summary>
    public string? LanguageID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Language" (FK LanguageID).</summary>
    public Language? Language { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_Description".</summary>
    public ICollection<SeriesDescription> SeriesDescription { get; set; } = new List<SeriesDescription>();

    /// <summary>Abhängige Datensätze aus "Series_Review".</summary>
    public ICollection<SeriesReview> SeriesReview { get; set; } = new List<SeriesReview>();

    /// <summary>Abhängige Datensätze aus "Episode_Review".</summary>
    public ICollection<EpisodeReview> EpisodeReview { get; set; } = new List<EpisodeReview>();

    /// <summary>Abhängige Datensätze aus "Movie_Description".</summary>
    public ICollection<MovieDescription> MovieDescription { get; set; } = new List<MovieDescription>();

    /// <summary>Abhängige Datensätze aus "Movie_Review".</summary>
    public ICollection<MovieReview> MovieReview { get; set; } = new List<MovieReview>();

    /// <summary>Abhängige Datensätze aus "Episode_Description".</summary>
    public ICollection<EpisodeDescription> EpisodeDescription { get; set; } = new List<EpisodeDescription>();

}
