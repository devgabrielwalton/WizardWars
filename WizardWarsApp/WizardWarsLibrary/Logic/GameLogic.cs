using System;
using System.Collections.Generic;
using WizardWarsLibrary.Enums;
using WizardWarsLibrary.Models;

namespace WizardWarsLibrary.Logic
{
    public static class GameLogic
    {
        public static void InitialiseArena(PlayerInfoModel playerInfoModel)
        {
            var letters = new List<string> { "A", "B", "C", "D", "E", };
            var numbers = new List<int> { 1, 2, 3, 4, 5, };

            foreach (var letter in letters)
            {
                foreach (var number in numbers)
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

            playerInfoModel.SpellGrid.Add(location);
        }

        public static bool PlaceWizard(PlayerInfoModel playerInfoModel, string location)
        {
            throw new NotImplementedException();
        }

        public static bool PlayerStillActive(PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }

        public static int GetSpellCount(PlayerInfoModel winner)
        {
            throw new NotImplementedException();
        }

        public static (string row, int column) SplitSpellIntoRowAndColumn(string spell)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateSpell(PlayerInfoModel activePlayer, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static bool IdentifySpellResult(PlayerInfoModel opponent, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static void MarkSpellResult(PlayerInfoModel activePlayer, string row, int column, bool isSuccefulSpell)
        {
            throw new NotImplementedException();
        }
    }
}