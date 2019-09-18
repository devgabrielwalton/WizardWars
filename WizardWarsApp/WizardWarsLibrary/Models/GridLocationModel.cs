using static WizardWarsLibrary.Enums.WizardWarsEnums;

namespace WizardWarsLibrary.Models
{
    public class GridLocationModel
    {
        public string Letter { get; set; }
        public int Number { get; set; }
        public LocationStatus Status { get; set; } = LocationStatus.Empty;
    }
}