namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode".</summary>
public class Episode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalTitle".</summary>
    public string? OriginalTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SeasonNo".</summary>
    public string? SeasonNo { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EpisodeNo".</summary>
    public string? EpisodeNo { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CastStatusID".</summary>
    public string? CastStatusID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CrewStatusID".</summary>
    public string? CrewStatusID { get; set; }

    /// <summary>Navigation über FK CastStatusID → Status.ID.</summary>
    public Status? StatusByCastStatusID { get; set; }

    /// <summary>Navigation über FK CrewStatusID → Status.ID.</summary>
    public Status? StatusByCrewStatusID { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeAnimationDepartment> EpisodeAnimationDepartmentByEpisodeID { get; set; } = new List<EpisodeAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeArtDepartment> EpisodeArtDepartmentByEpisodeID { get; set; } = new List<EpisodeArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeArtDirection> EpisodeArtDirectionByEpisodeID { get; set; } = new List<EpisodeArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeAssistantDirector> EpisodeAssistantDirectorByEpisodeID { get; set; } = new List<EpisodeAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeAward> EpisodeAwardByEpisodeID { get; set; } = new List<EpisodeAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeCast> EpisodeCastByEpisodeID { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeCasting> EpisodeCastingByEpisodeID { get; set; } = new List<EpisodeCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeCastingDepartment> EpisodeCastingDepartmentByEpisodeID { get; set; } = new List<EpisodeCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeCinematography> EpisodeCinematographyByEpisodeID { get; set; } = new List<EpisodeCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeContinuityDepartment> EpisodeContinuityDepartmentByEpisodeID { get; set; } = new List<EpisodeContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeCostumeDepartment> EpisodeCostumeDepartmentByEpisodeID { get; set; } = new List<EpisodeCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeCostumeDesign> EpisodeCostumeDesignByEpisodeID { get; set; } = new List<EpisodeCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeDescription> EpisodeDescriptionByEpisodeID { get; set; } = new List<EpisodeDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeDirector> EpisodeDirectorByEpisodeID { get; set; } = new List<EpisodeDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributorByEpisodeID { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeEditorialDepartment> EpisodeEditorialDepartmentByEpisodeID { get; set; } = new List<EpisodeEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeElectricalDepartment> EpisodeElectricalDepartmentByEpisodeID { get; set; } = new List<EpisodeElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeFilmEditing> EpisodeFilmEditingByEpisodeID { get; set; } = new List<EpisodeFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeFilmingDate> EpisodeFilmingDateByEpisodeID { get; set; } = new List<EpisodeFilmingDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocationByEpisodeID { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeImage> EpisodeImageByEpisodeID { get; set; } = new List<EpisodeImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeLocationManagement> EpisodeLocationManagementByEpisodeID { get; set; } = new List<EpisodeLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeMakeupDepartment> EpisodeMakeupDepartmentByEpisodeID { get; set; } = new List<EpisodeMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeMusic> EpisodeMusicByEpisodeID { get; set; } = new List<EpisodeMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeMusicDepartment> EpisodeMusicDepartmentByEpisodeID { get; set; } = new List<EpisodeMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeOtherCompany> EpisodeOtherCompanyByEpisodeID { get; set; } = new List<EpisodeOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeOtherCrew> EpisodeOtherCrewByEpisodeID { get; set; } = new List<EpisodeOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeProducer> EpisodeProducerByEpisodeID { get; set; } = new List<EpisodeProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeProductionCompany> EpisodeProductionCompanyByEpisodeID { get; set; } = new List<EpisodeProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeProductionDate> EpisodeProductionDateByEpisodeID { get; set; } = new List<EpisodeProductionDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeProductionDesign> EpisodeProductionDesignByEpisodeID { get; set; } = new List<EpisodeProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeProductionManagement> EpisodeProductionManagementByEpisodeID { get; set; } = new List<EpisodeProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeReview> EpisodeReviewByEpisodeID { get; set; } = new List<EpisodeReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeSetDecoration> EpisodeSetDecorationByEpisodeID { get; set; } = new List<EpisodeSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeSoundDepartment> EpisodeSoundDepartmentByEpisodeID { get; set; } = new List<EpisodeSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeSpecialEffects> EpisodeSpecialEffectsByEpisodeID { get; set; } = new List<EpisodeSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompanyByEpisodeID { get; set; } = new List<EpisodeSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeStunts> EpisodeStuntsByEpisodeID { get; set; } = new List<EpisodeStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeThanks> EpisodeThanksByEpisodeID { get; set; } = new List<EpisodeThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeTransportationDepartment> EpisodeTransportationDepartmentByEpisodeID { get; set; } = new List<EpisodeTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeVisualEffects> EpisodeVisualEffectsByEpisodeID { get; set; } = new List<EpisodeVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode" verweisen.</summary>
    public ICollection<EpisodeWriter> EpisodeWriterByEpisodeID { get; set; } = new List<EpisodeWriter>();

}
