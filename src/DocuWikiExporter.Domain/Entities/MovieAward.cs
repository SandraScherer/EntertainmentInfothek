namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Award".</summary>
public class MovieAward : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AwardID".</summary>
    public string? AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Category".</summary>
    public string? Category { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Date".</summary>
    public string? Date { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Winner".</summary>
    public long? Winner { get; set; }

    /// <summary>Navigation über FK AwardID → Award.ID.</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie_Award" verweisen.</summary>
    public ICollection<MovieAwardPerson> MovieAwardPersonByMovie_AwardID { get; set; } = new List<MovieAwardPerson>();

}
