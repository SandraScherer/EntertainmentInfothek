namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Image".</summary>
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

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation über FK TypeID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<Book> BookByLogoID { get; set; } = new List<Book>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<BookCover> BookCoverByImageID { get; set; } = new List<BookCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<Certification> CertificationByImageID { get; set; } = new List<Certification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<EpisodeImage> EpisodeImageByImageID { get; set; } = new List<EpisodeImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<ImageSource> ImageSourceByImageID { get; set; } = new List<ImageSource>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<Movie> MovieByLogoID { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<MovieCover> MovieCoverByImageID { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<MovieImage> MovieImageByImageID { get; set; } = new List<MovieImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<MoviePoster> MoviePosterByImageID { get; set; } = new List<MoviePoster>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<SeriesCover> SeriesCoverByImageID { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<SeriesImage> SeriesImageByImageID { get; set; } = new List<SeriesImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<SeriesLogo> SeriesLogoByImageID { get; set; } = new List<SeriesLogo>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<SeriesPoster> SeriesPosterByImageID { get; set; } = new List<SeriesPoster>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<VideoGame> VideoGameByLogoID { get; set; } = new List<VideoGame>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<VideoGameCover> VideoGameCoverByImageID { get; set; } = new List<VideoGameCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Image" verweisen.</summary>
    public ICollection<VideoGameImage> VideoGameImageByImageID { get; set; } = new List<VideoGameImage>();

}
