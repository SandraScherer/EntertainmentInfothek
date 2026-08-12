namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Person".</summary>
public class Person : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "FirstName".</summary>
    public string? FirstName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "LastName".</summary>
    public string? LastName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "NameAddOn".</summary>
    public string? NameAddOn { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "BirthName".</summary>
    public string? BirthName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "DateOfBirth".</summary>
    public string? DateOfBirth { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "LocationOfBirthID".</summary>
    public string? LocationOfBirthID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "DateOfDeath".</summary>
    public string? DateOfDeath { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "LocationOfDeathID".</summary>
    public string? LocationOfDeathID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CauseOfDeath".</summary>
    public string? CauseOfDeath { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "EmployerID".</summary>
    public string? EmployerID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Company" (FK EmployerID).</summary>
    public Company? Employer { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Location" (FK LocationOfBirthID).</summary>
    public Location? LocationOfBirth { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Location" (FK LocationOfDeathID).</summary>
    public Location? LocationOfDeath { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Type" (FK TypeID).</summary>
    public Type? Type { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_CostumeDepartment".</summary>
    public ICollection<MovieCostumeDepartment> MovieCostumeDepartment { get; set; } = new List<MovieCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Producer".</summary>
    public ICollection<MovieProducer> MovieProducer { get; set; } = new List<MovieProducer>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionManagement".</summary>
    public ICollection<EpisodeProductionManagement> EpisodeProductionManagement { get; set; } = new List<EpisodeProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Movie_Cast".</summary>
    public ICollection<MovieCast> MovieCast { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze aus "Movie_Cast".</summary>
    public ICollection<MovieCast> MovieCastItems { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze aus "Movie_Cast".</summary>
    public ICollection<MovieCast> MovieCastItems { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze aus "Movie_ArtDirection".</summary>
    public ICollection<MovieArtDirection> MovieArtDirection { get; set; } = new List<MovieArtDirection>();

    /// <summary>Abhängige Datensätze aus "Series_Casting".</summary>
    public ICollection<SeriesCasting> SeriesCasting { get; set; } = new List<SeriesCasting>();

    /// <summary>Abhängige Datensätze aus "Episode_Writer".</summary>
    public ICollection<EpisodeWriter> EpisodeWriter { get; set; } = new List<EpisodeWriter>();

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

    /// <summary>Abhängige Datensätze aus "Movie_SpecialEffects".</summary>
    public ICollection<MovieSpecialEffects> MovieSpecialEffects { get; set; } = new List<MovieSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Series_Stunts".</summary>
    public ICollection<SeriesStunts> SeriesStunts { get; set; } = new List<SeriesStunts>();

    /// <summary>Abhängige Datensätze aus "Episode_CastingDepartment".</summary>
    public ICollection<EpisodeCastingDepartment> EpisodeCastingDepartment { get; set; } = new List<EpisodeCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_MakeupDepartment".</summary>
    public ICollection<EpisodeMakeupDepartment> EpisodeMakeupDepartment { get; set; } = new List<EpisodeMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Cinematography".</summary>
    public ICollection<EpisodeCinematography> EpisodeCinematography { get; set; } = new List<EpisodeCinematography>();

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

    /// <summary>Abhängige Datensätze aus "Series_TransportationDepartment".</summary>
    public ICollection<SeriesTransportationDepartment> SeriesTransportationDepartment { get; set; } = new List<SeriesTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_CostumeDesign".</summary>
    public ICollection<MovieCostumeDesign> MovieCostumeDesign { get; set; } = new List<MovieCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Movie_SoundDepartment".</summary>
    public ICollection<MovieSoundDepartment> MovieSoundDepartment { get; set; } = new List<MovieSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_CostumeDesign".</summary>
    public ICollection<SeriesCostumeDesign> SeriesCostumeDesign { get; set; } = new List<SeriesCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Episode_SpecialEffects".</summary>
    public ICollection<EpisodeSpecialEffects> EpisodeSpecialEffects { get; set; } = new List<EpisodeSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_OtherCrew".</summary>
    public ICollection<EpisodeOtherCrew> EpisodeOtherCrew { get; set; } = new List<EpisodeOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Series_Writer".</summary>
    public ICollection<SeriesWriter> SeriesWriter { get; set; } = new List<SeriesWriter>();

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

    /// <summary>Abhängige Datensätze aus "Movie_CastingDepartment".</summary>
    public ICollection<MovieCastingDepartment> MovieCastingDepartment { get; set; } = new List<MovieCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Award_Person".</summary>
    public ICollection<MovieAwardPerson> MovieAwardPerson { get; set; } = new List<MovieAwardPerson>();

    /// <summary>Abhängige Datensätze aus "Movie_MakeupDepartment".</summary>
    public ICollection<MovieMakeupDepartment> MovieMakeupDepartment { get; set; } = new List<MovieMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_VisualEffects".</summary>
    public ICollection<EpisodeVisualEffects> EpisodeVisualEffects { get; set; } = new List<EpisodeVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmEditing".</summary>
    public ICollection<EpisodeFilmEditing> EpisodeFilmEditing { get; set; } = new List<EpisodeFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Series_Director".</summary>
    public ICollection<SeriesDirector> SeriesDirector { get; set; } = new List<SeriesDirector>();

    /// <summary>Abhängige Datensätze aus "Series_Producer".</summary>
    public ICollection<SeriesProducer> SeriesProducer { get; set; } = new List<SeriesProducer>();

    /// <summary>Abhängige Datensätze aus "Episode_SoundDepartment".</summary>
    public ICollection<EpisodeSoundDepartment> EpisodeSoundDepartment { get; set; } = new List<EpisodeSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_Music".</summary>
    public ICollection<SeriesMusic> SeriesMusic { get; set; } = new List<SeriesMusic>();

    /// <summary>Abhängige Datensätze aus "Movie_TransportationDepartment".</summary>
    public ICollection<MovieTransportationDepartment> MovieTransportationDepartment { get; set; } = new List<MovieTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_EditorialDepartment".</summary>
    public ICollection<SeriesEditorialDepartment> SeriesEditorialDepartment { get; set; } = new List<SeriesEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_AnimationDepartment".</summary>
    public ICollection<MovieAnimationDepartment> MovieAnimationDepartment { get; set; } = new List<MovieAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Casting".</summary>
    public ICollection<EpisodeCasting> EpisodeCasting { get; set; } = new List<EpisodeCasting>();

    /// <summary>Abhängige Datensätze aus "Series_Award_Person".</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPerson { get; set; } = new List<SeriesAwardPerson>();

    /// <summary>Abhängige Datensätze aus "Movie_LocationManagement".</summary>
    public ICollection<MovieLocationManagement> MovieLocationManagement { get; set; } = new List<MovieLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Movie_EditorialDepartment".</summary>
    public ICollection<MovieEditorialDepartment> MovieEditorialDepartment { get; set; } = new List<MovieEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionManagement".</summary>
    public ICollection<SeriesProductionManagement> SeriesProductionManagement { get; set; } = new List<SeriesProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Episode_ContinuityDepartment".</summary>
    public ICollection<EpisodeContinuityDepartment> EpisodeContinuityDepartment { get; set; } = new List<EpisodeContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Cast".</summary>
    public ICollection<EpisodeCast> EpisodeCast { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze aus "Episode_Cast".</summary>
    public ICollection<EpisodeCast> EpisodeCastItems { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze aus "Episode_Cast".</summary>
    public ICollection<EpisodeCast> EpisodeCastItems { get; set; } = new List<EpisodeCast>();

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

    /// <summary>Abhängige Datensätze aus "Series_LocationManagement".</summary>
    public ICollection<SeriesLocationManagement> SeriesLocationManagement { get; set; } = new List<SeriesLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Series_SetDecoration".</summary>
    public ICollection<SeriesSetDecoration> SeriesSetDecoration { get; set; } = new List<SeriesSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Series_ElectricalDepartment".</summary>
    public ICollection<SeriesElectricalDepartment> SeriesElectricalDepartment { get; set; } = new List<SeriesElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ArtDirection".</summary>
    public ICollection<EpisodeArtDirection> EpisodeArtDirection { get; set; } = new List<EpisodeArtDirection>();

    /// <summary>Abhängige Datensätze aus "Series_MakeupDepartment".</summary>
    public ICollection<SeriesMakeupDepartment> SeriesMakeupDepartment { get; set; } = new List<SeriesMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmEditing".</summary>
    public ICollection<MovieFilmEditing> MovieFilmEditing { get; set; } = new List<MovieFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Episode_SetDecoration".</summary>
    public ICollection<EpisodeSetDecoration> EpisodeSetDecoration { get; set; } = new List<EpisodeSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Series_SpecialEffects".</summary>
    public ICollection<SeriesSpecialEffects> SeriesSpecialEffects { get; set; } = new List<SeriesSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_TransportationDepartment".</summary>
    public ICollection<EpisodeTransportationDepartment> EpisodeTransportationDepartment { get; set; } = new List<EpisodeTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionDesign".</summary>
    public ICollection<EpisodeProductionDesign> EpisodeProductionDesign { get; set; } = new List<EpisodeProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Series_ContinuityDepartment".</summary>
    public ICollection<SeriesContinuityDepartment> SeriesContinuityDepartment { get; set; } = new List<SeriesContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_AssistantDirector".</summary>
    public ICollection<MovieAssistantDirector> MovieAssistantDirector { get; set; } = new List<MovieAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Movie_Director".</summary>
    public ICollection<MovieDirector> MovieDirector { get; set; } = new List<MovieDirector>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionManagement".</summary>
    public ICollection<MovieProductionManagement> MovieProductionManagement { get; set; } = new List<MovieProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Series_VisualEffects".</summary>
    public ICollection<SeriesVisualEffects> SeriesVisualEffects { get; set; } = new List<SeriesVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Series_AssistantDirector".</summary>
    public ICollection<SeriesAssistantDirector> SeriesAssistantDirector { get; set; } = new List<SeriesAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Movie_Writer".</summary>
    public ICollection<MovieWriter> MovieWriter { get; set; } = new List<MovieWriter>();

    /// <summary>Abhängige Datensätze aus "Series_Thanks".</summary>
    public ICollection<SeriesThanks> SeriesThanks { get; set; } = new List<SeriesThanks>();

    /// <summary>Abhängige Datensätze aus "Episode_Award_Person".</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPerson { get; set; } = new List<EpisodeAwardPerson>();

    /// <summary>Abhängige Datensätze aus "Series_ArtDirection".</summary>
    public ICollection<SeriesArtDirection> SeriesArtDirection { get; set; } = new List<SeriesArtDirection>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionDesign".</summary>
    public ICollection<MovieProductionDesign> MovieProductionDesign { get; set; } = new List<MovieProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Movie_Casting".</summary>
    public ICollection<MovieCasting> MovieCasting { get; set; } = new List<MovieCasting>();

    /// <summary>Abhängige Datensätze aus "Movie_VisualEffects".</summary>
    public ICollection<MovieVisualEffects> MovieVisualEffects { get; set; } = new List<MovieVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_MusicDepartment".</summary>
    public ICollection<EpisodeMusicDepartment> EpisodeMusicDepartment { get; set; } = new List<EpisodeMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Thanks".</summary>
    public ICollection<MovieThanks> MovieThanks { get; set; } = new List<MovieThanks>();

    /// <summary>Abhängige Datensätze aus "Episode_Producer".</summary>
    public ICollection<EpisodeProducer> EpisodeProducer { get; set; } = new List<EpisodeProducer>();

    /// <summary>Abhängige Datensätze aus "Episode_Music".</summary>
    public ICollection<EpisodeMusic> EpisodeMusic { get; set; } = new List<EpisodeMusic>();

    /// <summary>Abhängige Datensätze aus "Series_OtherCrew".</summary>
    public ICollection<SeriesOtherCrew> SeriesOtherCrew { get; set; } = new List<SeriesOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Series_Cinematography".</summary>
    public ICollection<SeriesCinematography> SeriesCinematography { get; set; } = new List<SeriesCinematography>();

    /// <summary>Abhängige Datensätze aus "Series_Cast".</summary>
    public ICollection<SeriesCast> SeriesCast { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze aus "Series_Cast".</summary>
    public ICollection<SeriesCast> SeriesCastItems { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze aus "Series_Cast".</summary>
    public ICollection<SeriesCast> SeriesCastItems { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze aus "Episode_EditorialDepartment".</summary>
    public ICollection<EpisodeEditorialDepartment> EpisodeEditorialDepartment { get; set; } = new List<EpisodeEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Stunts".</summary>
    public ICollection<EpisodeStunts> EpisodeStunts { get; set; } = new List<EpisodeStunts>();

    /// <summary>Abhängige Datensätze aus "Movie_ElectricalDepartment".</summary>
    public ICollection<MovieElectricalDepartment> MovieElectricalDepartment { get; set; } = new List<MovieElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_AnimationDepartment".</summary>
    public ICollection<EpisodeAnimationDepartment> EpisodeAnimationDepartment { get; set; } = new List<EpisodeAnimationDepartment>();

    /// <summary>Abhängige Datensätze aus "Series_CostumeDepartment".</summary>
    public ICollection<SeriesCostumeDepartment> SeriesCostumeDepartment { get; set; } = new List<SeriesCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Stunts".</summary>
    public ICollection<MovieStunts> MovieStunts { get; set; } = new List<MovieStunts>();

    /// <summary>Abhängige Datensätze aus "Series_MusicDepartment".</summary>
    public ICollection<SeriesMusicDepartment> SeriesMusicDepartment { get; set; } = new List<SeriesMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Movie_Music".</summary>
    public ICollection<MovieMusic> MovieMusic { get; set; } = new List<MovieMusic>();

    /// <summary>Abhängige Datensätze aus "Movie_ArtDepartment".</summary>
    public ICollection<MovieArtDepartment> MovieArtDepartment { get; set; } = new List<MovieArtDepartment>();

}
