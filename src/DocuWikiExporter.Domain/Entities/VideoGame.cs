namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame".</summary>
public class VideoGame : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalTitle".</summary>
    public string? OriginalTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LogoID".</summary>
    public string? LogoID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Budget".</summary>
    public string? Budget { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WorldwideGross".</summary>
    public string? WorldwideGross { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WorldwideGrossDate".</summary>
    public string? WorldwideGrossDate { get; set; }

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

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByVideoGameID { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameAward> VideoGameAwardByVideoGameID { get; set; } = new List<VideoGameAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameCast> VideoGameCastByVideoGameID { get; set; } = new List<VideoGameCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameCertification> VideoGameCertificationByVideoGameID { get; set; } = new List<VideoGameCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletionByVideoGameID { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameCover> VideoGameCoverByVideoGameID { get; set; } = new List<VideoGameCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameDescription> VideoGameDescriptionByVideoGameID { get; set; } = new List<VideoGameDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameDeveloper> VideoGameDeveloperByVideoGameID { get; set; } = new List<VideoGameDeveloper>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultyByVideoGameID { get; set; } = new List<VideoGameDifficulty>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameGenre> VideoGameGenreByVideoGameID { get; set; } = new List<VideoGameGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameImage> VideoGameImageByVideoGameID { get; set; } = new List<VideoGameImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameLanguage> VideoGameLanguageByVideoGameID { get; set; } = new List<VideoGameLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectiveByVideoGameID { get; set; } = new List<VideoGamePerspective>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGamePublisher> VideoGamePublisherByVideoGameID { get; set; } = new List<VideoGamePublisher>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameReleaseDate> VideoGameReleaseDateByVideoGameID { get; set; } = new List<VideoGameReleaseDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameReview> VideoGameReviewByVideoGameID { get; set; } = new List<VideoGameReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameScore> VideoGameScoreByVideoGameID { get; set; } = new List<VideoGameScore>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameSetting> VideoGameSettingByVideoGameID { get; set; } = new List<VideoGameSetting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameUser> VideoGameUserByVideoGameID { get; set; } = new List<VideoGameUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameVersion> VideoGameVersionByVideoGameID { get; set; } = new List<VideoGameVersion>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoGame" verweisen.</summary>
    public ICollection<VideoGameWeblink> VideoGameWeblinkByVideoGameID { get; set; } = new List<VideoGameWeblink>();

}
