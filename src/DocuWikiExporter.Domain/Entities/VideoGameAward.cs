namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Award".</summary>
public class VideoGameAward : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AwardID".</summary>
    public string? AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Category".</summary>
    public string? Category { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Year".</summary>
    public string? Year { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Winner".</summary>
    public long? Winner { get; set; }

    /// <summary>Navigation über FK AwardID → Award.ID.</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
