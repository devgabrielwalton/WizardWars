using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardWarsLibrary.Enums;
using WizardWarsLibrary.Logic;
using WizardWarsLibrary.Models;

namespace WizardWars
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            var activePlayer = CreatePlayer("Wizard 1");
            var opponent = CreatePlayer("Wizard 2");

            PlayerInfoModel winner = null;

            while(winner == null)
            {
                DisplayArena(activePlayer);
                RecordShot(activePlayer, opponent);
            }

            Console.ReadLine();
        }

        private static void RecordShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }

        private static void DisplayArena(PlayerInfoModel activePlayer)
        {
            var currentRow = activePlayer.ShotGrid[0].Letter;

            foreach (var gridLocation in activePlayer.ShotGrid)
            {
                if(gridLocation.Letter != currentRow)
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
                    Console.Write(" X ");
                }
                else if (gridLocation.Status == WizardWarsEnums.LocationStatus.Miss)
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write(" ? ");
                }
            }
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

                var isValidLocation = GameLogic.PlaceWizard(playerInfoModel, location);

                if (!isValidLocation)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }
            }
        }
    }
}
