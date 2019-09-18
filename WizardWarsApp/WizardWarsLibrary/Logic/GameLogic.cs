using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardWarsLibrary.Enums;
using WizardWarsLibrary.Models;


namespace WizardWarsLibrary.Logic
{
    public static class GameLogic
    {
        public static void InitialiseGrid(PlayerInfoModel playerInfoModel)
        {
            var letters = new List<string> { "A", "B", "C", "D", "E", };
            var numbers = new List<int> { 1, 2, 3, 4, 5, };

            foreach (var letter in letters)
            {
                foreach(var number in numbers)
                {
                    AddGridSpot(playerInfoModel, letter, number);
                }
            }
        }

        private static void AddGridSpot(PlayerInfoModel playerInfoModel, string letter, int number)
        {
            var location = new GridLocationModel()
            {
                Letter = letter,
                Number = number,
                Status = WizardWarsEnums.LocationStatus.Empty
            };

            playerInfoModel.ShotGrid.Add(location);
        }

        public static bool PlaceWizard(PlayerInfoModel playerInfoModel, string location)
        {
            throw new NotImplementedException();
        }
    }
}
