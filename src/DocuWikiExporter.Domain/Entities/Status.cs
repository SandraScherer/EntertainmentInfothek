namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Status".</summary>
public class Status : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<AspectRatio> AspectRatioByStatusID { get; set; } = new List<AspectRatio>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Award> AwardByStatusID { get; set; } = new List<Award>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Book> BookByCastStatusID { get; set; } = new List<Book>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Book> BookByStatusID { get; set; } = new List<Book>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookAward> BookAwardByStatusID { get; set; } = new List<BookAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookCast> BookCastByStatusID { get; set; } = new List<BookCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookCover> BookCoverByStatusID { get; set; } = new List<BookCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookDescription> BookDescriptionByStatusID { get; set; } = new List<BookDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookGenre> BookGenreByStatusID { get; set; } = new List<BookGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookLanguage> BookLanguageByStatusID { get; set; } = new List<BookLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookPublication> BookPublicationByStatusID { get; set; } = new List<BookPublication>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookReview> BookReviewByStatusID { get; set; } = new List<BookReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookUser> BookUserByStatusID { get; set; } = new List<BookUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookUser> BookUserByUserStatusID { get; set; } = new List<BookUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookWeblink> BookWeblinkByStatusID { get; set; } = new List<BookWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BookWriter> BookWriterByStatusID { get; set; } = new List<BookWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<BusinessModel> BusinessModelByStatusID { get; set; } = new List<BusinessModel>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<CDROMDriveSpeed> CDROMDriveSpeedByStatusID { get; set; } = new List<CDROMDriveSpeed>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<CPU> CPUByStatusID { get; set; } = new List<CPU>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Camera> CameraByStatusID { get; set; } = new List<Camera>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Certification> CertificationByStatusID { get; set; } = new List<Certification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<CinematographicProcess> CinematographicProcessByStatusID { get; set; } = new List<CinematographicProcess>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Color> ColorByStatusID { get; set; } = new List<Color>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Company> CompanyByStatusID { get; set; } = new List<Company>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Connection> ConnectionByStatusID { get; set; } = new List<Connection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<ControllerType> ControllerTypeByStatusID { get; set; } = new List<ControllerType>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<CopyProtection> CopyProtectionByStatusID { get; set; } = new List<CopyProtection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Country> CountryByStatusID { get; set; } = new List<Country>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Difficulty> DifficultyByStatusID { get; set; } = new List<Difficulty>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<DirectX> DirectXByStatusID { get; set; } = new List<DirectX>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Driver> DriverByStatusID { get; set; } = new List<Driver>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Edition> EditionByStatusID { get; set; } = new List<Edition>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Episode> EpisodeByCastStatusID { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Episode> EpisodeByCrewStatusID { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Episode> EpisodeByStatusID { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeAnimationDepartment> EpisodeAnimationDepartmentByStatusID { get; set; } = new List<EpisodeAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeArtDepartment> EpisodeArtDepartmentByStatusID { get; set; } = new List<EpisodeArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeArtDirection> EpisodeArtDirectionByStatusID { get; set; } = new List<EpisodeArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeAssistantDirector> EpisodeAssistantDirectorByStatusID { get; set; } = new List<EpisodeAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeAward> EpisodeAwardByStatusID { get; set; } = new List<EpisodeAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPersonByStatusID { get; set; } = new List<EpisodeAwardPerson>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeCast> EpisodeCastByStatusID { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeCasting> EpisodeCastingByStatusID { get; set; } = new List<EpisodeCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeCastingDepartment> EpisodeCastingDepartmentByStatusID { get; set; } = new List<EpisodeCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeCinematography> EpisodeCinematographyByStatusID { get; set; } = new List<EpisodeCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeContinuityDepartment> EpisodeContinuityDepartmentByStatusID { get; set; } = new List<EpisodeContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeCostumeDepartment> EpisodeCostumeDepartmentByStatusID { get; set; } = new List<EpisodeCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeCostumeDesign> EpisodeCostumeDesignByStatusID { get; set; } = new List<EpisodeCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeDescription> EpisodeDescriptionByStatusID { get; set; } = new List<EpisodeDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeDirector> EpisodeDirectorByStatusID { get; set; } = new List<EpisodeDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributorByStatusID { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeEditorialDepartment> EpisodeEditorialDepartmentByStatusID { get; set; } = new List<EpisodeEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeElectricalDepartment> EpisodeElectricalDepartmentByStatusID { get; set; } = new List<EpisodeElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeFilmEditing> EpisodeFilmEditingByStatusID { get; set; } = new List<EpisodeFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeFilmingDate> EpisodeFilmingDateByStatusID { get; set; } = new List<EpisodeFilmingDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocationByStatusID { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeImage> EpisodeImageByStatusID { get; set; } = new List<EpisodeImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeLocationManagement> EpisodeLocationManagementByStatusID { get; set; } = new List<EpisodeLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeMakeupDepartment> EpisodeMakeupDepartmentByStatusID { get; set; } = new List<EpisodeMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeMusic> EpisodeMusicByStatusID { get; set; } = new List<EpisodeMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeMusicDepartment> EpisodeMusicDepartmentByStatusID { get; set; } = new List<EpisodeMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeOtherCompany> EpisodeOtherCompanyByStatusID { get; set; } = new List<EpisodeOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeOtherCrew> EpisodeOtherCrewByStatusID { get; set; } = new List<EpisodeOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeProducer> EpisodeProducerByStatusID { get; set; } = new List<EpisodeProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeProductionCompany> EpisodeProductionCompanyByStatusID { get; set; } = new List<EpisodeProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeProductionDate> EpisodeProductionDateByStatusID { get; set; } = new List<EpisodeProductionDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeProductionDesign> EpisodeProductionDesignByStatusID { get; set; } = new List<EpisodeProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeProductionManagement> EpisodeProductionManagementByStatusID { get; set; } = new List<EpisodeProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeReview> EpisodeReviewByStatusID { get; set; } = new List<EpisodeReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeSetDecoration> EpisodeSetDecorationByStatusID { get; set; } = new List<EpisodeSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeSoundDepartment> EpisodeSoundDepartmentByStatusID { get; set; } = new List<EpisodeSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeSpecialEffects> EpisodeSpecialEffectsByStatusID { get; set; } = new List<EpisodeSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompanyByStatusID { get; set; } = new List<EpisodeSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeStunts> EpisodeStuntsByStatusID { get; set; } = new List<EpisodeStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeThanks> EpisodeThanksByStatusID { get; set; } = new List<EpisodeThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeTransportationDepartment> EpisodeTransportationDepartmentByStatusID { get; set; } = new List<EpisodeTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeVisualEffects> EpisodeVisualEffectsByStatusID { get; set; } = new List<EpisodeVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<EpisodeWriter> EpisodeWriterByStatusID { get; set; } = new List<EpisodeWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<FilmFormat> FilmFormatByStatusID { get; set; } = new List<FilmFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Genre> GenreByStatusID { get; set; } = new List<Genre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Hardware> HardwareByStatusID { get; set; } = new List<Hardware>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Image> ImageByStatusID { get; set; } = new List<Image>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<ImageSource> ImageSourceByStatusID { get; set; } = new List<ImageSource>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<InputDevice> InputDeviceByStatusID { get; set; } = new List<InputDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<InputDeviceFeature> InputDeviceFeatureByStatusID { get; set; } = new List<InputDeviceFeature>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Laboratory> LaboratoryByStatusID { get; set; } = new List<Laboratory>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Language> LanguageByStatusID { get; set; } = new List<Language>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Location> LocationByStatusID { get; set; } = new List<Location>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MacOSSprocket> MacOSSprocketByStatusID { get; set; } = new List<MacOSSprocket>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MediaType> MediaTypeByStatusID { get; set; } = new List<MediaType>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Movie> MovieByCastStatusID { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Movie> MovieByCrewStatusID { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Movie> MovieByStatusID { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieAnimationDepartment> MovieAnimationDepartmentByStatusID { get; set; } = new List<MovieAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieArtDepartment> MovieArtDepartmentByStatusID { get; set; } = new List<MovieArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieArtDirection> MovieArtDirectionByStatusID { get; set; } = new List<MovieArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatioByStatusID { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieAssistantDirector> MovieAssistantDirectorByStatusID { get; set; } = new List<MovieAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieAward> MovieAwardByStatusID { get; set; } = new List<MovieAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieAwardPerson> MovieAwardPersonByStatusID { get; set; } = new List<MovieAwardPerson>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCamera> MovieCameraByStatusID { get; set; } = new List<MovieCamera>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCast> MovieCastByStatusID { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCasting> MovieCastingByStatusID { get; set; } = new List<MovieCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCastingDepartment> MovieCastingDepartmentByStatusID { get; set; } = new List<MovieCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCertification> MovieCertificationByStatusID { get; set; } = new List<MovieCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcessByStatusID { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCinematography> MovieCinematographyByStatusID { get; set; } = new List<MovieCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieColor> MovieColorByStatusID { get; set; } = new List<MovieColor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieContinuityDepartment> MovieContinuityDepartmentByStatusID { get; set; } = new List<MovieContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCostumeDepartment> MovieCostumeDepartmentByStatusID { get; set; } = new List<MovieCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCostumeDesign> MovieCostumeDesignByStatusID { get; set; } = new List<MovieCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCountry> MovieCountryByStatusID { get; set; } = new List<MovieCountry>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieCover> MovieCoverByStatusID { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieDescription> MovieDescriptionByStatusID { get; set; } = new List<MovieDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieDirector> MovieDirectorByStatusID { get; set; } = new List<MovieDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieDistributor> MovieDistributorByStatusID { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieEditorialDepartment> MovieEditorialDepartmentByStatusID { get; set; } = new List<MovieEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieElectricalDepartment> MovieElectricalDepartmentByStatusID { get; set; } = new List<MovieElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieFilmEditing> MovieFilmEditingByStatusID { get; set; } = new List<MovieFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieFilmLength> MovieFilmLengthByStatusID { get; set; } = new List<MovieFilmLength>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieFilmingDate> MovieFilmingDateByStatusID { get; set; } = new List<MovieFilmingDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocationByStatusID { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieGenre> MovieGenreByStatusID { get; set; } = new List<MovieGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieImage> MovieImageByStatusID { get; set; } = new List<MovieImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieLaboratory> MovieLaboratoryByStatusID { get; set; } = new List<MovieLaboratory>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieLanguage> MovieLanguageByStatusID { get; set; } = new List<MovieLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieLocationManagement> MovieLocationManagementByStatusID { get; set; } = new List<MovieLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieMakeupDepartment> MovieMakeupDepartmentByStatusID { get; set; } = new List<MovieMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieMusic> MovieMusicByStatusID { get; set; } = new List<MovieMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieMusicDepartment> MovieMusicDepartmentByStatusID { get; set; } = new List<MovieMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormatByStatusID { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieOtherCompany> MovieOtherCompanyByStatusID { get; set; } = new List<MovieOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieOtherCrew> MovieOtherCrewByStatusID { get; set; } = new List<MovieOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MoviePoster> MoviePosterByStatusID { get; set; } = new List<MoviePoster>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormatByStatusID { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieProducer> MovieProducerByStatusID { get; set; } = new List<MovieProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieProductionCompany> MovieProductionCompanyByStatusID { get; set; } = new List<MovieProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieProductionDate> MovieProductionDateByStatusID { get; set; } = new List<MovieProductionDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieProductionDesign> MovieProductionDesignByStatusID { get; set; } = new List<MovieProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieProductionManagement> MovieProductionManagementByStatusID { get; set; } = new List<MovieProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieReview> MovieReviewByStatusID { get; set; } = new List<MovieReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieRuntime> MovieRuntimeByStatusID { get; set; } = new List<MovieRuntime>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieSetDecoration> MovieSetDecorationByStatusID { get; set; } = new List<MovieSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieSoundDepartment> MovieSoundDepartmentByStatusID { get; set; } = new List<MovieSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieSoundMix> MovieSoundMixByStatusID { get; set; } = new List<MovieSoundMix>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieSpecialEffects> MovieSpecialEffectsByStatusID { get; set; } = new List<MovieSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieSpecialEffectsCompany> MovieSpecialEffectsCompanyByStatusID { get; set; } = new List<MovieSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieStunts> MovieStuntsByStatusID { get; set; } = new List<MovieStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieThanks> MovieThanksByStatusID { get; set; } = new List<MovieThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieTransportationDepartment> MovieTransportationDepartmentByStatusID { get; set; } = new List<MovieTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieUser> MovieUserByStatusID { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieUser> MovieUserByUserStatusID { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieVisualEffects> MovieVisualEffectsByStatusID { get; set; } = new List<MovieVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieWeblink> MovieWeblinkByStatusID { get; set; } = new List<MovieWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MovieWriter> MovieWriterByStatusID { get; set; } = new List<MovieWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MultiplayerGameMode> MultiplayerGameModeByStatusID { get; set; } = new List<MultiplayerGameMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<MultiplayerOption> MultiplayerOptionByStatusID { get; set; } = new List<MultiplayerOption>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<OperatingSystem> OperatingSystemByStatusID { get; set; } = new List<OperatingSystem>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Person> PersonByStatusID { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Perspective> PerspectiveByStatusID { get; set; } = new List<Perspective>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Platform> PlatformByStatusID { get; set; } = new List<Platform>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Priority> PriorityByStatusID { get; set; } = new List<Priority>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Publication> PublicationByStatusID { get; set; } = new List<Publication>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<PublicationCertification> PublicationCertificationByStatusID { get; set; } = new List<PublicationCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<PublicationLanguage> PublicationLanguageByStatusID { get; set; } = new List<PublicationLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<PublicationPublisher> PublicationPublisherByStatusID { get; set; } = new List<PublicationPublisher>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<RAM> RAMByStatusID { get; set; } = new List<RAM>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SaveGameMethod> SaveGameMethodByStatusID { get; set; } = new List<SaveGameMethod>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Series> SeriesByCastStatusID { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Series> SeriesByCrewStatusID { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Series> SeriesByStatusID { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesAnimationDepartment> SeriesAnimationDepartmentByStatusID { get; set; } = new List<SeriesAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesArtDepartment> SeriesArtDepartmentByStatusID { get; set; } = new List<SeriesArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesArtDirection> SeriesArtDirectionByStatusID { get; set; } = new List<SeriesArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatioByStatusID { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesAssistantDirector> SeriesAssistantDirectorByStatusID { get; set; } = new List<SeriesAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesAward> SeriesAwardByStatusID { get; set; } = new List<SeriesAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPersonByStatusID { get; set; } = new List<SeriesAwardPerson>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCamera> SeriesCameraByStatusID { get; set; } = new List<SeriesCamera>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCast> SeriesCastByStatusID { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCasting> SeriesCastingByStatusID { get; set; } = new List<SeriesCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCastingDepartment> SeriesCastingDepartmentByStatusID { get; set; } = new List<SeriesCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCertification> SeriesCertificationByStatusID { get; set; } = new List<SeriesCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcessByStatusID { get; set; } = new List<SeriesCinematographicProcess>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCinematography> SeriesCinematographyByStatusID { get; set; } = new List<SeriesCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesColor> SeriesColorByStatusID { get; set; } = new List<SeriesColor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesContinuityDepartment> SeriesContinuityDepartmentByStatusID { get; set; } = new List<SeriesContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCostumeDepartment> SeriesCostumeDepartmentByStatusID { get; set; } = new List<SeriesCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCostumeDesign> SeriesCostumeDesignByStatusID { get; set; } = new List<SeriesCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCountry> SeriesCountryByStatusID { get; set; } = new List<SeriesCountry>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCover> SeriesCoverByStatusID { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesCreator> SeriesCreatorByStatusID { get; set; } = new List<SeriesCreator>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesDescription> SeriesDescriptionByStatusID { get; set; } = new List<SeriesDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesDirector> SeriesDirectorByStatusID { get; set; } = new List<SeriesDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesDistributor> SeriesDistributorByStatusID { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesEditorialDepartment> SeriesEditorialDepartmentByStatusID { get; set; } = new List<SeriesEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesElectricalDepartment> SeriesElectricalDepartmentByStatusID { get; set; } = new List<SeriesElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesFilmEditing> SeriesFilmEditingByStatusID { get; set; } = new List<SeriesFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesFilmLength> SeriesFilmLengthByStatusID { get; set; } = new List<SeriesFilmLength>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesFilmingDate> SeriesFilmingDateByStatusID { get; set; } = new List<SeriesFilmingDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocationByStatusID { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesGenre> SeriesGenreByStatusID { get; set; } = new List<SeriesGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesImage> SeriesImageByStatusID { get; set; } = new List<SeriesImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratoryByStatusID { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesLanguage> SeriesLanguageByStatusID { get; set; } = new List<SeriesLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesLocationManagement> SeriesLocationManagementByStatusID { get; set; } = new List<SeriesLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesLogo> SeriesLogoByStatusID { get; set; } = new List<SeriesLogo>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesMakeupDepartment> SeriesMakeupDepartmentByStatusID { get; set; } = new List<SeriesMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesMusic> SeriesMusicByStatusID { get; set; } = new List<SeriesMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesMusicDepartment> SeriesMusicDepartmentByStatusID { get; set; } = new List<SeriesMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormatByStatusID { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesOtherCrew> SeriesOtherCrewByStatusID { get; set; } = new List<SeriesOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesPoster> SeriesPosterByStatusID { get; set; } = new List<SeriesPoster>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormatByStatusID { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesProducer> SeriesProducerByStatusID { get; set; } = new List<SeriesProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesProductionCompany> SeriesProductionCompanyByStatusID { get; set; } = new List<SeriesProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesProductionDate> SeriesProductionDateByStatusID { get; set; } = new List<SeriesProductionDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesProductionDesign> SeriesProductionDesignByStatusID { get; set; } = new List<SeriesProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesProductionManagement> SeriesProductionManagementByStatusID { get; set; } = new List<SeriesProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesReview> SeriesReviewByStatusID { get; set; } = new List<SeriesReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesRuntime> SeriesRuntimeByStatusID { get; set; } = new List<SeriesRuntime>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesSetDecoration> SeriesSetDecorationByStatusID { get; set; } = new List<SeriesSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesSoundDepartment> SeriesSoundDepartmentByStatusID { get; set; } = new List<SeriesSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMixByStatusID { get; set; } = new List<SeriesSoundMix>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesSpecialEffects> SeriesSpecialEffectsByStatusID { get; set; } = new List<SeriesSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompanyByStatusID { get; set; } = new List<SeriesSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesStunts> SeriesStuntsByStatusID { get; set; } = new List<SeriesStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesThanks> SeriesThanksByStatusID { get; set; } = new List<SeriesThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesTransportationDepartment> SeriesTransportationDepartmentByStatusID { get; set; } = new List<SeriesTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesUser> SeriesUserByStatusID { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesUser> SeriesUserByUserStatusID { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesVisualEffects> SeriesVisualEffectsByStatusID { get; set; } = new List<SeriesVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesWeblink> SeriesWeblinkByStatusID { get; set; } = new List<SeriesWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SeriesWriter> SeriesWriterByStatusID { get; set; } = new List<SeriesWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Setting> SettingByStatusID { get; set; } = new List<Setting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SoundDevice> SoundDeviceByStatusID { get; set; } = new List<SoundDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SoundMix> SoundMixByStatusID { get; set; } = new List<SoundMix>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SoundMode> SoundModeByStatusID { get; set; } = new List<SoundMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Status> StatusByStatusID { get; set; } = new List<Status>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<SystemEntity> SystemEntityByStatusID { get; set; } = new List<SystemEntity>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByStatusID { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationCopyProtection> TechnicalSpecificationCopyProtectionByStatusID { get; set; } = new List<TechnicalSpecificationCopyProtection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocket> TechnicalSpecificationMacOSSprocketByStatusID { get; set; } = new List<TechnicalSpecificationMacOSSprocket>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationMediaType> TechnicalSpecificationMediaTypeByStatusID { get; set; } = new List<TechnicalSpecificationMediaType>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameMode> TechnicalSpecificationMultiplayerGameModeByStatusID { get; set; } = new List<TechnicalSpecificationMultiplayerGameMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOption> TechnicalSpecificationMultiplayerOptionByStatusID { get; set; } = new List<TechnicalSpecificationMultiplayerOption>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardware> TechnicalSpecificationRequiredAdditionalHardwareByStatusID { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardware>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDevice> TechnicalSpecificationRequiredInputDeviceByStatusID { get; set; } = new List<TechnicalSpecificationRequiredInputDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethod> TechnicalSpecificationSaveGameMethodByStatusID { get; set; } = new List<TechnicalSpecificationSaveGameMethod>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardware> TechnicalSpecificationSupportedAdditionalHardwareByStatusID { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardware>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedControllerType> TechnicalSpecificationSupportedControllerTypeByStatusID { get; set; } = new List<TechnicalSpecificationSupportedControllerType>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedDriver> TechnicalSpecificationSupportedDriverByStatusID { get; set; } = new List<TechnicalSpecificationSupportedDriver>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDevice> TechnicalSpecificationSupportedInputDeviceByStatusID { get; set; } = new List<TechnicalSpecificationSupportedInputDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeature> TechnicalSpecificationSupportedInputDeviceFeatureByStatusID { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeature>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDevice> TechnicalSpecificationSupportedSoundDeviceByStatusID { get; set; } = new List<TechnicalSpecificationSupportedSoundDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundMode> TechnicalSpecificationSupportedSoundModeByStatusID { get; set; } = new List<TechnicalSpecificationSupportedSoundMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoMode> TechnicalSpecificationSupportedVideoModeByStatusID { get; set; } = new List<TechnicalSpecificationSupportedVideoMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolution> TechnicalSpecificationSupportedVideoResolutionByStatusID { get; set; } = new List<TechnicalSpecificationSupportedVideoResolution>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Text> TextByStatusID { get; set; } = new List<Text>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TextAuthor> TextAuthorByStatusID { get; set; } = new List<TextAuthor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<TextSource> TextSourceByStatusID { get; set; } = new List<TextSource>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Type> TypeByStatusID { get; set; } = new List<Type>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<User> UserByStatusID { get; set; } = new List<User>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Version> VersionByStatusID { get; set; } = new List<Version>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGame> VideoGameByCastStatusID { get; set; } = new List<VideoGame>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGame> VideoGameByStatusID { get; set; } = new List<VideoGame>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameAward> VideoGameAwardByStatusID { get; set; } = new List<VideoGameAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameCast> VideoGameCastByStatusID { get; set; } = new List<VideoGameCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameCertification> VideoGameCertificationByStatusID { get; set; } = new List<VideoGameCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletionByCompletionID { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletionByStatusID { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameCover> VideoGameCoverByStatusID { get; set; } = new List<VideoGameCover>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameDescription> VideoGameDescriptionByStatusID { get; set; } = new List<VideoGameDescription>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameDeveloper> VideoGameDeveloperByStatusID { get; set; } = new List<VideoGameDeveloper>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultyByStatusID { get; set; } = new List<VideoGameDifficulty>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameDistributor> VideoGameDistributorByStatusID { get; set; } = new List<VideoGameDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameGenre> VideoGameGenreByStatusID { get; set; } = new List<VideoGameGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameImage> VideoGameImageByStatusID { get; set; } = new List<VideoGameImage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectiveByStatusID { get; set; } = new List<VideoGamePerspective>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGamePublisher> VideoGamePublisherByStatusID { get; set; } = new List<VideoGamePublisher>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameReleaseDate> VideoGameReleaseDateByStatusID { get; set; } = new List<VideoGameReleaseDate>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameReview> VideoGameReviewByStatusID { get; set; } = new List<VideoGameReview>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameScore> VideoGameScoreByStatusID { get; set; } = new List<VideoGameScore>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameSetting> VideoGameSettingByStatusID { get; set; } = new List<VideoGameSetting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameUser> VideoGameUserByStatusID { get; set; } = new List<VideoGameUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameUser> VideoGameUserByUserStatusID { get; set; } = new List<VideoGameUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameVersion> VideoGameVersionByStatusID { get; set; } = new List<VideoGameVersion>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoGameWeblink> VideoGameWeblinkByStatusID { get; set; } = new List<VideoGameWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoMode> VideoModeByStatusID { get; set; } = new List<VideoMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<VideoResolution> VideoResolutionByStatusID { get; set; } = new List<VideoResolution>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Status" verweisen.</summary>
    public ICollection<Weblink> WeblinkByStatusID { get; set; } = new List<Weblink>();

}
