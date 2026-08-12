namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK CastStatusID).</summary>
    public Status? CastStatus { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Connection" (FK ConnectionID).</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK CrewStatusID).</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Type" (FK TypeID).</summary>
    public Type? Type { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_OtherCompany".</summary>
    public ICollection<SeriesOtherCompany> SeriesOtherCompany { get; set; } = new List<SeriesOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Episode".</summary>
    public ICollection<Episode> Episode { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze aus "Series_Logo".</summary>
    public ICollection<SeriesLogo> SeriesLogo { get; set; } = new List<SeriesLogo>();

    /// <summary>Abhängige Datensätze aus "Series_Casting".</summary>
    public ICollection<SeriesCasting> SeriesCasting { get; set; } = new List<SeriesCasting>();

    /// <summary>Abhängige Datensätze aus "Series_Description".</summary>
    public ICollection<SeriesDescription> SeriesDescription { get; set; } = new List<SeriesDescription>();

    /// <summary>Abhängige Datensätze aus "Series_FilmingLocation".</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocation { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Series_ArtDepartment".</summary>
    public ICollection<SeriesArtDepartment> SeriesArtDepartment { get; set; } = new List<SeriesArtDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Stunts".</summary>
    public ICollection<SeriesStunts> SeriesStunts { get; set; } = new List<SeriesStunts>();

    /// <summary>Abhängige Datensätze aus "Series_Camera".</summary>
    public ICollection<SeriesCamera> SeriesCamera { get; set; } = new List<SeriesCamera>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionDesign".</summary>
    public ICollection<SeriesProductionDesign> SeriesProductionDesign { get; set; } = new List<SeriesProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Series_FilmEditing".</summary>
    public ICollection<SeriesFilmEditing> SeriesFilmEditing { get; set; } = new List<SeriesFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Series_Creator".</summary>
    public ICollection<SeriesCreator> SeriesCreator { get; set; } = new List<SeriesCreator>();

    /// <summary>Abhängige Datensätze aus "Series_AspectRatio".</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatio { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Abhängige Datensätze aus "Series_TransportationDepartment".</summary>
    public ICollection<SeriesTransportationDepartment> SeriesTransportationDepartment { get; set; } = new List<SeriesTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Image".</summary>
    public ICollection<SeriesImage> SeriesImage { get; set; } = new List<SeriesImage>();

    /// <summary>Abhängige Datensätze aus "Series_Certification".</summary>
    public ICollection<SeriesCertification> SeriesCertification { get; set; } = new List<SeriesCertification>();

    /// <summary>Abhängige Datensätze aus "Series_CostumeDesign".</summary>
    public ICollection<SeriesCostumeDesign> SeriesCostumeDesign { get; set; } = new List<SeriesCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionDate".</summary>
    public ICollection<SeriesProductionDate> SeriesProductionDate { get; set; } = new List<SeriesProductionDate>();

    /// <summary>Abhängige Datensätze aus "Series_Writer".</summary>
    public ICollection<SeriesWriter> SeriesWriter { get; set; } = new List<SeriesWriter>();

    /// <summary>Abhängige Datensätze aus "Series_AnimationDepartment".</summary>
    public ICollection<SeriesAnimationDepartment> SeriesAnimationDepartment { get; set; } = new List<SeriesAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_User".</summary>
    public ICollection<SeriesUser> SeriesUser { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze aus "Series_Laboratory".</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratory { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Abhängige Datensätze aus "Series_Director".</summary>
    public ICollection<SeriesDirector> SeriesDirector { get; set; } = new List<SeriesDirector>();

    /// <summary>Abhängige Datensätze aus "Series_Producer".</summary>
    public ICollection<SeriesProducer> SeriesProducer { get; set; } = new List<SeriesProducer>();

    /// <summary>Abhängige Datensätze aus "Series_Genre".</summary>
    public ICollection<SeriesGenre> SeriesGenre { get; set; } = new List<SeriesGenre>();

    /// <summary>Abhängige Datensätze aus "Series_Language".</summary>
    public ICollection<SeriesLanguage> SeriesLanguage { get; set; } = new List<SeriesLanguage>();

    /// <summary>Abhängige Datensätze aus "Series_Music".</summary>
    public ICollection<SeriesMusic> SeriesMusic { get; set; } = new List<SeriesMusic>();

    /// <summary>Abhängige Datensätze aus "Series_EditorialDepartment".</summary>
    public ICollection<SeriesEditorialDepartment> SeriesEditorialDepartment { get; set; } = new List<SeriesEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Poster".</summary>
    public ICollection<SeriesPoster> SeriesPoster { get; set; } = new List<SeriesPoster>();

    /// <summary>Abhängige Datensätze aus "Series_FilmLength".</summary>
    public ICollection<SeriesFilmLength> SeriesFilmLength { get; set; } = new List<SeriesFilmLength>();

    /// <summary>Abhängige Datensätze aus "Series_Color".</summary>
    public ICollection<SeriesColor> SeriesColor { get; set; } = new List<SeriesColor>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionManagement".</summary>
    public ICollection<SeriesProductionManagement> SeriesProductionManagement { get; set; } = new List<SeriesProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Series_SoundMix".</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMix { get; set; } = new List<SeriesSoundMix>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionCompany".</summary>
    public ICollection<SeriesProductionCompany> SeriesProductionCompany { get; set; } = new List<SeriesProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Series_FilmingDate".</summary>
    public ICollection<SeriesFilmingDate> SeriesFilmingDate { get; set; } = new List<SeriesFilmingDate>();

    /// <summary>Abhängige Datensätze aus "Series_SoundDepartment".</summary>
    public ICollection<SeriesSoundDepartment> SeriesSoundDepartment { get; set; } = new List<SeriesSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_CastingDepartment".</summary>
    public ICollection<SeriesCastingDepartment> SeriesCastingDepartment { get; set; } = new List<SeriesCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Distributor".</summary>
    public ICollection<SeriesDistributor> SeriesDistributor { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze aus "Series_LocationManagement".</summary>
    public ICollection<SeriesLocationManagement> SeriesLocationManagement { get; set; } = new List<SeriesLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Series_NegativeFormat".</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormat { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Abhängige Datensätze aus "Series_SetDecoration".</summary>
    public ICollection<SeriesSetDecoration> SeriesSetDecoration { get; set; } = new List<SeriesSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Series_Review".</summary>
    public ICollection<SeriesReview> SeriesReview { get; set; } = new List<SeriesReview>();

    /// <summary>Abhängige Datensätze aus "Series_ElectricalDepartment".</summary>
    public ICollection<SeriesElectricalDepartment> SeriesElectricalDepartment { get; set; } = new List<SeriesElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_MakeupDepartment".</summary>
    public ICollection<SeriesMakeupDepartment> SeriesMakeupDepartment { get; set; } = new List<SeriesMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_SpecialEffects".</summary>
    public ICollection<SeriesSpecialEffects> SeriesSpecialEffects { get; set; } = new List<SeriesSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Series_Cover".</summary>
    public ICollection<SeriesCover> SeriesCover { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze aus "Series_ContinuityDepartment".</summary>
    public ICollection<SeriesContinuityDepartment> SeriesContinuityDepartment { get; set; } = new List<SeriesContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Award".</summary>
    public ICollection<SeriesAward> SeriesAward { get; set; } = new List<SeriesAward>();

    /// <summary>Abhängige Datensätze aus "Series_SpecialEffectsCompany".</summary>
    public ICollection<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompany { get; set; } = new List<SeriesSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Series_VisualEffects".</summary>
    public ICollection<SeriesVisualEffects> SeriesVisualEffects { get; set; } = new List<SeriesVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Series_AssistantDirector".</summary>
    public ICollection<SeriesAssistantDirector> SeriesAssistantDirector { get; set; } = new List<SeriesAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Series_Weblink".</summary>
    public ICollection<SeriesWeblink> SeriesWeblink { get; set; } = new List<SeriesWeblink>();

    /// <summary>Abhängige Datensätze aus "Series_Thanks".</summary>
    public ICollection<SeriesThanks> SeriesThanks { get; set; } = new List<SeriesThanks>();

    /// <summary>Abhängige Datensätze aus "Series_Country".</summary>
    public ICollection<SeriesCountry> SeriesCountry { get; set; } = new List<SeriesCountry>();

    /// <summary>Abhängige Datensätze aus "Series_ArtDirection".</summary>
    public ICollection<SeriesArtDirection> SeriesArtDirection { get; set; } = new List<SeriesArtDirection>();

    /// <summary>Abhängige Datensätze aus "Series_PrintedFilmFormat".</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormat { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Abhängige Datensätze aus "Series_OtherCrew".</summary>
    public ICollection<SeriesOtherCrew> SeriesOtherCrew { get; set; } = new List<SeriesOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Series_Cinematography".</summary>
    public ICollection<SeriesCinematography> SeriesCinematography { get; set; } = new List<SeriesCinematography>();

    /// <summary>Abhängige Datensätze aus "Series_Runtime".</summary>
    public ICollection<SeriesRuntime> SeriesRuntime { get; set; } = new List<SeriesRuntime>();

    /// <summary>Abhängige Datensätze aus "Series_Cast".</summary>
    public ICollection<SeriesCast> SeriesCast { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze aus "Series_CinematographicProcess".</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcess { get; set; } = new List<SeriesCinematographicProcess>();

    /// <summary>Abhängige Datensätze aus "Series_CostumeDepartment".</summary>
    public ICollection<SeriesCostumeDepartment> SeriesCostumeDepartment { get; set; } = new List<SeriesCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_MusicDepartment".</summary>
    public ICollection<SeriesMusicDepartment> SeriesMusicDepartment { get; set; } = new List<SeriesMusicDepartment>();

}
