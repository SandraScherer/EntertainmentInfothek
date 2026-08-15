namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Publication_Language".</summary>
public class PublicationLanguage : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "PublicationID".</summary>
    public string? PublicationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LanguageID".</summary>
    public string? LanguageID { get; set; }

    /// <summary>Navigation über FK LanguageID → Language.ID.</summary>
    public Language? Language { get; set; }

    /// <summary>Navigation über FK PublicationID → Publication.ID.</summary>
    public Publication? Publication { get; set; }

}
