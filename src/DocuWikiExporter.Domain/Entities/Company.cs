namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Company".</summary>
public class Company : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "NameAddOn".</summary>
    public string? NameAddOn { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Type" (FK TypeID).</summary>
    public Type? Type { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_OtherCompany".</summary>
    public ICollection<SeriesOtherCompany> SeriesOtherCompany { get; set; } = new List<SeriesOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Episode_ProductionCompany".</summary>
    public ICollection<EpisodeProductionCompany> EpisodeProductionCompany { get; set; } = new List<EpisodeProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_OtherCompany".</summary>
    public ICollection<MovieOtherCompany> MovieOtherCompany { get; set; } = new List<MovieOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Person".</summary>
    public ICollection<Person> Person { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze aus "Movie_Distributor".</summary>
    public ICollection<MovieDistributor> MovieDistributor { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze aus "Episode_OtherCompany".</summary>
    public ICollection<EpisodeOtherCompany> EpisodeOtherCompany { get; set; } = new List<EpisodeOtherCompany>();

    /// <summary>Abhängige Datensätze aus "Series_ProductionCompany".</summary>
    public ICollection<SeriesProductionCompany> SeriesProductionCompany { get; set; } = new List<SeriesProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Series_Distributor".</summary>
    public ICollection<SeriesDistributor> SeriesDistributor { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze aus "Series_SpecialEffectsCompany".</summary>
    public ICollection<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompany { get; set; } = new List<SeriesSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_SpecialEffectsCompany".</summary>
    public ICollection<MovieSpecialEffectsCompany> MovieSpecialEffectsCompany { get; set; } = new List<MovieSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Movie_ProductionCompany".</summary>
    public ICollection<MovieProductionCompany> MovieProductionCompany { get; set; } = new List<MovieProductionCompany>();

    /// <summary>Abhängige Datensätze aus "Episode_Distributor".</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributor { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze aus "Episode_SpecialEffectsCompany".</summary>
    public ICollection<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompany { get; set; } = new List<EpisodeSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze aus "Award".</summary>
    public ICollection<Award> Award { get; set; } = new List<Award>();

}
