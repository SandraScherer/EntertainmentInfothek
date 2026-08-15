namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Edition".</summary>
public class Edition : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<MovieCover> MovieCoverByEditionID { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<MovieRuntime> MovieRuntimeByEditionID { get; set; } = new List<MovieRuntime>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<MovieUser> MovieUserByEditionID { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<Publication> PublicationByEditionID { get; set; } = new List<Publication>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<SeriesCover> SeriesCoverByEditionID { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<SeriesRuntime> SeriesRuntimeByEditionID { get; set; } = new List<SeriesRuntime>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<SeriesUser> SeriesUserByEditionID { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Edition" verweisen.</summary>
    public ICollection<VideoGameUser> VideoGameUserByEditionID { get; set; } = new List<VideoGameUser>();

}
