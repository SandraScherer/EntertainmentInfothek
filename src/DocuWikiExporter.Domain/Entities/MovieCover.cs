namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Cover".</summary>
public class MovieCover : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ImageID".</summary>
    public string? ImageID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EditionID".</summary>
    public string? EditionID { get; set; }

    /// <summary>Navigation über FK EditionID → Edition.ID.</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation über FK ImageID → Image.ID.</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
