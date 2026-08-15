namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification".</summary>
public class TechnicalSpecification : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PlatformID".</summary>
    public string? PlatformID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "BusinessModelID".</summary>
    public string? BusinessModelID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MinimumCPUClassID".</summary>
    public string? MinimumCPUClassID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MinimumOSClassID".</summary>
    public string? MinimumOSClassID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MinimumRAMID".</summary>
    public string? MinimumRAMID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MinimumDirectXID".</summary>
    public string? MinimumDirectXID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MinimumCDRomDriveSpeedID".</summary>
    public string? MinimumCDRomDriveSpeedID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MinimumVideoRAMID".</summary>
    public string? MinimumVideoRAMID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NoOfPlayersOffline".</summary>
    public string? NoOfPlayersOffline { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NoOfPlayersOfflineMultitap".</summary>
    public string? NoOfPlayersOfflineMultitap { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NoOfPlayersOnline".</summary>
    public string? NoOfPlayersOnline { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Annotation".</summary>
    public string? Annotation { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MiscAttributes".</summary>
    public string? MiscAttributes { get; set; }

    /// <summary>Navigation über FK BusinessModelID → BusinessModel.ID.</summary>
    public BusinessModel? BusinessModel { get; set; }

    /// <summary>Navigation über FK MinimumCDRomDriveSpeedID → CDROMDriveSpeed.ID.</summary>
    public CDROMDriveSpeed? CDROMDriveSpeed { get; set; }

    /// <summary>Navigation über FK MinimumCPUClassID → CPU.ID.</summary>
    public CPU? CPU { get; set; }

    /// <summary>Navigation über FK MinimumDirectXID → DirectX.ID.</summary>
    public DirectX? DirectX { get; set; }

    /// <summary>Navigation über FK MinimumOSClassID → OperatingSystem.ID.</summary>
    public OperatingSystem? OperatingSystem { get; set; }

    /// <summary>Navigation über FK MinimumRAMID → RAM.ID.</summary>
    public RAM? RAMByMinimumRAMID { get; set; }

    /// <summary>Navigation über FK MinimumVideoRAMID → RAM.ID.</summary>
    public RAM? RAMByMinimumVideoRAMID { get; set; }

    /// <summary>Navigation über FK PlatformID → Platform.ID.</summary>
    public Platform? Platform { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationCopyProtection> TechnicalSpecificationCopyProtectionByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationCopyProtection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocket> TechnicalSpecificationMacOSSprocketByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationMacOSSprocket>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationMediaType> TechnicalSpecificationMediaTypeByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationMediaType>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameMode> TechnicalSpecificationMultiplayerGameModeByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationMultiplayerGameMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOption> TechnicalSpecificationMultiplayerOptionByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationMultiplayerOption>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardware> TechnicalSpecificationRequiredAdditionalHardwareByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardware>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDevice> TechnicalSpecificationRequiredInputDeviceByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationRequiredInputDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethod> TechnicalSpecificationSaveGameMethodByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSaveGameMethod>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardware> TechnicalSpecificationSupportedAdditionalHardwareByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardware>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedControllerType> TechnicalSpecificationSupportedControllerTypeByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedControllerType>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedDriver> TechnicalSpecificationSupportedDriverByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedDriver>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDevice> TechnicalSpecificationSupportedInputDeviceByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedInputDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeature> TechnicalSpecificationSupportedInputDeviceFeatureByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeature>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDevice> TechnicalSpecificationSupportedSoundDeviceByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedSoundDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundMode> TechnicalSpecificationSupportedSoundModeByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedSoundMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoMode> TechnicalSpecificationSupportedVideoModeByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedVideoMode>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "TechnicalSpecification" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolution> TechnicalSpecificationSupportedVideoResolutionByTechnicalSpecificationID { get; set; } = new List<TechnicalSpecificationSupportedVideoResolution>();

}
