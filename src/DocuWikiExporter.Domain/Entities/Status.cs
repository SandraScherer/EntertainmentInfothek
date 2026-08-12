namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Status".</summary>
public class Status : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Episode".</summary>
    public ICollection<Episode> Episode { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze aus "Episode".</summary>
    public ICollection<Episode> EpisodeItems { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze aus "Episode".</summary>
    public ICollection<Episode> EpisodeItems { get; set; } = new List<Episode>();

    /// <summary>Abhängige Datensätze aus "Certification".</summary>
    public ICollection<Certification> Certification { get; set; } = new List<Certification>();

    /// <summary>Abhängige Datensätze aus "Movie_CostumeDepartment".</summary>
    public ICollection<MovieCostumeDepartment> MovieCostumeDepartment { get; set; } = new List<MovieCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Producer".</summary>
    public ICollection<MovieProducer> MovieProducer { get; set; } = new List<MovieProducer>();

    /// <summary>Abhängige Datensätze aus "AspectRatio".</summary>
    public ICollection<AspectRatio> AspectRatio { get; set; } = new List<AspectRatio>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionManagement".</summary>
    public ICollection<EpisodeProductionManagement> EpisodeProductionManagement { get; set; } = new List<EpisodeProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Movie_Cast".</summary>
    public ICollection<MovieCast> MovieCast { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze aus "FilmFormat".</summary>
    public ICollection<FilmFormat> FilmFormat { get; set; } = new List<FilmFormat>();

    /// <summary>Abhängige Datensätze aus "Movie_ArtDirection".</summary>
    public ICollection<MovieArtDirection> MovieArtDirection { get; set; } = new List<MovieArtDirection>();

    /// <summary>Abhängige Datensätze aus "Series_Logo".</summary>
    public ICollection<SeriesLogo> SeriesLogo { get; set; } = new List<SeriesLogo>();

    /// <summary>Abhängige Datensätze aus "Series_Casting".</summary>
    public ICollection<SeriesCasting> SeriesCasting { get; set; } = new List<SeriesCasting>();

    /// <summary>Abhängige Datensätze aus "Episode_Writer".</summary>
    public ICollection<EpisodeWriter> EpisodeWriter { get; set; } = new List<EpisodeWriter>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionCompany".</summary>
    public ICollection<EpisodeProductionCompany> EpisodeProductionCompany { get; set; } = new List<EpisodeProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Series_Description".</summary>
    public ICollection<SeriesDescription> SeriesDescription { get; set; } = new List<SeriesDescription>();

    /// <summary>Abhängige Datensätze aus "Series_FilmingLocation".</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocation { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Language".</summary>
    public ICollection<Language> Language { get; set; } = new List<Language>();

    /// <summary>Abhängige Datensätze aus "Movie_MusicDepartment".</summary>
    public ICollection<MovieMusicDepartment> MovieMusicDepartment { get; set; } = new List<MovieMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_CostumeDepartment".</summary>
    public ICollection<EpisodeCostumeDepartment> EpisodeCostumeDepartment { get; set; } = new List<EpisodeCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_CostumeDesign".</summary>
    public ICollection<EpisodeCostumeDesign> EpisodeCostumeDesign { get; set; } = new List<EpisodeCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Episode_ElectricalDepartment".</summary>
    public ICollection<EpisodeElectricalDepartment> EpisodeElectricalDepartment { get; set; } = new List<EpisodeElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ArtDepartment".</summary>
    public ICollection<EpisodeArtDepartment> EpisodeArtDepartment { get; set; } = new List<EpisodeArtDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_ArtDepartment".</summary>
    public ICollection<SeriesArtDepartment> SeriesArtDepartment { get; set; } = new List<SeriesArtDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmingDate".</summary>
    public ICollection<MovieFilmingDate> MovieFilmingDate { get; set; } = new List<MovieFilmingDate>();

    /// <summary>Abhängige Datensätze aus "Movie_SpecialEffects".</summary>
    public ICollection<MovieSpecialEffects> MovieSpecialEffects { get; set; } = new List<MovieSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Genre".</summary>
    public ICollection<Genre> Genre { get; set; } = new List<Genre>();

    /// <summary>Abhängige Datensätze aus "Series_Stunts".</summary>
    public ICollection<SeriesStunts> SeriesStunts { get; set; } = new List<SeriesStunts>();

    /// <summary>Abhängige Datensätze aus "Weblink".</summary>
    public ICollection<Weblink> Weblink { get; set; } = new List<Weblink>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionDate".</summary>
    public ICollection<EpisodeProductionDate> EpisodeProductionDate { get; set; } = new List<EpisodeProductionDate>();

    /// <summary>Abhängige Datensätze aus "Movie_OtherCompany".</summary>
    public ICollection<MovieOtherCompany> MovieOtherCompany { get; set; } = new List<MovieOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Episode_CastingDepartment".</summary>
    public ICollection<EpisodeCastingDepartment> EpisodeCastingDepartment { get; set; } = new List<EpisodeCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Camera".</summary>
    public ICollection<SeriesCamera> SeriesCamera { get; set; } = new List<SeriesCamera>();

    /// <summary>Abhängige Datensätze aus "Movie_PrintedFilmFormat".</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormat { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Abhängige Datensätze aus "Episode_MakeupDepartment".</summary>
    public ICollection<EpisodeMakeupDepartment> EpisodeMakeupDepartment { get; set; } = new List<EpisodeMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Cinematography".</summary>
    public ICollection<EpisodeCinematography> EpisodeCinematography { get; set; } = new List<EpisodeCinematography>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmingLocation".</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocation { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionDesign".</summary>
    public ICollection<SeriesProductionDesign> SeriesProductionDesign { get; set; } = new List<SeriesProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Series_FilmEditing".</summary>
    public ICollection<SeriesFilmEditing> SeriesFilmEditing { get; set; } = new List<SeriesFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Movie_Cinematography".</summary>
    public ICollection<MovieCinematography> MovieCinematography { get; set; } = new List<MovieCinematography>();

    /// <summary>Abhängige Datensätze aus "Series_Creator".</summary>
    public ICollection<SeriesCreator> SeriesCreator { get; set; } = new List<SeriesCreator>();

    /// <summary>Abhängige Datensätze aus "User".</summary>
    public ICollection<User> User { get; set; } = new List<User>();

    /// <summary>Abhängige Datensätze aus "Movie".</summary>
    public ICollection<Movie> Movie { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze aus "Movie".</summary>
    public ICollection<Movie> MovieItems { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze aus "Movie".</summary>
    public ICollection<Movie> MovieItems { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze aus "Person".</summary>
    public ICollection<Person> Person { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze aus "Series_AspectRatio".</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatio { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Abhängige Datensätze aus "Series_TransportationDepartment".</summary>
    public ICollection<SeriesTransportationDepartment> SeriesTransportationDepartment { get; set; } = new List<SeriesTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionDate".</summary>
    public ICollection<MovieProductionDate> MovieProductionDate { get; set; } = new List<MovieProductionDate>();

    /// <summary>Abhängige Datensätze aus "Series_Image".</summary>
    public ICollection<SeriesImage> SeriesImage { get; set; } = new List<SeriesImage>();

    /// <summary>Abhängige Datensätze aus "Series_Certification".</summary>
    public ICollection<SeriesCertification> SeriesCertification { get; set; } = new List<SeriesCertification>();

    /// <summary>Abhängige Datensätze aus "Movie_Image".</summary>
    public ICollection<MovieImage> MovieImage { get; set; } = new List<MovieImage>();

    /// <summary>Abhängige Datensätze aus "Movie_CostumeDesign".</summary>
    public ICollection<MovieCostumeDesign> MovieCostumeDesign { get; set; } = new List<MovieCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Episode_Image".</summary>
    public ICollection<EpisodeImage> EpisodeImage { get; set; } = new List<EpisodeImage>();

    /// <summary>Abhängige Datensätze aus "Movie_SoundDepartment".</summary>
    public ICollection<MovieSoundDepartment> MovieSoundDepartment { get; set; } = new List<MovieSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Country".</summary>
    public ICollection<MovieCountry> MovieCountry { get; set; } = new List<MovieCountry>();

    /// <summary>Abhängige Datensätze aus "Series_CostumeDesign".</summary>
    public ICollection<SeriesCostumeDesign> SeriesCostumeDesign { get; set; } = new List<SeriesCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Episode_SpecialEffects".</summary>
    public ICollection<EpisodeSpecialEffects> EpisodeSpecialEffects { get; set; } = new List<EpisodeSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Movie_Genre".</summary>
    public ICollection<MovieGenre> MovieGenre { get; set; } = new List<MovieGenre>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionDate".</summary>
    public ICollection<SeriesProductionDate> SeriesProductionDate { get; set; } = new List<SeriesProductionDate>();

    /// <summary>Abhängige Datensätze aus "Episode_OtherCrew".</summary>
    public ICollection<EpisodeOtherCrew> EpisodeOtherCrew { get; set; } = new List<EpisodeOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Series_Writer".</summary>
    public ICollection<SeriesWriter> SeriesWriter { get; set; } = new List<SeriesWriter>();

    /// <summary>Abhängige Datensätze aus "Movie_CinematographicProcess".</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcess { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Abhängige Datensätze aus "Movie_OtherCrew".</summary>
    public ICollection<MovieOtherCrew> MovieOtherCrew { get; set; } = new List<MovieOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Movie_ContinuityDepartment".</summary>
    public ICollection<MovieContinuityDepartment> MovieContinuityDepartment { get; set; } = new List<MovieContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_AssistantDirector".</summary>
    public ICollection<EpisodeAssistantDirector> EpisodeAssistantDirector { get; set; } = new List<EpisodeAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Series_AnimationDepartment".</summary>
    public ICollection<SeriesAnimationDepartment> SeriesAnimationDepartment { get; set; } = new List<SeriesAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_SetDecoration".</summary>
    public ICollection<MovieSetDecoration> MovieSetDecoration { get; set; } = new List<MovieSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Series_User".</summary>
    public ICollection<SeriesUser> SeriesUser { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze aus "Series_User".</summary>
    public ICollection<SeriesUser> SeriesUserItems { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze aus "Movie_CastingDepartment".</summary>
    public ICollection<MovieCastingDepartment> MovieCastingDepartment { get; set; } = new List<MovieCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Award_Person".</summary>
    public ICollection<MovieAwardPerson> MovieAwardPerson { get; set; } = new List<MovieAwardPerson>();

    /// <summary>Abhängige Datensätze aus "Movie_MakeupDepartment".</summary>
    public ICollection<MovieMakeupDepartment> MovieMakeupDepartment { get; set; } = new List<MovieMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Award".</summary>
    public ICollection<MovieAward> MovieAward { get; set; } = new List<MovieAward>();

    /// <summary>Abhängige Datensätze aus "Movie_Weblink".</summary>
    public ICollection<MovieWeblink> MovieWeblink { get; set; } = new List<MovieWeblink>();

    /// <summary>Abhängige Datensätze aus "Episode_VisualEffects".</summary>
    public ICollection<EpisodeVisualEffects> EpisodeVisualEffects { get; set; } = new List<EpisodeVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Movie_Distributor".</summary>
    public ICollection<MovieDistributor> MovieDistributor { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze aus "Series_Laboratory".</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratory { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmEditing".</summary>
    public ICollection<EpisodeFilmEditing> EpisodeFilmEditing { get; set; } = new List<EpisodeFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Series_Director".</summary>
    public ICollection<SeriesDirector> SeriesDirector { get; set; } = new List<SeriesDirector>();

    /// <summary>Abhängige Datensätze aus "Series_Producer".</summary>
    public ICollection<SeriesProducer> SeriesProducer { get; set; } = new List<SeriesProducer>();

    /// <summary>Abhängige Datensätze aus "Episode_SoundDepartment".</summary>
    public ICollection<EpisodeSoundDepartment> EpisodeSoundDepartment { get; set; } = new List<EpisodeSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmLength".</summary>
    public ICollection<MovieFilmLength> MovieFilmLength { get; set; } = new List<MovieFilmLength>();

    /// <summary>Abhängige Datensätze aus "Movie_Laboratory".</summary>
    public ICollection<MovieLaboratory> MovieLaboratory { get; set; } = new List<MovieLaboratory>();

    /// <summary>Abhängige Datensätze aus "Connection".</summary>
    public ICollection<Connection> Connection { get; set; } = new List<Connection>();

    /// <summary>Abhängige Datensätze aus "Series_Genre".</summary>
    public ICollection<SeriesGenre> SeriesGenre { get; set; } = new List<SeriesGenre>();

    /// <summary>Abhängige Datensätze aus "Series_Language".</summary>
    public ICollection<SeriesLanguage> SeriesLanguage { get; set; } = new List<SeriesLanguage>();

    /// <summary>Abhängige Datensätze aus "Series_Music".</summary>
    public ICollection<SeriesMusic> SeriesMusic { get; set; } = new List<SeriesMusic>();

    /// <summary>Abhängige Datensätze aus "Movie_TransportationDepartment".</summary>
    public ICollection<MovieTransportationDepartment> MovieTransportationDepartment { get; set; } = new List<MovieTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Camera".</summary>
    public ICollection<Camera> Camera { get; set; } = new List<Camera>();

    /// <summary>Abhängige Datensätze aus "Series_EditorialDepartment".</summary>
    public ICollection<SeriesEditorialDepartment> SeriesEditorialDepartment { get; set; } = new List<SeriesEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_AnimationDepartment".</summary>
    public ICollection<MovieAnimationDepartment> MovieAnimationDepartment { get; set; } = new List<MovieAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Poster".</summary>
    public ICollection<SeriesPoster> SeriesPoster { get; set; } = new List<SeriesPoster>();

    /// <summary>Abhängige Datensätze aus "Episode_OtherCompany".</summary>
    public ICollection<EpisodeOtherCompany> EpisodeOtherCompany { get; set; } = new List<EpisodeOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_SoundMix".</summary>
    public ICollection<MovieSoundMix> MovieSoundMix { get; set; } = new List<MovieSoundMix>();

    /// <summary>Abhängige Datensätze aus "Movie_User".</summary>
    public ICollection<MovieUser> MovieUser { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze aus "Movie_User".</summary>
    public ICollection<MovieUser> MovieUserItems { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze aus "Episode_Casting".</summary>
    public ICollection<EpisodeCasting> EpisodeCasting { get; set; } = new List<EpisodeCasting>();

    /// <summary>Abhängige Datensätze aus "Series_FilmLength".</summary>
    public ICollection<SeriesFilmLength> SeriesFilmLength { get; set; } = new List<SeriesFilmLength>();

    /// <summary>Abhängige Datensätze aus "Series_Award_Person".</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPerson { get; set; } = new List<SeriesAwardPerson>();

    /// <summary>Abhängige Datensätze aus "Movie_LocationManagement".</summary>
    public ICollection<MovieLocationManagement> MovieLocationManagement { get; set; } = new List<MovieLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Movie_AspectRatio".</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatio { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Abhängige Datensätze aus "Movie_EditorialDepartment".</summary>
    public ICollection<MovieEditorialDepartment> MovieEditorialDepartment { get; set; } = new List<MovieEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Color".</summary>
    public ICollection<SeriesColor> SeriesColor { get; set; } = new List<SeriesColor>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionManagement".</summary>
    public ICollection<SeriesProductionManagement> SeriesProductionManagement { get; set; } = new List<SeriesProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Episode_ContinuityDepartment".</summary>
    public ICollection<EpisodeContinuityDepartment> EpisodeContinuityDepartment { get; set; } = new List<EpisodeContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_SoundMix".</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMix { get; set; } = new List<SeriesSoundMix>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionCompany".</summary>
    public ICollection<SeriesProductionCompany> SeriesProductionCompany { get; set; } = new List<SeriesProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Series_FilmingDate".</summary>
    public ICollection<SeriesFilmingDate> SeriesFilmingDate { get; set; } = new List<SeriesFilmingDate>();

    /// <summary>Abhängige Datensätze aus "Episode_Cast".</summary>
    public ICollection<EpisodeCast> EpisodeCast { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze aus "Series_SoundDepartment".</summary>
    public ICollection<SeriesSoundDepartment> SeriesSoundDepartment { get; set; } = new List<SeriesSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Director".</summary>
    public ICollection<EpisodeDirector> EpisodeDirector { get; set; } = new List<EpisodeDirector>();

    /// <summary>Abhängige Datensätze aus "Episode_LocationManagement".</summary>
    public ICollection<EpisodeLocationManagement> EpisodeLocationManagement { get; set; } = new List<EpisodeLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Episode_Thanks".</summary>
    public ICollection<EpisodeThanks> EpisodeThanks { get; set; } = new List<EpisodeThanks>();

    /// <summary>Abhängige Datensätze aus "Series_CastingDepartment".</summary>
    public ICollection<SeriesCastingDepartment> SeriesCastingDepartment { get; set; } = new List<SeriesCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Distributor".</summary>
    public ICollection<SeriesDistributor> SeriesDistributor { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze aus "Series_LocationManagement".</summary>
    public ICollection<SeriesLocationManagement> SeriesLocationManagement { get; set; } = new List<SeriesLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Series_NegativeFormat".</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormat { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Abhängige Datensätze aus "Type".</summary>
    public ICollection<Type> Type { get; set; } = new List<Type>();

    /// <summary>Abhängige Datensätze aus "Series_SetDecoration".</summary>
    public ICollection<SeriesSetDecoration> SeriesSetDecoration { get; set; } = new List<SeriesSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Series_Review".</summary>
    public ICollection<SeriesReview> SeriesReview { get; set; } = new List<SeriesReview>();

    /// <summary>Abhängige Datensätze aus "Series_ElectricalDepartment".</summary>
    public ICollection<SeriesElectricalDepartment> SeriesElectricalDepartment { get; set; } = new List<SeriesElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ArtDirection".</summary>
    public ICollection<EpisodeArtDirection> EpisodeArtDirection { get; set; } = new List<EpisodeArtDirection>();

    /// <summary>Abhängige Datensätze aus "Series_MakeupDepartment".</summary>
    public ICollection<SeriesMakeupDepartment> SeriesMakeupDepartment { get; set; } = new List<SeriesMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Review".</summary>
    public ICollection<EpisodeReview> EpisodeReview { get; set; } = new List<EpisodeReview>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmEditing".</summary>
    public ICollection<MovieFilmEditing> MovieFilmEditing { get; set; } = new List<MovieFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Episode_SetDecoration".</summary>
    public ICollection<EpisodeSetDecoration> EpisodeSetDecoration { get; set; } = new List<EpisodeSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Series_SpecialEffects".</summary>
    public ICollection<SeriesSpecialEffects> SeriesSpecialEffects { get; set; } = new List<SeriesSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Color".</summary>
    public ICollection<Color> Color { get; set; } = new List<Color>();

    /// <summary>Abhängige Datensätze aus "Series_Cover".</summary>
    public ICollection<SeriesCover> SeriesCover { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze aus "Movie_Color".</summary>
    public ICollection<MovieColor> MovieColor { get; set; } = new List<MovieColor>();

    /// <summary>Abhängige Datensätze aus "Episode_TransportationDepartment".</summary>
    public ICollection<EpisodeTransportationDepartment> EpisodeTransportationDepartment { get; set; } = new List<EpisodeTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Description".</summary>
    public ICollection<MovieDescription> MovieDescription { get; set; } = new List<MovieDescription>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionDesign".</summary>
    public ICollection<EpisodeProductionDesign> EpisodeProductionDesign { get; set; } = new List<EpisodeProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Series_ContinuityDepartment".</summary>
    public ICollection<SeriesContinuityDepartment> SeriesContinuityDepartment { get; set; } = new List<SeriesContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_AssistantDirector".</summary>
    public ICollection<MovieAssistantDirector> MovieAssistantDirector { get; set; } = new List<MovieAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Image".</summary>
    public ICollection<Image> Image { get; set; } = new List<Image>();

    /// <summary>Abhängige Datensätze aus "Movie_Camera".</summary>
    public ICollection<MovieCamera> MovieCamera { get; set; } = new List<MovieCamera>();

    /// <summary>Abhängige Datensätze aus "Movie_Poster".</summary>
    public ICollection<MoviePoster> MoviePoster { get; set; } = new List<MoviePoster>();

    /// <summary>Abhängige Datensätze aus "Movie_Director".</summary>
    public ICollection<MovieDirector> MovieDirector { get; set; } = new List<MovieDirector>();

    /// <summary>Abhängige Datensätze aus "Episode_Award".</summary>
    public ICollection<EpisodeAward> EpisodeAward { get; set; } = new List<EpisodeAward>();

    /// <summary>Abhängige Datensätze aus "Series_Award".</summary>
    public ICollection<SeriesAward> SeriesAward { get; set; } = new List<SeriesAward>();

    /// <summary>Abhängige Datensätze aus "Series_SpecialEffectsCompany".</summary>
    public ICollection<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompany { get; set; } = new List<SeriesSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionManagement".</summary>
    public ICollection<MovieProductionManagement> MovieProductionManagement { get; set; } = new List<MovieProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Series_VisualEffects".</summary>
    public ICollection<SeriesVisualEffects> SeriesVisualEffects { get; set; } = new List<SeriesVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Series_AssistantDirector".</summary>
    public ICollection<SeriesAssistantDirector> SeriesAssistantDirector { get; set; } = new List<SeriesAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Series_Weblink".</summary>
    public ICollection<SeriesWeblink> SeriesWeblink { get; set; } = new List<SeriesWeblink>();

    /// <summary>Abhängige Datensätze aus "Movie_SpecialEffectsCompany".</summary>
    public ICollection<MovieSpecialEffectsCompany> MovieSpecialEffectsCompany { get; set; } = new List<MovieSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_Writer".</summary>
    public ICollection<MovieWriter> MovieWriter { get; set; } = new List<MovieWriter>();

    /// <summary>Abhängige Datensätze aus "Series_Thanks".</summary>
    public ICollection<SeriesThanks> SeriesThanks { get; set; } = new List<SeriesThanks>();

    /// <summary>Abhängige Datensätze aus "Series_Country".</summary>
    public ICollection<SeriesCountry> SeriesCountry { get; set; } = new List<SeriesCountry>();

    /// <summary>Abhängige Datensätze aus "Episode_Award_Person".</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPerson { get; set; } = new List<EpisodeAwardPerson>();

    /// <summary>Abhängige Datensätze aus "Series_ArtDirection".</summary>
    public ICollection<SeriesArtDirection> SeriesArtDirection { get; set; } = new List<SeriesArtDirection>();

    /// <summary>Abhängige Datensätze aus "SoundMix".</summary>
    public ICollection<SoundMix> SoundMix { get; set; } = new List<SoundMix>();

    /// <summary>Abhängige Datensätze aus "Movie_Cover".</summary>
    public ICollection<MovieCover> MovieCover { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionCompany".</summary>
    public ICollection<MovieProductionCompany> MovieProductionCompany { get; set; } = new List<MovieProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionDesign".</summary>
    public ICollection<MovieProductionDesign> MovieProductionDesign { get; set; } = new List<MovieProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Priority".</summary>
    public ICollection<Priority> Priority { get; set; } = new List<Priority>();

    /// <summary>Abhängige Datensätze aus "Movie_Casting".</summary>
    public ICollection<MovieCasting> MovieCasting { get; set; } = new List<MovieCasting>();

    /// <summary>Abhängige Datensätze aus "Episode_Distributor".</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributor { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze aus "Country".</summary>
    public ICollection<Country> Country { get; set; } = new List<Country>();

    /// <summary>Abhängige Datensätze aus "Status".</summary>
    public ICollection<Status> Status { get; set; } = new List<Status>();

    /// <summary>Abhängige Datensätze aus "Series".</summary>
    public ICollection<Series> Series { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze aus "Series".</summary>
    public ICollection<Series> SeriesItems { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze aus "Series".</summary>
    public ICollection<Series> SeriesItems { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze aus "Movie_Language".</summary>
    public ICollection<MovieLanguage> MovieLanguage { get; set; } = new List<MovieLanguage>();

    /// <summary>Abhängige Datensätze aus "Location".</summary>
    public ICollection<Location> Location { get; set; } = new List<Location>();

    /// <summary>Abhängige Datensätze aus "Episode_SpecialEffectsCompany".</summary>
    public ICollection<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompany { get; set; } = new List<EpisodeSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_Certification".</summary>
    public ICollection<MovieCertification> MovieCertification { get; set; } = new List<MovieCertification>();

    /// <summary>Abhängige Datensätze aus "Movie_VisualEffects".</summary>
    public ICollection<MovieVisualEffects> MovieVisualEffects { get; set; } = new List<MovieVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_MusicDepartment".</summary>
    public ICollection<EpisodeMusicDepartment> EpisodeMusicDepartment { get; set; } = new List<EpisodeMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Review".</summary>
    public ICollection<MovieReview> MovieReview { get; set; } = new List<MovieReview>();

    /// <summary>Abhängige Datensätze aus "Company".</summary>
    public ICollection<Company> Company { get; set; } = new List<Company>();

    /// <summary>Abhängige Datensätze aus "Episode_Description".</summary>
    public ICollection<EpisodeDescription> EpisodeDescription { get; set; } = new List<EpisodeDescription>();

    /// <summary>Abhängige Datensätze aus "Movie_Thanks".</summary>
    public ICollection<MovieThanks> MovieThanks { get; set; } = new List<MovieThanks>();

    /// <summary>Abhängige Datensätze aus "Series_PrintedFilmFormat".</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormat { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Abhängige Datensätze aus "Episode_Producer".</summary>
    public ICollection<EpisodeProducer> EpisodeProducer { get; set; } = new List<EpisodeProducer>();

    /// <summary>Abhängige Datensätze aus "Episode_Music".</summary>
    public ICollection<EpisodeMusic> EpisodeMusic { get; set; } = new List<EpisodeMusic>();

    /// <summary>Abhängige Datensätze aus "CinematographicProcess".</summary>
    public ICollection<CinematographicProcess> CinematographicProcess { get; set; } = new List<CinematographicProcess>();

    /// <summary>Abhängige Datensätze aus "Series_OtherCrew".</summary>
    public ICollection<SeriesOtherCrew> SeriesOtherCrew { get; set; } = new List<SeriesOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmingLocation".</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocation { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Series_Cinematography".</summary>
    public ICollection<SeriesCinematography> SeriesCinematography { get; set; } = new List<SeriesCinematography>();

    /// <summary>Abhängige Datensätze aus "Series_Runtime".</summary>
    public ICollection<SeriesRuntime> SeriesRuntime { get; set; } = new List<SeriesRuntime>();

    /// <summary>Abhängige Datensätze aus "Series_Cast".</summary>
    public ICollection<SeriesCast> SeriesCast { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze aus "Edition".</summary>
    public ICollection<Edition> Edition { get; set; } = new List<Edition>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmingDate".</summary>
    public ICollection<EpisodeFilmingDate> EpisodeFilmingDate { get; set; } = new List<EpisodeFilmingDate>();

    /// <summary>Abhängige Datensätze aus "Movie_NegativeFormat".</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormat { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Abhängige Datensätze aus "Episode_EditorialDepartment".</summary>
    public ICollection<EpisodeEditorialDepartment> EpisodeEditorialDepartment { get; set; } = new List<EpisodeEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Stunts".</summary>
    public ICollection<EpisodeStunts> EpisodeStunts { get; set; } = new List<EpisodeStunts>();

    /// <summary>Abhängige Datensätze aus "Movie_ElectricalDepartment".</summary>
    public ICollection<MovieElectricalDepartment> MovieElectricalDepartment { get; set; } = new List<MovieElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_AnimationDepartment".</summary>
    public ICollection<EpisodeAnimationDepartment> EpisodeAnimationDepartment { get; set; } = new List<EpisodeAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_CinematographicProcess".</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcess { get; set; } = new List<SeriesCinematographicProcess>();

    /// <summary>Abhängige Datensätze aus "Series_CostumeDepartment".</summary>
    public ICollection<SeriesCostumeDepartment> SeriesCostumeDepartment { get; set; } = new List<SeriesCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Stunts".</summary>
    public ICollection<MovieStunts> MovieStunts { get; set; } = new List<MovieStunts>();

    /// <summary>Abhängige Datensätze aus "Series_MusicDepartment".</summary>
    public ICollection<SeriesMusicDepartment> SeriesMusicDepartment { get; set; } = new List<SeriesMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Runtime".</summary>
    public ICollection<MovieRuntime> MovieRuntime { get; set; } = new List<MovieRuntime>();

    /// <summary>Abhängige Datensätze aus "Text".</summary>
    public ICollection<Text> Text { get; set; } = new List<Text>();

    /// <summary>Abhängige Datensätze aus "Award".</summary>
    public ICollection<Award> Award { get; set; } = new List<Award>();

    /// <summary>Abhängige Datensätze aus "Laboratory".</summary>
    public ICollection<Laboratory> Laboratory { get; set; } = new List<Laboratory>();

    /// <summary>Abhängige Datensätze aus "Movie_Music".</summary>
    public ICollection<MovieMusic> MovieMusic { get; set; } = new List<MovieMusic>();

    /// <summary>Abhängige Datensätze aus "Movie_ArtDepartment".</summary>
    public ICollection<MovieArtDepartment> MovieArtDepartment { get; set; } = new List<MovieArtDepartment>();

}
