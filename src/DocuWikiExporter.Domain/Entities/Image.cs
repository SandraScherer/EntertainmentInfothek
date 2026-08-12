namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Image".</summary>
public class Image : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "FileName".</summary>
    public string? FileName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Description".</summary>
    public string? Description { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Country" (FK CountryID).</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Type" (FK TypeID).</summary>
    public Type? Type { get; set; }


    /// <summary>Abhängige Datensätze aus "Certification".</summary>
    public ICollection<Certification> Certification { get; set; } = new List<Certification>();

    /// <summary>Abhängige Datensätze aus "Series_Logo".</summary>
    public ICollection<SeriesLogo> SeriesLogo { get; set; } = new List<SeriesLogo>();

    /// <summary>Abhängige Datensätze aus "Movie".</summary>
    public ICollection<Movie> Movie { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze aus "Series_Image".</summary>
    public ICollection<SeriesImage> SeriesImage { get; set; } = new List<SeriesImage>();

    /// <summary>Abhängige Datensätze aus "Movie_Image".</summary>
    public ICollection<MovieImage> MovieImage { get; set; } = new List<MovieImage>();

    /// <summary>Abhängige Datensätze aus "Episode_Image".</summary>
    public ICollection<EpisodeImage> EpisodeImage { get; set; } = new List<EpisodeImage>();

    /// <summary>Abhängige Datensätze aus "Series_Poster".</summary>
    public ICollection<SeriesPoster> SeriesPoster { get; set; } = new List<SeriesPoster>();

    /// <summary>Abhängige Datensätze aus "Series_Cover".</summary>
    public ICollection<SeriesCover> SeriesCover { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze aus "Movie_Poster".</summary>
    public ICollection<MoviePoster> MoviePoster { get; set; } = new List<MoviePoster>();

    /// <summary>Abhängige Datensätze aus "Movie_Cover".</summary>
    public ICollection<MovieCover> MovieCover { get; set; } = new List<MovieCover>();

}
