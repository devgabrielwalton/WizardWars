using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardWarsLibrary.Models
{
    public class PlayerInfoModel
    {
        public string PlayerName { get; set; }
        public List<GridLocationModel> WizardLocations { get; set; }
        public List<GridLocationModel> ShotGrid { get; set; }
    }
}
