using System.Collections.Generic;

namespace WizardWarsLibrary.Models
{
    public class PlayerInfoModel
    {
        public string PlayerName { get; set; }
        public List<GridLocationModel> WizardLocations { get; set; } = new List<GridLocationModel>();
        public List<GridLocationModel> SpellGrid { get; set; } = new List<GridLocationModel>();
    }
}