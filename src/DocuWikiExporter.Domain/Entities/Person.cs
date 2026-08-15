namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Person".</summary>
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

    /// <summary>Navigation über FK EmployerID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation über FK LocationOfBirthID → Location.ID.</summary>
    public Location? LocationByLocationOfBirthID { get; set; }

    /// <summary>Navigation über FK LocationOfDeathID → Location.ID.</summary>
    public Location? LocationByLocationOfDeathID { get; set; }

    /// <summary>Navigation über FK TypeID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<BookCast> BookCastByCharacterID { get; set; } = new List<BookCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<BookWriter> BookWriterByPersonID { get; set; } = new List<BookWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeAnimationDepartment> EpisodeAnimationDepartmentByPersonID { get; set; } = new List<EpisodeAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeArtDepartment> EpisodeArtDepartmentByPersonID { get; set; } = new List<EpisodeArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeArtDirection> EpisodeArtDirectionByPersonID { get; set; } = new List<EpisodeArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeAssistantDirector> EpisodeAssistantDirectorByPersonID { get; set; } = new List<EpisodeAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPersonByPersonID { get; set; } = new List<EpisodeAwardPerson>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCast> EpisodeCastByActorID { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCast> EpisodeCastByCharacterID { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCast> EpisodeCastByGermanDubberID { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCasting> EpisodeCastingByPersonID { get; set; } = new List<EpisodeCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCastingDepartment> EpisodeCastingDepartmentByPersonID { get; set; } = new List<EpisodeCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCinematography> EpisodeCinematographyByPersonID { get; set; } = new List<EpisodeCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeContinuityDepartment> EpisodeContinuityDepartmentByPersonID { get; set; } = new List<EpisodeContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCostumeDepartment> EpisodeCostumeDepartmentByPersonID { get; set; } = new List<EpisodeCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeCostumeDesign> EpisodeCostumeDesignByPersonID { get; set; } = new List<EpisodeCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeDirector> EpisodeDirectorByPersonID { get; set; } = new List<EpisodeDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeEditorialDepartment> EpisodeEditorialDepartmentByPersonID { get; set; } = new List<EpisodeEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeElectricalDepartment> EpisodeElectricalDepartmentByPersonID { get; set; } = new List<EpisodeElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeFilmEditing> EpisodeFilmEditingByPersonID { get; set; } = new List<EpisodeFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeLocationManagement> EpisodeLocationManagementByPersonID { get; set; } = new List<EpisodeLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeMakeupDepartment> EpisodeMakeupDepartmentByPersonID { get; set; } = new List<EpisodeMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeMusic> EpisodeMusicByPersonID { get; set; } = new List<EpisodeMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeMusicDepartment> EpisodeMusicDepartmentByPersonID { get; set; } = new List<EpisodeMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeOtherCrew> EpisodeOtherCrewByPersonID { get; set; } = new List<EpisodeOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeProducer> EpisodeProducerByPersonID { get; set; } = new List<EpisodeProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeProductionDesign> EpisodeProductionDesignByPersonID { get; set; } = new List<EpisodeProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeProductionManagement> EpisodeProductionManagementByPersonID { get; set; } = new List<EpisodeProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeSetDecoration> EpisodeSetDecorationByPersonID { get; set; } = new List<EpisodeSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeSoundDepartment> EpisodeSoundDepartmentByPersonID { get; set; } = new List<EpisodeSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeSpecialEffects> EpisodeSpecialEffectsByPersonID { get; set; } = new List<EpisodeSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeStunts> EpisodeStuntsByPersonID { get; set; } = new List<EpisodeStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeThanks> EpisodeThanksByPersonID { get; set; } = new List<EpisodeThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeTransportationDepartment> EpisodeTransportationDepartmentByPersonID { get; set; } = new List<EpisodeTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeVisualEffects> EpisodeVisualEffectsByPersonID { get; set; } = new List<EpisodeVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<EpisodeWriter> EpisodeWriterByPersonID { get; set; } = new List<EpisodeWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieAnimationDepartment> MovieAnimationDepartmentByPersonID { get; set; } = new List<MovieAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieArtDepartment> MovieArtDepartmentByPersonID { get; set; } = new List<MovieArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieArtDirection> MovieArtDirectionByPersonID { get; set; } = new List<MovieArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieAssistantDirector> MovieAssistantDirectorByPersonID { get; set; } = new List<MovieAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieAwardPerson> MovieAwardPersonByPersonID { get; set; } = new List<MovieAwardPerson>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCast> MovieCastByActorID { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCast> MovieCastByCharacterID { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCast> MovieCastByGermanDubberID { get; set; } = new List<MovieCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCasting> MovieCastingByPersonID { get; set; } = new List<MovieCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCastingDepartment> MovieCastingDepartmentByPersonID { get; set; } = new List<MovieCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCinematography> MovieCinematographyByPersonID { get; set; } = new List<MovieCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieContinuityDepartment> MovieContinuityDepartmentByPersonID { get; set; } = new List<MovieContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCostumeDepartment> MovieCostumeDepartmentByPersonID { get; set; } = new List<MovieCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieCostumeDesign> MovieCostumeDesignByPersonID { get; set; } = new List<MovieCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieDirector> MovieDirectorByPersonID { get; set; } = new List<MovieDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieEditorialDepartment> MovieEditorialDepartmentByPersonID { get; set; } = new List<MovieEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieElectricalDepartment> MovieElectricalDepartmentByPersonID { get; set; } = new List<MovieElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieFilmEditing> MovieFilmEditingByPersonID { get; set; } = new List<MovieFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieLocationManagement> MovieLocationManagementByPersonID { get; set; } = new List<MovieLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieMakeupDepartment> MovieMakeupDepartmentByPersonID { get; set; } = new List<MovieMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieMusic> MovieMusicByPersonID { get; set; } = new List<MovieMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieMusicDepartment> MovieMusicDepartmentByPersonID { get; set; } = new List<MovieMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieOtherCrew> MovieOtherCrewByPersonID { get; set; } = new List<MovieOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieProducer> MovieProducerByPersonID { get; set; } = new List<MovieProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieProductionDesign> MovieProductionDesignByPersonID { get; set; } = new List<MovieProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieProductionManagement> MovieProductionManagementByPersonID { get; set; } = new List<MovieProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieSetDecoration> MovieSetDecorationByPersonID { get; set; } = new List<MovieSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieSoundDepartment> MovieSoundDepartmentByPersonID { get; set; } = new List<MovieSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieSpecialEffects> MovieSpecialEffectsByPersonID { get; set; } = new List<MovieSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieStunts> MovieStuntsByPersonID { get; set; } = new List<MovieStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieThanks> MovieThanksByPersonID { get; set; } = new List<MovieThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieTransportationDepartment> MovieTransportationDepartmentByPersonID { get; set; } = new List<MovieTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieVisualEffects> MovieVisualEffectsByPersonID { get; set; } = new List<MovieVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<MovieWriter> MovieWriterByPersonID { get; set; } = new List<MovieWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesAnimationDepartment> SeriesAnimationDepartmentByPersonID { get; set; } = new List<SeriesAnimationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesArtDepartment> SeriesArtDepartmentByPersonID { get; set; } = new List<SeriesArtDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesArtDirection> SeriesArtDirectionByPersonID { get; set; } = new List<SeriesArtDirection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesAssistantDirector> SeriesAssistantDirectorByPersonID { get; set; } = new List<SeriesAssistantDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPersonByPersonID { get; set; } = new List<SeriesAwardPerson>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCast> SeriesCastByActorID { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCast> SeriesCastByCharacterID { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCast> SeriesCastByGermanDubberID { get; set; } = new List<SeriesCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCasting> SeriesCastingByPersonID { get; set; } = new List<SeriesCasting>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCastingDepartment> SeriesCastingDepartmentByPersonID { get; set; } = new List<SeriesCastingDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCinematography> SeriesCinematographyByPersonID { get; set; } = new List<SeriesCinematography>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesContinuityDepartment> SeriesContinuityDepartmentByPersonID { get; set; } = new List<SeriesContinuityDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCostumeDepartment> SeriesCostumeDepartmentByPersonID { get; set; } = new List<SeriesCostumeDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCostumeDesign> SeriesCostumeDesignByPersonID { get; set; } = new List<SeriesCostumeDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesCreator> SeriesCreatorByPersonID { get; set; } = new List<SeriesCreator>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesDirector> SeriesDirectorByPersonID { get; set; } = new List<SeriesDirector>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesEditorialDepartment> SeriesEditorialDepartmentByPersonID { get; set; } = new List<SeriesEditorialDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesElectricalDepartment> SeriesElectricalDepartmentByPersonID { get; set; } = new List<SeriesElectricalDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesFilmEditing> SeriesFilmEditingByPersonID { get; set; } = new List<SeriesFilmEditing>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesLocationManagement> SeriesLocationManagementByPersonID { get; set; } = new List<SeriesLocationManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesMakeupDepartment> SeriesMakeupDepartmentByPersonID { get; set; } = new List<SeriesMakeupDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesMusic> SeriesMusicByPersonID { get; set; } = new List<SeriesMusic>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesMusicDepartment> SeriesMusicDepartmentByPersonID { get; set; } = new List<SeriesMusicDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesOtherCrew> SeriesOtherCrewByPersonID { get; set; } = new List<SeriesOtherCrew>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesProducer> SeriesProducerByPersonID { get; set; } = new List<SeriesProducer>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesProductionDesign> SeriesProductionDesignByPersonID { get; set; } = new List<SeriesProductionDesign>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesProductionManagement> SeriesProductionManagementByPersonID { get; set; } = new List<SeriesProductionManagement>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesSetDecoration> SeriesSetDecorationByPersonID { get; set; } = new List<SeriesSetDecoration>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesSoundDepartment> SeriesSoundDepartmentByPersonID { get; set; } = new List<SeriesSoundDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesSpecialEffects> SeriesSpecialEffectsByPersonID { get; set; } = new List<SeriesSpecialEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesStunts> SeriesStuntsByPersonID { get; set; } = new List<SeriesStunts>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesThanks> SeriesThanksByPersonID { get; set; } = new List<SeriesThanks>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesTransportationDepartment> SeriesTransportationDepartmentByPersonID { get; set; } = new List<SeriesTransportationDepartment>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesVisualEffects> SeriesVisualEffectsByPersonID { get; set; } = new List<SeriesVisualEffects>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<SeriesWriter> SeriesWriterByPersonID { get; set; } = new List<SeriesWriter>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<TextAuthor> TextAuthorByPersonID { get; set; } = new List<TextAuthor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<User> UserByPersonID { get; set; } = new List<User>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<VideoGameCast> VideoGameCastByActorID { get; set; } = new List<VideoGameCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<VideoGameCast> VideoGameCastByCharacterID { get; set; } = new List<VideoGameCast>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Person" verweisen.</summary>
    public ICollection<VideoGameCast> VideoGameCastByDubberID { get; set; } = new List<VideoGameCast>();

}
