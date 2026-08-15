namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Platform".</summary>
public class Platform : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Title".</summary>
    public string? Title { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByPlatformID { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<Version> VersionByPlatformID { get; set; } = new List<Version>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGameDeveloper> VideoGameDeveloperByPlatformID { get; set; } = new List<VideoGameDeveloper>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultyByPlatformID { get; set; } = new List<VideoGameDifficulty>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGameDistributor> VideoGameDistributorByPlatformID { get; set; } = new List<VideoGameDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectiveByPlatformID { get; set; } = new List<VideoGamePerspective>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGamePublisher> VideoGamePublisherByPlatformID { get; set; } = new List<VideoGamePublisher>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGameReleaseDate> VideoGameReleaseDateByPlatformID { get; set; } = new List<VideoGameReleaseDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Platform" verweisen.</summary>
    public ICollection<VideoGameScore> VideoGameScoreByPlatformID { get; set; } = new List<VideoGameScore>();

}
