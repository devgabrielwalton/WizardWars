using System;
using WizardWarsLibrary.Enums;
using WizardWarsLibrary.Logic;
using WizardWarsLibrary.Models;

namespace WizardWars
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WelcomeMessage();

            PlayerInfoModel activePlayer = CreatePlayer("Wizard 1");
            PlayerInfoModel opponent = CreatePlayer("Wizard 2");
            PlayerInfoModel winner = null;

            while (winner == null)
            {
                DisplaySpellGrid(activePlayer);
                RecordPlayerSpell(activePlayer, opponent);

                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                if (doesGameContinue)
                {
                    (activePlayer, opponent) = (opponent, activePlayer);
                }
                else
                {
                    winner = activePlayer;
                }
            }

            IdentifyWinner(winner);

            Console.ReadLine();
        }

        private static void IdentifyWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"{ winner.PlayerName } won the Wizard War!");
            Console.WriteLine($"{ winner.PlayerName } took { GameLogic.GetSpellCount(winner) } spells.");
        }

        private static void RecordPlayerSpell(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            bool isValidSpell = false;
            string row = string.Empty;
            int column = 0;

            while (!isValidSpell)
            {
                string spell = AskForSpell(activePlayer);
                try
                {
                    (row, column) = GameLogic.SplitSpellIntoRowAndColumn(spell);
                    isValidSpell = GameLogic.ValidateSpell(activePlayer, row, column);
                }
                catch (Exception)
                {
                    isValidSpell = false;
                }

                if (!isValidSpell)
                {
                    Console.WriteLine("Invalid spell location. Please try again.");
                }
            }

            bool isAHit = GameLogic.IdentifySpellResult(opponent, row, column);

            GameLogic.MarkSpellResult(activePlayer, row, column, isAHit);

            DisplaySpellResult(row, column, isAHit);
        }

        private static void DisplaySpellResult(string row, int column, bool isAHit)
        {
            if (isAHit)
            {
                Console.WriteLine();
                Console.WriteLine($"[+]{ row }{ column } is a Hit!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"[-]{ row }{ column } is a Miss.");
            }

            Console.WriteLine();
        }

        private static string AskForSpell(PlayerInfoModel player)
        {
            Console.Write($"{ player.PlayerName }, please enter your spell selection: ");
            string output = Console.ReadLine();

            return output;
        }

        private static void DisplaySpellGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.SpellGrid[0].Letter;

            foreach (var gridLocation in activePlayer.SpellGrid)
            {
                if (gridLocation.Letter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridLocation.Letter;
                }

                if (gridLocation.Status == WizardWarsEnums.LocationStatus.Empty)
                {
                    Console.Write($" { gridLocation.Letter }{ gridLocation.Number } ");
                }
                else if (gridLocation.Status == WizardWarsEnums.LocationStatus.Hit)
                {
                    Console.Write(" X  ");
                }
                else if (gridLocation.Status == WizardWarsEnums.LocationStatus.Miss)
                {
                    Console.Write(" O  ");
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Wizard Wars!");
            Console.WriteLine("created by Gabriel Walton");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            Console.WriteLine($"Player information for { playerTitle }");

            var output = new PlayerInfoModel
            {
                PlayerName = AskForPlayersName()
            };

            GameLogic.InitialiseArena(output);

            PlaceWizards(output);

            Console.Clear();

            return output;
        }

        private static string AskForPlayersName()
        {
            Console.Write("Please enter your name: ");
            var output = Console.ReadLine();

            return output;
        }

        private static void PlaceWizards(PlayerInfoModel playerInfoModel)
        {
            while (playerInfoModel.WizardLocations.Count < 5)
            {
                Console.Write($"Where would you like to place wizard number { playerInfoModel.WizardLocations.Count + 1 }: ");
                var location = Console.ReadLine();

                var isValidLocation = false;

                try
                {
                    isValidLocation = GameLogic.PlaceWizard(playerInfoModel, location);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: { ex.Message }");
                }

                if (!isValidLocation)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }
            }
        }
    }
}