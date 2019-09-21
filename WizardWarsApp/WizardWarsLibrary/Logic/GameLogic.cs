using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool PlayerStillActive(PlayerInfoModel player)
        {
            bool isActive = false;

            foreach (var wizard in player.WizardLocations)
            {
                if (wizard.Status != WizardWarsEnums.LocationStatus.Killed)
                {
                    isActive = true;
                }
            }

            return isActive;
        }

        public static int GetSpellCount(PlayerInfoModel player)
        {
            var count = 0;

            foreach (var shot in player.SpellGrid)
            {
                if (shot.Status != WizardWarsEnums.LocationStatus.Empty)
                {
                    count++;
                }
            }

            return count;
        }

        public static bool PlaceWizard(PlayerInfoModel playerInfoModel, string location)
        {
            var output = false;

            (string row, int column) = SplitSpellIntoRowAndColumn(location);

            var isValidLocation = ValidateGridLocation(playerInfoModel, row, column);
            var isSpotOpen = ValidateWizardLocation(playerInfoModel, row, column);

            if (isValidLocation && isSpotOpen)
            {
                playerInfoModel.WizardLocations.Add(new GridLocationModel
                {
                    Letter = row.ToUpper(),
                    Number = column,
                    Status = WizardWarsEnums.LocationStatus.Wizard
                });

                output = true;
            }

            return output;
        }

        private static bool ValidateWizardLocation(PlayerInfoModel playerInfoModel, string row, int column)
        {
            var isValidLocation = true;

            foreach (var wizard in playerInfoModel.WizardLocations)
            {
                if (wizard.Letter == row.ToUpper() && wizard.Number == column)
                {
                    isValidLocation = false;
                }
            }

            return isValidLocation;
        }

        private static bool ValidateGridLocation(PlayerInfoModel playerInfoModel, string row, int column)
        {
            var isValidLocation = false;

            foreach (var spot in playerInfoModel.SpellGrid)
            {
                if (spot.Letter == row.ToUpper() && spot.Number == column)
                {
                    isValidLocation = true;
                }
            }

            return isValidLocation;
        }

        public static (string row, int column) SplitSpellIntoRowAndColumn(string spell)
        {
            if (spell.Length != 2)
            {
                throw new ArgumentException("This was an invalid spell type.", "spell");
            }

            var spellArray = spell.ToArray();

            string row = spellArray[0].ToString();
            int column = int.Parse(spellArray[1].ToString());

            return (row, column);
        }

        public static bool ValidateSpell(PlayerInfoModel player, string row, int column)
        {
            var isValidSpell = false;

            foreach (var spot in player.SpellGrid)
            {
                if (spot.Letter == row.ToUpper() && spot.Number == column)
                {
                    if (spot.Status == WizardWarsEnums.LocationStatus.Empty)
                    {
                        isValidSpell = true;
                    }
                }
            }

            return isValidSpell;
        }

        public static bool IdentifySpellResult(PlayerInfoModel opponent, string row, int column)
        {
            var isAHit = false;

            foreach (var wizard in opponent.WizardLocations)
            {
                if (wizard.Letter == row.ToUpper() && wizard.Number == column)
                {
                    isAHit = true;
                }
            }

            return isAHit;
        }

        public static void MarkSpellResult(PlayerInfoModel player, string row, int column, bool isAHit)
        {
            foreach (var spot in player.SpellGrid)
            {
                if (spot.Letter == row.ToUpper() && spot.Number == column)
                {
                    if (isAHit)
                    {
                        spot.Status = WizardWarsEnums.LocationStatus.Hit;
                    }
                    else
                    {
                        spot.Status = WizardWarsEnums.LocationStatus.Miss;
                    }
                }
            }
        }
    }
}