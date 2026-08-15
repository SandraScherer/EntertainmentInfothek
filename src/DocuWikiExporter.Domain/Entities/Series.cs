namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series".</summary>
public class Series : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalTitle".</summary>
    public string? OriginalTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDateFirstEpisode".</summary>
    public string? ReleaseDateFirstEpisode { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDateLastEpisode".</summary>
    public string? ReleaseDateLastEpisode { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NoOfSeasons".</summary>
    public string? NoOfSeasons { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NoOfEpisodes".</summary>
    public string? NoOfEpisodes { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Budget".</summary>
    public string? Budget { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WorldwideGross".</summary>
    public string? WorldwideGross { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WorldwideGrossDate".</summary>
    public string? WorldwideGrossDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CastStatusID".</summary>
    public string? CastStatusID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CrewStatusID".</summary>
    public string? CrewStatusID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ConnectionID".</summary>
    public string? ConnectionID { get; set; }

    /// <summary>Navigation über FK CastStatusID → Status.ID.</summary>
    public Status? StatusByCastStatusID { get; set; }

    /// <summary>Navigation über FK ConnectionID → Connection.ID.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation über FK CrewStatusID → Status.ID.</summary>
    public Status? StatusByCrewStatusID { get; set; }

    /// <summary>Navigation über FK TypeID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<Episode> EpisodeBySeriesID { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesAnimationDepartment> SeriesAnimationDepartmentBySeriesID { get; set; } = new List<SeriesAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesArtDepartment> SeriesArtDepartmentBySeriesID { get; set; } = new List<SeriesArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesArtDirection> SeriesArtDirectionBySeriesID { get; set; } = new List<SeriesArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatioBySeriesID { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesAssistantDirector> SeriesAssistantDirectorBySeriesID { get; set; } = new List<SeriesAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesAward> SeriesAwardBySeriesID { get; set; } = new List<SeriesAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCamera> SeriesCameraBySeriesID { get; set; } = new List<SeriesCamera>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCast> SeriesCastBySeriesID { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCasting> SeriesCastingBySeriesID { get; set; } = new List<SeriesCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCastingDepartment> SeriesCastingDepartmentBySeriesID { get; set; } = new List<SeriesCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCertification> SeriesCertificationBySeriesID { get; set; } = new List<SeriesCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcessBySeriesID { get; set; } = new List<SeriesCinematographicProcess>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCinematography> SeriesCinematographyBySeriesID { get; set; } = new List<SeriesCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesColor> SeriesColorBySeriesID { get; set; } = new List<SeriesColor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesContinuityDepartment> SeriesContinuityDepartmentBySeriesID { get; set; } = new List<SeriesContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCostumeDepartment> SeriesCostumeDepartmentBySeriesID { get; set; } = new List<SeriesCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCostumeDesign> SeriesCostumeDesignBySeriesID { get; set; } = new List<SeriesCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCountry> SeriesCountryBySeriesID { get; set; } = new List<SeriesCountry>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCover> SeriesCoverBySeriesID { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesCreator> SeriesCreatorBySeriesID { get; set; } = new List<SeriesCreator>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesDescription> SeriesDescriptionBySeriesID { get; set; } = new List<SeriesDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesDirector> SeriesDirectorBySeriesID { get; set; } = new List<SeriesDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesDistributor> SeriesDistributorBySeriesID { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesEditorialDepartment> SeriesEditorialDepartmentBySeriesID { get; set; } = new List<SeriesEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesElectricalDepartment> SeriesElectricalDepartmentBySeriesID { get; set; } = new List<SeriesElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesFilmEditing> SeriesFilmEditingBySeriesID { get; set; } = new List<SeriesFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesFilmLength> SeriesFilmLengthBySeriesID { get; set; } = new List<SeriesFilmLength>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesFilmingDate> SeriesFilmingDateBySeriesID { get; set; } = new List<SeriesFilmingDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocationBySeriesID { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesGenre> SeriesGenreBySeriesID { get; set; } = new List<SeriesGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesImage> SeriesImageBySeriesID { get; set; } = new List<SeriesImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratoryBySeriesID { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesLanguage> SeriesLanguageBySeriesID { get; set; } = new List<SeriesLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesLocationManagement> SeriesLocationManagementBySeriesID { get; set; } = new List<SeriesLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesLogo> SeriesLogoBySeriesID { get; set; } = new List<SeriesLogo>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesMakeupDepartment> SeriesMakeupDepartmentBySeriesID { get; set; } = new List<SeriesMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesMusic> SeriesMusicBySeriesID { get; set; } = new List<SeriesMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesMusicDepartment> SeriesMusicDepartmentBySeriesID { get; set; } = new List<SeriesMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormatBySeriesID { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesOtherCompany> SeriesOtherCompanyBySeriesID { get; set; } = new List<SeriesOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesOtherCrew> SeriesOtherCrewBySeriesID { get; set; } = new List<SeriesOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesPoster> SeriesPosterBySeriesID { get; set; } = new List<SeriesPoster>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormatBySeriesID { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesProducer> SeriesProducerBySeriesID { get; set; } = new List<SeriesProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesProductionCompany> SeriesProductionCompanyBySeriesID { get; set; } = new List<SeriesProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesProductionDate> SeriesProductionDateBySeriesID { get; set; } = new List<SeriesProductionDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesProductionDesign> SeriesProductionDesignBySeriesID { get; set; } = new List<SeriesProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesProductionManagement> SeriesProductionManagementBySeriesID { get; set; } = new List<SeriesProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesReview> SeriesReviewBySeriesID { get; set; } = new List<SeriesReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesRuntime> SeriesRuntimeBySeriesID { get; set; } = new List<SeriesRuntime>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesSetDecoration> SeriesSetDecorationBySeriesID { get; set; } = new List<SeriesSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesSoundDepartment> SeriesSoundDepartmentBySeriesID { get; set; } = new List<SeriesSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMixBySeriesID { get; set; } = new List<SeriesSoundMix>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesSpecialEffects> SeriesSpecialEffectsBySeriesID { get; set; } = new List<SeriesSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompanyBySeriesID { get; set; } = new List<SeriesSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesStunts> SeriesStuntsBySeriesID { get; set; } = new List<SeriesStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesThanks> SeriesThanksBySeriesID { get; set; } = new List<SeriesThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesTransportationDepartment> SeriesTransportationDepartmentBySeriesID { get; set; } = new List<SeriesTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesUser> SeriesUserBySeriesID { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesVisualEffects> SeriesVisualEffectsBySeriesID { get; set; } = new List<SeriesVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesWeblink> SeriesWeblinkBySeriesID { get; set; } = new List<SeriesWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series" verweisen.</summary>
    public ICollection<SeriesWriter> SeriesWriterBySeriesID { get; set; } = new List<SeriesWriter>();

}
