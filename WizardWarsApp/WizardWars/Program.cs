using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardWarsLibrary.Logic;
using WizardWarsLibrary.Models;

namespace WizardWars
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            var player01 = CreatePlayer("Wizard 1");
            var player02 = CreatePlayer("Wizard 2");

            Console.ReadLine();
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

            GameLogic.InitialiseGrid(output);

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
