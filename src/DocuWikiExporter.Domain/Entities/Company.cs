namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Company".</summary>
public class Company : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NameAddOn".</summary>
    public string? NameAddOn { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TypeID".</summary>
    public string? TypeID { get; set; }

    /// <summary>Navigation über FK TypeID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<Award> AwardByPresenterID { get; set; } = new List<Award>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributorByCompanyID { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<EpisodeOtherCompany> EpisodeOtherCompanyByCompanyID { get; set; } = new List<EpisodeOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<EpisodeProductionCompany> EpisodeProductionCompanyByCompanyID { get; set; } = new List<EpisodeProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<EpisodeSpecialEffectsCompany> EpisodeSpecialEffectsCompanyByCompanyID { get; set; } = new List<EpisodeSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<ImageSource> ImageSourceByCompanyID { get; set; } = new List<ImageSource>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<MovieDistributor> MovieDistributorByCompanyID { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<MovieOtherCompany> MovieOtherCompanyByCompanyID { get; set; } = new List<MovieOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<MovieProductionCompany> MovieProductionCompanyByCompanyID { get; set; } = new List<MovieProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<MovieSpecialEffectsCompany> MovieSpecialEffectsCompanyByCompanyID { get; set; } = new List<MovieSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<Person> PersonByEmployerID { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<PublicationPublisher> PublicationPublisherByCompanyID { get; set; } = new List<PublicationPublisher>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<SeriesDistributor> SeriesDistributorByCompanyID { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<SeriesOtherCompany> SeriesOtherCompanyByCompanyID { get; set; } = new List<SeriesOtherCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<SeriesProductionCompany> SeriesProductionCompanyByCompanyID { get; set; } = new List<SeriesProductionCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<SeriesSpecialEffectsCompany> SeriesSpecialEffectsCompanyByCompanyID { get; set; } = new List<SeriesSpecialEffectsCompany>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<TextSource> TextSourceByCompanyID { get; set; } = new List<TextSource>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<VideoGameDeveloper> VideoGameDeveloperByCompanyID { get; set; } = new List<VideoGameDeveloper>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<VideoGameDistributor> VideoGameDistributorByCompanyID { get; set; } = new List<VideoGameDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<VideoGamePublisher> VideoGamePublisherByCompanyID { get; set; } = new List<VideoGamePublisher>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Company" verweisen.</summary>
    public ICollection<VideoGameScore> VideoGameScoreByCompanyID { get; set; } = new List<VideoGameScore>();

}
