using DocuWikiExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocuWikiExporter.Infrastructure.Persistence;

/// <summary>EF-Core-Kontext für die bereits existierende SQLite-Datenbank.</summary>
/// <remarks>Der Kontext ist read-only gedacht; es werden keine Migrationen angewendet.</remarks>
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>DbSet für die SQLite-Tabelle "AspectRatio".</summary>
    public DbSet<AspectRatio> AspectRatios => Set<AspectRatio>();
    /// <summary>DbSet für die SQLite-Tabelle "Award".</summary>
    public DbSet<Award> Awards => Set<Award>();
    /// <summary>DbSet für die SQLite-Tabelle "Book".</summary>
    public DbSet<Book> Books => Set<Book>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Award".</summary>
    public DbSet<BookAward> BookAwards => Set<BookAward>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Cast".</summary>
    public DbSet<BookCast> BookCasts => Set<BookCast>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Cover".</summary>
    public DbSet<BookCover> BookCovers => Set<BookCover>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Description".</summary>
    public DbSet<BookDescription> BookDescriptions => Set<BookDescription>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Genre".</summary>
    public DbSet<BookGenre> BookGenres => Set<BookGenre>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Language".</summary>
    public DbSet<BookLanguage> BookLanguages => Set<BookLanguage>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Publication".</summary>
    public DbSet<BookPublication> BookPublications => Set<BookPublication>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Review".</summary>
    public DbSet<BookReview> BookReviews => Set<BookReview>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_User".</summary>
    public DbSet<BookUser> BookUsers => Set<BookUser>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Weblink".</summary>
    public DbSet<BookWeblink> BookWeblinks => Set<BookWeblink>();
    /// <summary>DbSet für die SQLite-Tabelle "Book_Writer".</summary>
    public DbSet<BookWriter> BookWriters => Set<BookWriter>();
    /// <summary>DbSet für die SQLite-Tabelle "BusinessModel".</summary>
    public DbSet<BusinessModel> BusinessModels => Set<BusinessModel>();
    /// <summary>DbSet für die SQLite-Tabelle "CDROMDriveSpeed".</summary>
    public DbSet<CDROMDriveSpeed> CDROMDriveSpeeds => Set<CDROMDriveSpeed>();
    /// <summary>DbSet für die SQLite-Tabelle "CPU".</summary>
    public DbSet<CPU> CPUs => Set<CPU>();
    /// <summary>DbSet für die SQLite-Tabelle "Camera".</summary>
    public DbSet<Camera> Cameras => Set<Camera>();
    /// <summary>DbSet für die SQLite-Tabelle "Certification".</summary>
    public DbSet<Certification> Certifications => Set<Certification>();
    /// <summary>DbSet für die SQLite-Tabelle "CinematographicProcess".</summary>
    public DbSet<CinematographicProcess> CinematographicProcessSet => Set<CinematographicProcess>();
    /// <summary>DbSet für die SQLite-Tabelle "Color".</summary>
    public DbSet<Color> Colors => Set<Color>();
    /// <summary>DbSet für die SQLite-Tabelle "Company".</summary>
    public DbSet<Company> Companys => Set<Company>();
    /// <summary>DbSet für die SQLite-Tabelle "Connection".</summary>
    public DbSet<Connection> Connections => Set<Connection>();
    /// <summary>DbSet für die SQLite-Tabelle "ControllerType".</summary>
    public DbSet<ControllerType> ControllerTypes => Set<ControllerType>();
    /// <summary>DbSet für die SQLite-Tabelle "CopyProtection".</summary>
    public DbSet<CopyProtection> CopyProtections => Set<CopyProtection>();
    /// <summary>DbSet für die SQLite-Tabelle "Country".</summary>
    public DbSet<Country> Countrys => Set<Country>();
    /// <summary>DbSet für die SQLite-Tabelle "Difficulty".</summary>
    public DbSet<Difficulty> Difficultys => Set<Difficulty>();
    /// <summary>DbSet für die SQLite-Tabelle "DirectX".</summary>
    public DbSet<DirectX> DirectXs => Set<DirectX>();
    /// <summary>DbSet für die SQLite-Tabelle "Driver".</summary>
    public DbSet<Driver> Drivers => Set<Driver>();
    /// <summary>DbSet für die SQLite-Tabelle "Edition".</summary>
    public DbSet<Edition> Editions => Set<Edition>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode".</summary>
    public DbSet<Episode> Episodes => Set<Episode>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_AnimationDepartment".</summary>
    public DbSet<EpisodeAnimationDepartment> EpisodeAnimationDepartments => Set<EpisodeAnimationDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ArtDepartment".</summary>
    public DbSet<EpisodeArtDepartment> EpisodeArtDepartments => Set<EpisodeArtDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ArtDirection".</summary>
    public DbSet<EpisodeArtDirection> EpisodeArtDirections => Set<EpisodeArtDirection>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_AssistantDirector".</summary>
    public DbSet<EpisodeAssistantDirector> EpisodeAssistantDirectors => Set<EpisodeAssistantDirector>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Award".</summary>
    public DbSet<EpisodeAward> EpisodeAwards => Set<EpisodeAward>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Award_Person".</summary>
    public DbSet<EpisodeAwardPerson> EpisodeAwardPersons => Set<EpisodeAwardPerson>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Cast".</summary>
    public DbSet<EpisodeCast> EpisodeCasts => Set<EpisodeCast>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Casting".</summary>
    public DbSet<EpisodeCasting> EpisodeCastings => Set<EpisodeCasting>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_CastingDepartment".</summary>
    public DbSet<EpisodeCastingDepartment> EpisodeCastingDepartments => Set<EpisodeCastingDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Cinematography".</summary>
    public DbSet<EpisodeCinematography> EpisodeCinematographys => Set<EpisodeCinematography>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ContinuityDepartment".</summary>
    public DbSet<EpisodeContinuityDepartment> EpisodeContinuityDepartments => Set<EpisodeContinuityDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_CostumeDepartment".</summary>
    public DbSet<EpisodeCostumeDepartment> EpisodeCostumeDepartments => Set<EpisodeCostumeDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_CostumeDesign".</summary>
    public DbSet<EpisodeCostumeDesign> EpisodeCostumeDesigns => Set<EpisodeCostumeDesign>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Description".</summary>
    public DbSet<EpisodeDescription> EpisodeDescriptions => Set<EpisodeDescription>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Director".</summary>
    public DbSet<EpisodeDirector> EpisodeDirectors => Set<EpisodeDirector>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Distributor".</summary>
    public DbSet<EpisodeDistributor> EpisodeDistributors => Set<EpisodeDistributor>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_EditorialDepartment".</summary>
    public DbSet<EpisodeEditorialDepartment> EpisodeEditorialDepartments => Set<EpisodeEditorialDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ElectricalDepartment".</summary>
    public DbSet<EpisodeElectricalDepartment> EpisodeElectricalDepartments => Set<EpisodeElectricalDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_FilmEditing".</summary>
    public DbSet<EpisodeFilmEditing> EpisodeFilmEditings => Set<EpisodeFilmEditing>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_FilmingDate".</summary>
    public DbSet<EpisodeFilmingDate> EpisodeFilmingDates => Set<EpisodeFilmingDate>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_FilmingLocation".</summary>
    public DbSet<EpisodeFilmingLocation> EpisodeFilmingLocations => Set<EpisodeFilmingLocation>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Image".</summary>
    public DbSet<EpisodeImage> EpisodeImages => Set<EpisodeImage>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_LocationManagement".</summary>
    public DbSet<EpisodeLocationManagement> EpisodeLocationManagements => Set<EpisodeLocationManagement>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_MakeupDepartment".</summary>
    public DbSet<EpisodeMakeupDepartment> EpisodeMakeupDepartments => Set<EpisodeMakeupDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Music".</summary>
    public DbSet<EpisodeMusic> EpisodeMusics => Set<EpisodeMusic>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_MusicDepartment".</summary>
    public DbSet<EpisodeMusicDepartment> EpisodeMusicDepartments => Set<EpisodeMusicDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_OtherCompany".</summary>
    public DbSet<EpisodeOtherCompany> EpisodeOtherCompanys => Set<EpisodeOtherCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_OtherCrew".</summary>
    public DbSet<EpisodeOtherCrew> EpisodeOtherCrews => Set<EpisodeOtherCrew>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Producer".</summary>
    public DbSet<EpisodeProducer> EpisodeProducers => Set<EpisodeProducer>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ProductionCompany".</summary>
    public DbSet<EpisodeProductionCompany> EpisodeProductionCompanys => Set<EpisodeProductionCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ProductionDate".</summary>
    public DbSet<EpisodeProductionDate> EpisodeProductionDates => Set<EpisodeProductionDate>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ProductionDesign".</summary>
    public DbSet<EpisodeProductionDesign> EpisodeProductionDesigns => Set<EpisodeProductionDesign>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_ProductionManagement".</summary>
    public DbSet<EpisodeProductionManagement> EpisodeProductionManagements => Set<EpisodeProductionManagement>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Review".</summary>
    public DbSet<EpisodeReview> EpisodeReviews => Set<EpisodeReview>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_SetDecoration".</summary>
    public DbSet<EpisodeSetDecoration> EpisodeSetDecorations => Set<EpisodeSetDecoration>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_SoundDepartment".</summary>
    public DbSet<EpisodeSoundDepartment> EpisodeSoundDepartments => Set<EpisodeSoundDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_SpecialEffects".</summary>
    public DbSet<EpisodeSpecialEffects> EpisodeSpecialEffectsSet => Set<EpisodeSpecialEffects>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_SpecialEffectsCompany".</summary>
    public DbSet<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompanys => Set<EpisodeSpecialEffectsCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Stunts".</summary>
    public DbSet<EpisodeStunts> EpisodeStuntsSet => Set<EpisodeStunts>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Thanks".</summary>
    public DbSet<EpisodeThanks> EpisodeThanksSet => Set<EpisodeThanks>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_TransportationDepartment".</summary>
    public DbSet<EpisodeTransportationDepartment> EpisodeTransportationDepartments => Set<EpisodeTransportationDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_VisualEffects".</summary>
    public DbSet<EpisodeVisualEffects> EpisodeVisualEffectsSet => Set<EpisodeVisualEffects>();
    /// <summary>DbSet für die SQLite-Tabelle "Episode_Writer".</summary>
    public DbSet<EpisodeWriter> EpisodeWriters => Set<EpisodeWriter>();
    /// <summary>DbSet für die SQLite-Tabelle "FilmFormat".</summary>
    public DbSet<FilmFormat> FilmFormats => Set<FilmFormat>();
    /// <summary>DbSet für die SQLite-Tabelle "Genre".</summary>
    public DbSet<Genre> Genres => Set<Genre>();
    /// <summary>DbSet für die SQLite-Tabelle "Hardware".</summary>
    public DbSet<Hardware> Hardwares => Set<Hardware>();
    /// <summary>DbSet für die SQLite-Tabelle "Image".</summary>
    public DbSet<Image> Images => Set<Image>();
    /// <summary>DbSet für die SQLite-Tabelle "Image_Source".</summary>
    public DbSet<ImageSource> ImageSources => Set<ImageSource>();
    /// <summary>DbSet für die SQLite-Tabelle "InputDevice".</summary>
    public DbSet<InputDevice> InputDevices => Set<InputDevice>();
    /// <summary>DbSet für die SQLite-Tabelle "InputDeviceFeature".</summary>
    public DbSet<InputDeviceFeature> InputDeviceFeatures => Set<InputDeviceFeature>();
    /// <summary>DbSet für die SQLite-Tabelle "Laboratory".</summary>
    public DbSet<Laboratory> Laboratorys => Set<Laboratory>();
    /// <summary>DbSet für die SQLite-Tabelle "Language".</summary>
    public DbSet<Language> Languages => Set<Language>();
    /// <summary>DbSet für die SQLite-Tabelle "Location".</summary>
    public DbSet<Location> Locations => Set<Location>();
    /// <summary>DbSet für die SQLite-Tabelle "MacOSSprocket".</summary>
    public DbSet<MacOSSprocket> MacOSSprockets => Set<MacOSSprocket>();
    /// <summary>DbSet für die SQLite-Tabelle "MediaType".</summary>
    public DbSet<MediaType> MediaTypes => Set<MediaType>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie".</summary>
    public DbSet<Movie> Movies => Set<Movie>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_AnimationDepartment".</summary>
    public DbSet<MovieAnimationDepartment> MovieAnimationDepartments => Set<MovieAnimationDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ArtDepartment".</summary>
    public DbSet<MovieArtDepartment> MovieArtDepartments => Set<MovieArtDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ArtDirection".</summary>
    public DbSet<MovieArtDirection> MovieArtDirections => Set<MovieArtDirection>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_AspectRatio".</summary>
    public DbSet<MovieAspectRatio> MovieAspectRatios => Set<MovieAspectRatio>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_AssistantDirector".</summary>
    public DbSet<MovieAssistantDirector> MovieAssistantDirectors => Set<MovieAssistantDirector>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Award".</summary>
    public DbSet<MovieAward> MovieAwards => Set<MovieAward>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Award_Person".</summary>
    public DbSet<MovieAwardPerson> MovieAwardPersons => Set<MovieAwardPerson>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Camera".</summary>
    public DbSet<MovieCamera> MovieCameras => Set<MovieCamera>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Cast".</summary>
    public DbSet<MovieCast> MovieCasts => Set<MovieCast>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Casting".</summary>
    public DbSet<MovieCasting> MovieCastings => Set<MovieCasting>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_CastingDepartment".</summary>
    public DbSet<MovieCastingDepartment> MovieCastingDepartments => Set<MovieCastingDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Certification".</summary>
    public DbSet<MovieCertification> MovieCertifications => Set<MovieCertification>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_CinematographicProcess".</summary>
    public DbSet<MovieCinematographicProcess> MovieCinematographicProcessSet => Set<MovieCinematographicProcess>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Cinematography".</summary>
    public DbSet<MovieCinematography> MovieCinematographys => Set<MovieCinematography>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Color".</summary>
    public DbSet<MovieColor> MovieColors => Set<MovieColor>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ContinuityDepartment".</summary>
    public DbSet<MovieContinuityDepartment> MovieContinuityDepartments => Set<MovieContinuityDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_CostumeDepartment".</summary>
    public DbSet<MovieCostumeDepartment> MovieCostumeDepartments => Set<MovieCostumeDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_CostumeDesign".</summary>
    public DbSet<MovieCostumeDesign> MovieCostumeDesigns => Set<MovieCostumeDesign>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Country".</summary>
    public DbSet<MovieCountry> MovieCountrys => Set<MovieCountry>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Cover".</summary>
    public DbSet<MovieCover> MovieCovers => Set<MovieCover>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Description".</summary>
    public DbSet<MovieDescription> MovieDescriptions => Set<MovieDescription>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Director".</summary>
    public DbSet<MovieDirector> MovieDirectors => Set<MovieDirector>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Distributor".</summary>
    public DbSet<MovieDistributor> MovieDistributors => Set<MovieDistributor>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_EditorialDepartment".</summary>
    public DbSet<MovieEditorialDepartment> MovieEditorialDepartments => Set<MovieEditorialDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ElectricalDepartment".</summary>
    public DbSet<MovieElectricalDepartment> MovieElectricalDepartments => Set<MovieElectricalDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_FilmEditing".</summary>
    public DbSet<MovieFilmEditing> MovieFilmEditings => Set<MovieFilmEditing>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_FilmLength".</summary>
    public DbSet<MovieFilmLength> MovieFilmLengths => Set<MovieFilmLength>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_FilmingDate".</summary>
    public DbSet<MovieFilmingDate> MovieFilmingDates => Set<MovieFilmingDate>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_FilmingLocation".</summary>
    public DbSet<MovieFilmingLocation> MovieFilmingLocations => Set<MovieFilmingLocation>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Genre".</summary>
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Image".</summary>
    public DbSet<MovieImage> MovieImages => Set<MovieImage>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Laboratory".</summary>
    public DbSet<MovieLaboratory> MovieLaboratorys => Set<MovieLaboratory>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Language".</summary>
    public DbSet<MovieLanguage> MovieLanguages => Set<MovieLanguage>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_LocationManagement".</summary>
    public DbSet<MovieLocationManagement> MovieLocationManagements => Set<MovieLocationManagement>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_MakeupDepartment".</summary>
    public DbSet<MovieMakeupDepartment> MovieMakeupDepartments => Set<MovieMakeupDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Music".</summary>
    public DbSet<MovieMusic> MovieMusics => Set<MovieMusic>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_MusicDepartment".</summary>
    public DbSet<MovieMusicDepartment> MovieMusicDepartments => Set<MovieMusicDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_NegativeFormat".</summary>
    public DbSet<MovieNegativeFormat> MovieNegativeFormats => Set<MovieNegativeFormat>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_OtherCompany".</summary>
    public DbSet<MovieOtherCompany> MovieOtherCompanys => Set<MovieOtherCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_OtherCrew".</summary>
    public DbSet<MovieOtherCrew> MovieOtherCrews => Set<MovieOtherCrew>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Poster".</summary>
    public DbSet<MoviePoster> MoviePosters => Set<MoviePoster>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_PrintedFilmFormat".</summary>
    public DbSet<MoviePrintedFilmFormat> MoviePrintedFilmFormats => Set<MoviePrintedFilmFormat>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Producer".</summary>
    public DbSet<MovieProducer> MovieProducers => Set<MovieProducer>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ProductionCompany".</summary>
    public DbSet<MovieProductionCompany> MovieProductionCompanys => Set<MovieProductionCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ProductionDate".</summary>
    public DbSet<MovieProductionDate> MovieProductionDates => Set<MovieProductionDate>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ProductionDesign".</summary>
    public DbSet<MovieProductionDesign> MovieProductionDesigns => Set<MovieProductionDesign>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_ProductionManagement".</summary>
    public DbSet<MovieProductionManagement> MovieProductionManagements => Set<MovieProductionManagement>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Review".</summary>
    public DbSet<MovieReview> MovieReviews => Set<MovieReview>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Runtime".</summary>
    public DbSet<MovieRuntime> MovieRuntimes => Set<MovieRuntime>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_SetDecoration".</summary>
    public DbSet<MovieSetDecoration> MovieSetDecorations => Set<MovieSetDecoration>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_SoundDepartment".</summary>
    public DbSet<MovieSoundDepartment> MovieSoundDepartments => Set<MovieSoundDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_SoundMix".</summary>
    public DbSet<MovieSoundMix> MovieSoundMixs => Set<MovieSoundMix>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_SpecialEffects".</summary>
    public DbSet<MovieSpecialEffects> MovieSpecialEffectsSet => Set<MovieSpecialEffects>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_SpecialEffectsCompany".</summary>
    public DbSet<MovieSpecialEffectsCompany> MovieSpecialEffectsCompanys => Set<MovieSpecialEffectsCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Stunts".</summary>
    public DbSet<MovieStunts> MovieStuntsSet => Set<MovieStunts>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Thanks".</summary>
    public DbSet<MovieThanks> MovieThanksSet => Set<MovieThanks>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_TransportationDepartment".</summary>
    public DbSet<MovieTransportationDepartment> MovieTransportationDepartments => Set<MovieTransportationDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_User".</summary>
    public DbSet<MovieUser> MovieUsers => Set<MovieUser>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_VisualEffects".</summary>
    public DbSet<MovieVisualEffects> MovieVisualEffectsSet => Set<MovieVisualEffects>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Weblink".</summary>
    public DbSet<MovieWeblink> MovieWeblinks => Set<MovieWeblink>();
    /// <summary>DbSet für die SQLite-Tabelle "Movie_Writer".</summary>
    public DbSet<MovieWriter> MovieWriters => Set<MovieWriter>();
    /// <summary>DbSet für die SQLite-Tabelle "MultiplayerGameMode".</summary>
    public DbSet<MultiplayerGameMode> MultiplayerGameModes => Set<MultiplayerGameMode>();
    /// <summary>DbSet für die SQLite-Tabelle "MultiplayerOption".</summary>
    public DbSet<MultiplayerOption> MultiplayerOptions => Set<MultiplayerOption>();
    /// <summary>DbSet für die SQLite-Tabelle "OperatingSystem".</summary>
    public DbSet<OperatingSystem> OperatingSystems => Set<OperatingSystem>();
    /// <summary>DbSet für die SQLite-Tabelle "Person".</summary>
    public DbSet<Person> Persons => Set<Person>();
    /// <summary>DbSet für die SQLite-Tabelle "Perspective".</summary>
    public DbSet<Perspective> Perspectives => Set<Perspective>();
    /// <summary>DbSet für die SQLite-Tabelle "Platform".</summary>
    public DbSet<Platform> Platforms => Set<Platform>();
    /// <summary>DbSet für die SQLite-Tabelle "Priority".</summary>
    public DbSet<Priority> Prioritys => Set<Priority>();
    /// <summary>DbSet für die SQLite-Tabelle "Publication".</summary>
    public DbSet<Publication> Publications => Set<Publication>();
    /// <summary>DbSet für die SQLite-Tabelle "Publication_Certification".</summary>
    public DbSet<PublicationCertification> PublicationCertifications => Set<PublicationCertification>();
    /// <summary>DbSet für die SQLite-Tabelle "Publication_Language".</summary>
    public DbSet<PublicationLanguage> PublicationLanguages => Set<PublicationLanguage>();
    /// <summary>DbSet für die SQLite-Tabelle "Publication_Publisher".</summary>
    public DbSet<PublicationPublisher> PublicationPublishers => Set<PublicationPublisher>();
    /// <summary>DbSet für die SQLite-Tabelle "RAM".</summary>
    public DbSet<RAM> RAMs => Set<RAM>();
    /// <summary>DbSet für die SQLite-Tabelle "SaveGameMethod".</summary>
    public DbSet<SaveGameMethod> SaveGameMethods => Set<SaveGameMethod>();
    /// <summary>DbSet für die SQLite-Tabelle "Series".</summary>
    public DbSet<Series> SeriesSet => Set<Series>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_AnimationDepartment".</summary>
    public DbSet<SeriesAnimationDepartment> SeriesAnimationDepartments => Set<SeriesAnimationDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ArtDepartment".</summary>
    public DbSet<SeriesArtDepartment> SeriesArtDepartments => Set<SeriesArtDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ArtDirection".</summary>
    public DbSet<SeriesArtDirection> SeriesArtDirections => Set<SeriesArtDirection>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_AspectRatio".</summary>
    public DbSet<SeriesAspectRatio> SeriesAspectRatios => Set<SeriesAspectRatio>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_AssistantDirector".</summary>
    public DbSet<SeriesAssistantDirector> SeriesAssistantDirectors => Set<SeriesAssistantDirector>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Award".</summary>
    public DbSet<SeriesAward> SeriesAwards => Set<SeriesAward>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Award_Person".</summary>
    public DbSet<SeriesAwardPerson> SeriesAwardPersons => Set<SeriesAwardPerson>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Camera".</summary>
    public DbSet<SeriesCamera> SeriesCameras => Set<SeriesCamera>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Cast".</summary>
    public DbSet<SeriesCast> SeriesCasts => Set<SeriesCast>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Casting".</summary>
    public DbSet<SeriesCasting> SeriesCastings => Set<SeriesCasting>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_CastingDepartment".</summary>
    public DbSet<SeriesCastingDepartment> SeriesCastingDepartments => Set<SeriesCastingDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Certification".</summary>
    public DbSet<SeriesCertification> SeriesCertifications => Set<SeriesCertification>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_CinematographicProcess".</summary>
    public DbSet<SeriesCinematographicProcess> SeriesCinematographicProcessSet => Set<SeriesCinematographicProcess>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Cinematography".</summary>
    public DbSet<SeriesCinematography> SeriesCinematographys => Set<SeriesCinematography>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Color".</summary>
    public DbSet<SeriesColor> SeriesColors => Set<SeriesColor>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ContinuityDepartment".</summary>
    public DbSet<SeriesContinuityDepartment> SeriesContinuityDepartments => Set<SeriesContinuityDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_CostumeDepartment".</summary>
    public DbSet<SeriesCostumeDepartment> SeriesCostumeDepartments => Set<SeriesCostumeDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_CostumeDesign".</summary>
    public DbSet<SeriesCostumeDesign> SeriesCostumeDesigns => Set<SeriesCostumeDesign>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Country".</summary>
    public DbSet<SeriesCountry> SeriesCountrys => Set<SeriesCountry>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Cover".</summary>
    public DbSet<SeriesCover> SeriesCovers => Set<SeriesCover>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Creator".</summary>
    public DbSet<SeriesCreator> SeriesCreators => Set<SeriesCreator>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Description".</summary>
    public DbSet<SeriesDescription> SeriesDescriptions => Set<SeriesDescription>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Director".</summary>
    public DbSet<SeriesDirector> SeriesDirectors => Set<SeriesDirector>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Distributor".</summary>
    public DbSet<SeriesDistributor> SeriesDistributors => Set<SeriesDistributor>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_EditorialDepartment".</summary>
    public DbSet<SeriesEditorialDepartment> SeriesEditorialDepartments => Set<SeriesEditorialDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ElectricalDepartment".</summary>
    public DbSet<SeriesElectricalDepartment> SeriesElectricalDepartments => Set<SeriesElectricalDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_FilmEditing".</summary>
    public DbSet<SeriesFilmEditing> SeriesFilmEditings => Set<SeriesFilmEditing>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_FilmLength".</summary>
    public DbSet<SeriesFilmLength> SeriesFilmLengths => Set<SeriesFilmLength>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_FilmingDate".</summary>
    public DbSet<SeriesFilmingDate> SeriesFilmingDates => Set<SeriesFilmingDate>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_FilmingLocation".</summary>
    public DbSet<SeriesFilmingLocation> SeriesFilmingLocations => Set<SeriesFilmingLocation>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Genre".</summary>
    public DbSet<SeriesGenre> SeriesGenres => Set<SeriesGenre>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Image".</summary>
    public DbSet<SeriesImage> SeriesImages => Set<SeriesImage>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Laboratory".</summary>
    public DbSet<SeriesLaboratory> SeriesLaboratorys => Set<SeriesLaboratory>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Language".</summary>
    public DbSet<SeriesLanguage> SeriesLanguages => Set<SeriesLanguage>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_LocationManagement".</summary>
    public DbSet<SeriesLocationManagement> SeriesLocationManagements => Set<SeriesLocationManagement>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Logo".</summary>
    public DbSet<SeriesLogo> SeriesLogos => Set<SeriesLogo>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_MakeupDepartment".</summary>
    public DbSet<SeriesMakeupDepartment> SeriesMakeupDepartments => Set<SeriesMakeupDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Music".</summary>
    public DbSet<SeriesMusic> SeriesMusics => Set<SeriesMusic>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_MusicDepartment".</summary>
    public DbSet<SeriesMusicDepartment> SeriesMusicDepartments => Set<SeriesMusicDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_NegativeFormat".</summary>
    public DbSet<SeriesNegativeFormat> SeriesNegativeFormats => Set<SeriesNegativeFormat>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_OtherCompany".</summary>
    public DbSet<SeriesOtherCompany> SeriesOtherCompanys => Set<SeriesOtherCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_OtherCrew".</summary>
    public DbSet<SeriesOtherCrew> SeriesOtherCrews => Set<SeriesOtherCrew>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Poster".</summary>
    public DbSet<SeriesPoster> SeriesPosters => Set<SeriesPoster>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_PrintedFilmFormat".</summary>
    public DbSet<SeriesPrintedFilmFormat> SeriesPrintedFilmFormats => Set<SeriesPrintedFilmFormat>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Producer".</summary>
    public DbSet<SeriesProducer> SeriesProducers => Set<SeriesProducer>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ProductionCompany".</summary>
    public DbSet<SeriesProductionCompany> SeriesProductionCompanys => Set<SeriesProductionCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ProductionDate".</summary>
    public DbSet<SeriesProductionDate> SeriesProductionDates => Set<SeriesProductionDate>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ProductionDesign".</summary>
    public DbSet<SeriesProductionDesign> SeriesProductionDesigns => Set<SeriesProductionDesign>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_ProductionManagement".</summary>
    public DbSet<SeriesProductionManagement> SeriesProductionManagements => Set<SeriesProductionManagement>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Review".</summary>
    public DbSet<SeriesReview> SeriesReviews => Set<SeriesReview>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Runtime".</summary>
    public DbSet<SeriesRuntime> SeriesRuntimes => Set<SeriesRuntime>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_SetDecoration".</summary>
    public DbSet<SeriesSetDecoration> SeriesSetDecorations => Set<SeriesSetDecoration>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_SoundDepartment".</summary>
    public DbSet<SeriesSoundDepartment> SeriesSoundDepartments => Set<SeriesSoundDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_SoundMix".</summary>
    public DbSet<SeriesSoundMix> SeriesSoundMixs => Set<SeriesSoundMix>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_SpecialEffects".</summary>
    public DbSet<SeriesSpecialEffects> SeriesSpecialEffectsSet => Set<SeriesSpecialEffects>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_SpecialEffectsCompany".</summary>
    public DbSet<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompanys => Set<SeriesSpecialEffectsCompany>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Stunts".</summary>
    public DbSet<SeriesStunts> SeriesStuntsSet => Set<SeriesStunts>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Thanks".</summary>
    public DbSet<SeriesThanks> SeriesThanksSet => Set<SeriesThanks>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_TransportationDepartment".</summary>
    public DbSet<SeriesTransportationDepartment> SeriesTransportationDepartments => Set<SeriesTransportationDepartment>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_User".</summary>
    public DbSet<SeriesUser> SeriesUsers => Set<SeriesUser>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_VisualEffects".</summary>
    public DbSet<SeriesVisualEffects> SeriesVisualEffectsSet => Set<SeriesVisualEffects>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Weblink".</summary>
    public DbSet<SeriesWeblink> SeriesWeblinks => Set<SeriesWeblink>();
    /// <summary>DbSet für die SQLite-Tabelle "Series_Writer".</summary>
    public DbSet<SeriesWriter> SeriesWriters => Set<SeriesWriter>();
    /// <summary>DbSet für die SQLite-Tabelle "Setting".</summary>
    public DbSet<Setting> Settings => Set<Setting>();
    /// <summary>DbSet für die SQLite-Tabelle "SoundDevice".</summary>
    public DbSet<SoundDevice> SoundDevices => Set<SoundDevice>();
    /// <summary>DbSet für die SQLite-Tabelle "SoundMix".</summary>
    public DbSet<SoundMix> SoundMixs => Set<SoundMix>();
    /// <summary>DbSet für die SQLite-Tabelle "SoundMode".</summary>
    public DbSet<SoundMode> SoundModes => Set<SoundMode>();
    /// <summary>DbSet für die SQLite-Tabelle "Status".</summary>
    public DbSet<Status> StatusSet => Set<Status>();
    /// <summary>DbSet für die SQLite-Tabelle "System".</summary>
    public DbSet<SystemEntity> SystemEntitys => Set<SystemEntity>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification".</summary>
    public DbSet<TechnicalSpecification> TechnicalSpecifications => Set<TechnicalSpecification>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_CopyProtection".</summary>
    public DbSet<TechnicalSpecificationCopyProtection> TechnicalSpecificationCopyProtections => Set<TechnicalSpecificationCopyProtection>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_MacOSSprocket".</summary>
    public DbSet<TechnicalSpecificationMacOSSprocket> TechnicalSpecificationMacOSSprockets => Set<TechnicalSpecificationMacOSSprocket>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_MediaType".</summary>
    public DbSet<TechnicalSpecificationMediaType> TechnicalSpecificationMediaTypes => Set<TechnicalSpecificationMediaType>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_MultiplayerGameMode".</summary>
    public DbSet<TechnicalSpecificationMultiplayerGameMode> TechnicalSpecificationMultiplayerGameModes => Set<TechnicalSpecificationMultiplayerGameMode>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_MultiplayerOption".</summary>
    public DbSet<TechnicalSpecificationMultiplayerOption> TechnicalSpecificationMultiplayerOptions => Set<TechnicalSpecificationMultiplayerOption>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_RequiredAdditionalHardware".</summary>
    public DbSet<TechnicalSpecificationRequiredAdditionalHardware> TechnicalSpecificationRequiredAdditionalHardwares => Set<TechnicalSpecificationRequiredAdditionalHardware>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_RequiredInputDevice".</summary>
    public DbSet<TechnicalSpecificationRequiredInputDevice> TechnicalSpecificationRequiredInputDevices => Set<TechnicalSpecificationRequiredInputDevice>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SaveGameMethod".</summary>
    public DbSet<TechnicalSpecificationSaveGameMethod> TechnicalSpecificationSaveGameMethods => Set<TechnicalSpecificationSaveGameMethod>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedAdditionalHardware".</summary>
    public DbSet<TechnicalSpecificationSupportedAdditionalHardware> TechnicalSpecificationSupportedAdditionalHardwares => Set<TechnicalSpecificationSupportedAdditionalHardware>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedControllerType".</summary>
    public DbSet<TechnicalSpecificationSupportedControllerType> TechnicalSpecificationSupportedControllerTypes => Set<TechnicalSpecificationSupportedControllerType>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedDriver".</summary>
    public DbSet<TechnicalSpecificationSupportedDriver> TechnicalSpecificationSupportedDrivers => Set<TechnicalSpecificationSupportedDriver>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedInputDevice".</summary>
    public DbSet<TechnicalSpecificationSupportedInputDevice> TechnicalSpecificationSupportedInputDevices => Set<TechnicalSpecificationSupportedInputDevice>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedInputDeviceFeature".</summary>
    public DbSet<TechnicalSpecificationSupportedInputDeviceFeature> TechnicalSpecificationSupportedInputDeviceFeatures => Set<TechnicalSpecificationSupportedInputDeviceFeature>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedSoundDevice".</summary>
    public DbSet<TechnicalSpecificationSupportedSoundDevice> TechnicalSpecificationSupportedSoundDevices => Set<TechnicalSpecificationSupportedSoundDevice>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedSoundMode".</summary>
    public DbSet<TechnicalSpecificationSupportedSoundMode> TechnicalSpecificationSupportedSoundModes => Set<TechnicalSpecificationSupportedSoundMode>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedVideoMode".</summary>
    public DbSet<TechnicalSpecificationSupportedVideoMode> TechnicalSpecificationSupportedVideoModes => Set<TechnicalSpecificationSupportedVideoMode>();
    /// <summary>DbSet für die SQLite-Tabelle "TechnicalSpecification_SupportedVideoResolution".</summary>
    public DbSet<TechnicalSpecificationSupportedVideoResolution> TechnicalSpecificationSupportedVideoResolutions => Set<TechnicalSpecificationSupportedVideoResolution>();
    /// <summary>DbSet für die SQLite-Tabelle "Text".</summary>
    public DbSet<Text> Texts => Set<Text>();
    /// <summary>DbSet für die SQLite-Tabelle "Text_Author".</summary>
    public DbSet<TextAuthor> TextAuthors => Set<TextAuthor>();
    /// <summary>DbSet für die SQLite-Tabelle "Text_Source".</summary>
    public DbSet<TextSource> TextSources => Set<TextSource>();
    /// <summary>DbSet für die SQLite-Tabelle "Type".</summary>
    public DbSet<Type> Types => Set<Type>();
    /// <summary>DbSet für die SQLite-Tabelle "User".</summary>
    public DbSet<User> Users => Set<User>();
    /// <summary>DbSet für die SQLite-Tabelle "Version".</summary>
    public DbSet<Version> Versions => Set<Version>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame".</summary>
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Award".</summary>
    public DbSet<VideoGameAward> VideoGameAwards => Set<VideoGameAward>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Cast".</summary>
    public DbSet<VideoGameCast> VideoGameCasts => Set<VideoGameCast>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Certification".</summary>
    public DbSet<VideoGameCertification> VideoGameCertifications => Set<VideoGameCertification>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Completion".</summary>
    public DbSet<VideoGameCompletion> VideoGameCompletions => Set<VideoGameCompletion>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Cover".</summary>
    public DbSet<VideoGameCover> VideoGameCovers => Set<VideoGameCover>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Description".</summary>
    public DbSet<VideoGameDescription> VideoGameDescriptions => Set<VideoGameDescription>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Developer".</summary>
    public DbSet<VideoGameDeveloper> VideoGameDevelopers => Set<VideoGameDeveloper>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Difficulty".</summary>
    public DbSet<VideoGameDifficulty> VideoGameDifficultys => Set<VideoGameDifficulty>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Distributor".</summary>
    public DbSet<VideoGameDistributor> VideoGameDistributors => Set<VideoGameDistributor>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Genre".</summary>
    public DbSet<VideoGameGenre> VideoGameGenres => Set<VideoGameGenre>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Image".</summary>
    public DbSet<VideoGameImage> VideoGameImages => Set<VideoGameImage>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Language".</summary>
    public DbSet<VideoGameLanguage> VideoGameLanguages => Set<VideoGameLanguage>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Perspective".</summary>
    public DbSet<VideoGamePerspective> VideoGamePerspectives => Set<VideoGamePerspective>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Publisher".</summary>
    public DbSet<VideoGamePublisher> VideoGamePublishers => Set<VideoGamePublisher>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_ReleaseDate".</summary>
    public DbSet<VideoGameReleaseDate> VideoGameReleaseDates => Set<VideoGameReleaseDate>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Review".</summary>
    public DbSet<VideoGameReview> VideoGameReviews => Set<VideoGameReview>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Score".</summary>
    public DbSet<VideoGameScore> VideoGameScores => Set<VideoGameScore>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Setting".</summary>
    public DbSet<VideoGameSetting> VideoGameSettings => Set<VideoGameSetting>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_User".</summary>
    public DbSet<VideoGameUser> VideoGameUsers => Set<VideoGameUser>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Version".</summary>
    public DbSet<VideoGameVersion> VideoGameVersions => Set<VideoGameVersion>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoGame_Weblink".</summary>
    public DbSet<VideoGameWeblink> VideoGameWeblinks => Set<VideoGameWeblink>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoMode".</summary>
    public DbSet<VideoMode> VideoModes => Set<VideoMode>();
    /// <summary>DbSet für die SQLite-Tabelle "VideoResolution".</summary>
    public DbSet<VideoResolution> VideoResolutions => Set<VideoResolution>();
    /// <summary>DbSet für die SQLite-Tabelle "Weblink".</summary>
    public DbSet<Weblink> Weblinks => Set<Weblink>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Alle tabellenspezifischen Fluent-API-Konfigurationen automatisch laden.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
