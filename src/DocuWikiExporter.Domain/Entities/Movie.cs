namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie".</summary>
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

    /// <summary>Navigation über FK CastStatusID → Status.ID.</summary>
    public Status? StatusByCastStatusID { get; set; }

    /// <summary>Navigation über FK ConnectionID → Connection.ID.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation über FK CrewStatusID → Status.ID.</summary>
    public Status? StatusByCrewStatusID { get; set; }

    /// <summary>Navigation über FK LogoID → Image.ID.</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation über FK TypeID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieAnimationDepartment> MovieAnimationDepartmentByMovieID { get; set; } = new List<MovieAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieArtDepartment> MovieArtDepartmentByMovieID { get; set; } = new List<MovieArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieArtDirection> MovieArtDirectionByMovieID { get; set; } = new List<MovieArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatioByMovieID { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieAssistantDirector> MovieAssistantDirectorByMovieID { get; set; } = new List<MovieAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieAward> MovieAwardByMovieID { get; set; } = new List<MovieAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCamera> MovieCameraByMovieID { get; set; } = new List<MovieCamera>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCast> MovieCastByMovieID { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCasting> MovieCastingByMovieID { get; set; } = new List<MovieCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCastingDepartment> MovieCastingDepartmentByMovieID { get; set; } = new List<MovieCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCertification> MovieCertificationByMovieID { get; set; } = new List<MovieCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcessByMovieID { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCinematography> MovieCinematographyByMovieID { get; set; } = new List<MovieCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieColor> MovieColorByMovieID { get; set; } = new List<MovieColor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieContinuityDepartment> MovieContinuityDepartmentByMovieID { get; set; } = new List<MovieContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCostumeDepartment> MovieCostumeDepartmentByMovieID { get; set; } = new List<MovieCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCostumeDesign> MovieCostumeDesignByMovieID { get; set; } = new List<MovieCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCountry> MovieCountryByMovieID { get; set; } = new List<MovieCountry>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieCover> MovieCoverByMovieID { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieDescription> MovieDescriptionByMovieID { get; set; } = new List<MovieDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieDirector> MovieDirectorByMovieID { get; set; } = new List<MovieDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieDistributor> MovieDistributorByMovieID { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieEditorialDepartment> MovieEditorialDepartmentByMovieID { get; set; } = new List<MovieEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieElectricalDepartment> MovieElectricalDepartmentByMovieID { get; set; } = new List<MovieElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieFilmEditing> MovieFilmEditingByMovieID { get; set; } = new List<MovieFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieFilmLength> MovieFilmLengthByMovieID { get; set; } = new List<MovieFilmLength>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieFilmingDate> MovieFilmingDateByMovieID { get; set; } = new List<MovieFilmingDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocationByMovieID { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieGenre> MovieGenreByMovieID { get; set; } = new List<MovieGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieImage> MovieImageByMovieID { get; set; } = new List<MovieImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieLaboratory> MovieLaboratoryByMovieID { get; set; } = new List<MovieLaboratory>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieLanguage> MovieLanguageByMovieID { get; set; } = new List<MovieLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieLocationManagement> MovieLocationManagementByMovieID { get; set; } = new List<MovieLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieMakeupDepartment> MovieMakeupDepartmentByMovieID { get; set; } = new List<MovieMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieMusic> MovieMusicByMovieID { get; set; } = new List<MovieMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieMusicDepartment> MovieMusicDepartmentByMovieID { get; set; } = new List<MovieMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormatByMovieID { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieOtherCompany> MovieOtherCompanyByMovieID { get; set; } = new List<MovieOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieOtherCrew> MovieOtherCrewByMovieID { get; set; } = new List<MovieOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MoviePoster> MoviePosterByMovieID { get; set; } = new List<MoviePoster>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormatByMovieID { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieProducer> MovieProducerByMovieID { get; set; } = new List<MovieProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieProductionCompany> MovieProductionCompanyByMovieID { get; set; } = new List<MovieProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieProductionDate> MovieProductionDateByMovieID { get; set; } = new List<MovieProductionDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieProductionDesign> MovieProductionDesignByMovieID { get; set; } = new List<MovieProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieProductionManagement> MovieProductionManagementByMovieID { get; set; } = new List<MovieProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieReview> MovieReviewByMovieID { get; set; } = new List<MovieReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieRuntime> MovieRuntimeByMovieID { get; set; } = new List<MovieRuntime>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieSetDecoration> MovieSetDecorationByMovieID { get; set; } = new List<MovieSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieSoundDepartment> MovieSoundDepartmentByMovieID { get; set; } = new List<MovieSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieSoundMix> MovieSoundMixByMovieID { get; set; } = new List<MovieSoundMix>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieSpecialEffects> MovieSpecialEffectsByMovieID { get; set; } = new List<MovieSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieSpecialEffectsCompany> MovieSpecialEffectsCompanyByMovieID { get; set; } = new List<MovieSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieStunts> MovieStuntsByMovieID { get; set; } = new List<MovieStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieThanks> MovieThanksByMovieID { get; set; } = new List<MovieThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieTransportationDepartment> MovieTransportationDepartmentByMovieID { get; set; } = new List<MovieTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieUser> MovieUserByMovieID { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieVisualEffects> MovieVisualEffectsByMovieID { get; set; } = new List<MovieVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieWeblink> MovieWeblinkByMovieID { get; set; } = new List<MovieWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Movie" verweisen.</summary>
    public ICollection<MovieWriter> MovieWriterByMovieID { get; set; } = new List<MovieWriter>();

}
