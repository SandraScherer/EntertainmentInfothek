namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie".</summary>
public class Movie : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalTitle".</summary>
    public string? OriginalTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }
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

    /// <summary>Navigation zur referenzierten Tabelle "Image" (FK LogoID).</summary>
    public Image? Logo { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Type" (FK TypeID).</summary>
    public Type? Type { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_CostumeDepartment".</summary>
    public ICollection<MovieCostumeDepartment> MovieCostumeDepartment { get; set; } = new List<MovieCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Producer".</summary>
    public ICollection<MovieProducer> MovieProducer { get; set; } = new List<MovieProducer>();

    /// <summary>Abhängige Datensätze aus "Movie_Cast".</summary>
    public ICollection<MovieCast> MovieCast { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze aus "Movie_ArtDirection".</summary>
    public ICollection<MovieArtDirection> MovieArtDirection { get; set; } = new List<MovieArtDirection>();

    /// <summary>Abhängige Datensätze aus "Movie_MusicDepartment".</summary>
    public ICollection<MovieMusicDepartment> MovieMusicDepartment { get; set; } = new List<MovieMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmingDate".</summary>
    public ICollection<MovieFilmingDate> MovieFilmingDate { get; set; } = new List<MovieFilmingDate>();

    /// <summary>Abhängige Datensätze aus "Movie_SpecialEffects".</summary>
    public ICollection<MovieSpecialEffects> MovieSpecialEffects { get; set; } = new List<MovieSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Movie_OtherCompany".</summary>
    public ICollection<MovieOtherCompany> MovieOtherCompany { get; set; } = new List<MovieOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_PrintedFilmFormat".</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormat { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmingLocation".</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocation { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Movie_Cinematography".</summary>
    public ICollection<MovieCinematography> MovieCinematography { get; set; } = new List<MovieCinematography>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionDate".</summary>
    public ICollection<MovieProductionDate> MovieProductionDate { get; set; } = new List<MovieProductionDate>();

    /// <summary>Abhängige Datensätze aus "Movie_Image".</summary>
    public ICollection<MovieImage> MovieImage { get; set; } = new List<MovieImage>();

    /// <summary>Abhängige Datensätze aus "Movie_CostumeDesign".</summary>
    public ICollection<MovieCostumeDesign> MovieCostumeDesign { get; set; } = new List<MovieCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Movie_SoundDepartment".</summary>
    public ICollection<MovieSoundDepartment> MovieSoundDepartment { get; set; } = new List<MovieSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Country".</summary>
    public ICollection<MovieCountry> MovieCountry { get; set; } = new List<MovieCountry>();

    /// <summary>Abhängige Datensätze aus "Movie_Genre".</summary>
    public ICollection<MovieGenre> MovieGenre { get; set; } = new List<MovieGenre>();

    /// <summary>Abhängige Datensätze aus "Movie_CinematographicProcess".</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcess { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Abhängige Datensätze aus "Movie_OtherCrew".</summary>
    public ICollection<MovieOtherCrew> MovieOtherCrew { get; set; } = new List<MovieOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Movie_ContinuityDepartment".</summary>
    public ICollection<MovieContinuityDepartment> MovieContinuityDepartment { get; set; } = new List<MovieContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_SetDecoration".</summary>
    public ICollection<MovieSetDecoration> MovieSetDecoration { get; set; } = new List<MovieSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Movie_CastingDepartment".</summary>
    public ICollection<MovieCastingDepartment> MovieCastingDepartment { get; set; } = new List<MovieCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_MakeupDepartment".</summary>
    public ICollection<MovieMakeupDepartment> MovieMakeupDepartment { get; set; } = new List<MovieMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Award".</summary>
    public ICollection<MovieAward> MovieAward { get; set; } = new List<MovieAward>();

    /// <summary>Abhängige Datensätze aus "Movie_Weblink".</summary>
    public ICollection<MovieWeblink> MovieWeblink { get; set; } = new List<MovieWeblink>();

    /// <summary>Abhängige Datensätze aus "Movie_Distributor".</summary>
    public ICollection<MovieDistributor> MovieDistributor { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmLength".</summary>
    public ICollection<MovieFilmLength> MovieFilmLength { get; set; } = new List<MovieFilmLength>();

    /// <summary>Abhängige Datensätze aus "Movie_Laboratory".</summary>
    public ICollection<MovieLaboratory> MovieLaboratory { get; set; } = new List<MovieLaboratory>();

    /// <summary>Abhängige Datensätze aus "Movie_TransportationDepartment".</summary>
    public ICollection<MovieTransportationDepartment> MovieTransportationDepartment { get; set; } = new List<MovieTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_AnimationDepartment".</summary>
    public ICollection<MovieAnimationDepartment> MovieAnimationDepartment { get; set; } = new List<MovieAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_SoundMix".</summary>
    public ICollection<MovieSoundMix> MovieSoundMix { get; set; } = new List<MovieSoundMix>();

    /// <summary>Abhängige Datensätze aus "Movie_User".</summary>
    public ICollection<MovieUser> MovieUser { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze aus "Movie_LocationManagement".</summary>
    public ICollection<MovieLocationManagement> MovieLocationManagement { get; set; } = new List<MovieLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Movie_AspectRatio".</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatio { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Abhängige Datensätze aus "Movie_EditorialDepartment".</summary>
    public ICollection<MovieEditorialDepartment> MovieEditorialDepartment { get; set; } = new List<MovieEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmEditing".</summary>
    public ICollection<MovieFilmEditing> MovieFilmEditing { get; set; } = new List<MovieFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Movie_Color".</summary>
    public ICollection<MovieColor> MovieColor { get; set; } = new List<MovieColor>();

    /// <summary>Abhängige Datensätze aus "Movie_Description".</summary>
    public ICollection<MovieDescription> MovieDescription { get; set; } = new List<MovieDescription>();

    /// <summary>Abhängige Datensätze aus "Movie_AssistantDirector".</summary>
    public ICollection<MovieAssistantDirector> MovieAssistantDirector { get; set; } = new List<MovieAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Movie_Camera".</summary>
    public ICollection<MovieCamera> MovieCamera { get; set; } = new List<MovieCamera>();

    /// <summary>Abhängige Datensätze aus "Movie_Poster".</summary>
    public ICollection<MoviePoster> MoviePoster { get; set; } = new List<MoviePoster>();

    /// <summary>Abhängige Datensätze aus "Movie_Director".</summary>
    public ICollection<MovieDirector> MovieDirector { get; set; } = new List<MovieDirector>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionManagement".</summary>
    public ICollection<MovieProductionManagement> MovieProductionManagement { get; set; } = new List<MovieProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Movie_SpecialEffectsCompany".</summary>
    public ICollection<MovieSpecialEffectsCompany> MovieSpecialEffectsCompany { get; set; } = new List<MovieSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_Writer".</summary>
    public ICollection<MovieWriter> MovieWriter { get; set; } = new List<MovieWriter>();

    /// <summary>Abhängige Datensätze aus "Movie_Cover".</summary>
    public ICollection<MovieCover> MovieCover { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionCompany".</summary>
    public ICollection<MovieProductionCompany> MovieProductionCompany { get; set; } = new List<MovieProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionDesign".</summary>
    public ICollection<MovieProductionDesign> MovieProductionDesign { get; set; } = new List<MovieProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Movie_Casting".</summary>
    public ICollection<MovieCasting> MovieCasting { get; set; } = new List<MovieCasting>();

    /// <summary>Abhängige Datensätze aus "Movie_Language".</summary>
    public ICollection<MovieLanguage> MovieLanguage { get; set; } = new List<MovieLanguage>();

    /// <summary>Abhängige Datensätze aus "Movie_Certification".</summary>
    public ICollection<MovieCertification> MovieCertification { get; set; } = new List<MovieCertification>();

    /// <summary>Abhängige Datensätze aus "Movie_VisualEffects".</summary>
    public ICollection<MovieVisualEffects> MovieVisualEffects { get; set; } = new List<MovieVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Movie_Review".</summary>
    public ICollection<MovieReview> MovieReview { get; set; } = new List<MovieReview>();

    /// <summary>Abhängige Datensätze aus "Movie_Thanks".</summary>
    public ICollection<MovieThanks> MovieThanks { get; set; } = new List<MovieThanks>();

    /// <summary>Abhängige Datensätze aus "Movie_NegativeFormat".</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormat { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Abhängige Datensätze aus "Movie_ElectricalDepartment".</summary>
    public ICollection<MovieElectricalDepartment> MovieElectricalDepartment { get; set; } = new List<MovieElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Stunts".</summary>
    public ICollection<MovieStunts> MovieStunts { get; set; } = new List<MovieStunts>();

    /// <summary>Abhängige Datensätze aus "Movie_Runtime".</summary>
    public ICollection<MovieRuntime> MovieRuntime { get; set; } = new List<MovieRuntime>();

    /// <summary>Abhängige Datensätze aus "Movie_Music".</summary>
    public ICollection<MovieMusic> MovieMusic { get; set; } = new List<MovieMusic>();

    /// <summary>Abhängige Datensätze aus "Movie_ArtDepartment".</summary>
    public ICollection<MovieArtDepartment> MovieArtDepartment { get; set; } = new List<MovieArtDepartment>();

}
