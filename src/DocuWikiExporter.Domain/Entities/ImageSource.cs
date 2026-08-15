namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Image_Source".</summary>
public class ImageSource : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "ImageID".</summary>
    public string? ImageID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CompanyID".</summary>
    public string? CompanyID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK CompanyID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation über FK ImageID → Image.ID.</summary>
    public Image? Image { get; set; }

}
