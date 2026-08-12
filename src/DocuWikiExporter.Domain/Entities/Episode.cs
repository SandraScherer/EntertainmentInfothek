namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Episode".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK CastStatusID).</summary>
    public Status? CastStatus { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK CrewStatusID).</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Episode_ProductionManagement".</summary>
    public ICollection<EpisodeProductionManagement> EpisodeProductionManagement { get; set; } = new List<EpisodeProductionManagement>();

    /// <summary>Abhängige Datensätze aus "Episode_Writer".</summary>
    public ICollection<EpisodeWriter> EpisodeWriter { get; set; } = new List<EpisodeWriter>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionCompany".</summary>
    public ICollection<EpisodeProductionCompany> EpisodeProductionCompany { get; set; } = new List<EpisodeProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Episode_CostumeDepartment".</summary>
    public ICollection<EpisodeCostumeDepartment> EpisodeCostumeDepartment { get; set; } = new List<EpisodeCostumeDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_CostumeDesign".</summary>
    public ICollection<EpisodeCostumeDesign> EpisodeCostumeDesign { get; set; } = new List<EpisodeCostumeDesign>();

    /// <summary>Abhängige Datensätze aus "Episode_ElectricalDepartment".</summary>
    public ICollection<EpisodeElectricalDepartment> EpisodeElectricalDepartment { get; set; } = new List<EpisodeElectricalDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ArtDepartment".</summary>
    public ICollection<EpisodeArtDepartment> EpisodeArtDepartment { get; set; } = new List<EpisodeArtDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionDate".</summary>
    public ICollection<EpisodeProductionDate> EpisodeProductionDate { get; set; } = new List<EpisodeProductionDate>();

    /// <summary>Abhängige Datensätze aus "Episode_CastingDepartment".</summary>
    public ICollection<EpisodeCastingDepartment> EpisodeCastingDepartment { get; set; } = new List<EpisodeCastingDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_MakeupDepartment".</summary>
    public ICollection<EpisodeMakeupDepartment> EpisodeMakeupDepartment { get; set; } = new List<EpisodeMakeupDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Cinematography".</summary>
    public ICollection<EpisodeCinematography> EpisodeCinematography { get; set; } = new List<EpisodeCinematography>();

    /// <summary>Abhängige Datensätze aus "Episode_Image".</summary>
    public ICollection<EpisodeImage> EpisodeImage { get; set; } = new List<EpisodeImage>();

    /// <summary>Abhängige Datensätze aus "Episode_SpecialEffects".</summary>
    public ICollection<EpisodeSpecialEffects> EpisodeSpecialEffects { get; set; } = new List<EpisodeSpecialEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_OtherCrew".</summary>
    public ICollection<EpisodeOtherCrew> EpisodeOtherCrew { get; set; } = new List<EpisodeOtherCrew>();

    /// <summary>Abhängige Datensätze aus "Episode_AssistantDirector".</summary>
    public ICollection<EpisodeAssistantDirector> EpisodeAssistantDirector { get; set; } = new List<EpisodeAssistantDirector>();

    /// <summary>Abhängige Datensätze aus "Episode_VisualEffects".</summary>
    public ICollection<EpisodeVisualEffects> EpisodeVisualEffects { get; set; } = new List<EpisodeVisualEffects>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmEditing".</summary>
    public ICollection<EpisodeFilmEditing> EpisodeFilmEditing { get; set; } = new List<EpisodeFilmEditing>();

    /// <summary>Abhängige Datensätze aus "Episode_SoundDepartment".</summary>
    public ICollection<EpisodeSoundDepartment> EpisodeSoundDepartment { get; set; } = new List<EpisodeSoundDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_OtherCompany".</summary>
    public ICollection<EpisodeOtherCompany> EpisodeOtherCompany { get; set; } = new List<EpisodeOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Episode_Casting".</summary>
    public ICollection<EpisodeCasting> EpisodeCasting { get; set; } = new List<EpisodeCasting>();

    /// <summary>Abhängige Datensätze aus "Episode_ContinuityDepartment".</summary>
    public ICollection<EpisodeContinuityDepartment> EpisodeContinuityDepartment { get; set; } = new List<EpisodeContinuityDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Cast".</summary>
    public ICollection<EpisodeCast> EpisodeCast { get; set; } = new List<EpisodeCast>();

    /// <summary>Abhängige Datensätze aus "Episode_Director".</summary>
    public ICollection<EpisodeDirector> EpisodeDirector { get; set; } = new List<EpisodeDirector>();

    /// <summary>Abhängige Datensätze aus "Episode_LocationManagement".</summary>
    public ICollection<EpisodeLocationManagement> EpisodeLocationManagement { get; set; } = new List<EpisodeLocationManagement>();

    /// <summary>Abhängige Datensätze aus "Episode_Thanks".</summary>
    public ICollection<EpisodeThanks> EpisodeThanks { get; set; } = new List<EpisodeThanks>();

    /// <summary>Abhängige Datensätze aus "Episode_ArtDirection".</summary>
    public ICollection<EpisodeArtDirection> EpisodeArtDirection { get; set; } = new List<EpisodeArtDirection>();

    /// <summary>Abhängige Datensätze aus "Episode_Review".</summary>
    public ICollection<EpisodeReview> EpisodeReview { get; set; } = new List<EpisodeReview>();

    /// <summary>Abhängige Datensätze aus "Episode_SetDecoration".</summary>
    public ICollection<EpisodeSetDecoration> EpisodeSetDecoration { get; set; } = new List<EpisodeSetDecoration>();

    /// <summary>Abhängige Datensätze aus "Episode_TransportationDepartment".</summary>
    public ICollection<EpisodeTransportationDepartment> EpisodeTransportationDepartment { get; set; } = new List<EpisodeTransportationDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionDesign".</summary>
    public ICollection<EpisodeProductionDesign> EpisodeProductionDesign { get; set; } = new List<EpisodeProductionDesign>();

    /// <summary>Abhängige Datensätze aus "Episode_Award".</summary>
    public ICollection<EpisodeAward> EpisodeAward { get; set; } = new List<EpisodeAward>();

    /// <summary>Abhängige Datensätze aus "Episode_Distributor".</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributor { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze aus "Episode_SpecialEffectsCompany".</summary>
    public ICollection<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompany { get; set; } = new List<EpisodeSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Episode_MusicDepartment".</summary>
    public ICollection<EpisodeMusicDepartment> EpisodeMusicDepartment { get; set; } = new List<EpisodeMusicDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Description".</summary>
    public ICollection<EpisodeDescription> EpisodeDescription { get; set; } = new List<EpisodeDescription>();

    /// <summary>Abhängige Datensätze aus "Episode_Producer".</summary>
    public ICollection<EpisodeProducer> EpisodeProducer { get; set; } = new List<EpisodeProducer>();

    /// <summary>Abhängige Datensätze aus "Episode_Music".</summary>
    public ICollection<EpisodeMusic> EpisodeMusic { get; set; } = new List<EpisodeMusic>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmingLocation".</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocation { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmingDate".</summary>
    public ICollection<EpisodeFilmingDate> EpisodeFilmingDate { get; set; } = new List<EpisodeFilmingDate>();

    /// <summary>Abhängige Datensätze aus "Episode_EditorialDepartment".</summary>
    public ICollection<EpisodeEditorialDepartment> EpisodeEditorialDepartment { get; set; } = new List<EpisodeEditorialDepartment>();

    /// <summary>Abhängige Datensätze aus "Episode_Stunts".</summary>
    public ICollection<EpisodeStunts> EpisodeStunts { get; set; } = new List<EpisodeStunts>();

    /// <summary>Abhängige Datensätze aus "Episode_AnimationDepartment".</summary>
    public ICollection<EpisodeAnimationDepartment> EpisodeAnimationDepartment { get; set; } = new List<EpisodeAnimationDepartment>();

}
