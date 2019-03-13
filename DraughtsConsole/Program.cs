using DraughtsConsolePrinter;
using DraughtsGame;
using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IDraughtsEngine draughtsGame = new DraughtsEngine(new Cheesboard(new CheesboardInitializer()), new DraughtsGameTwoRowsInitializer());
            DraughtsCheesboardPrinter draughtsCheesboardPrinter = new DraughtsCheesboardPrinter(draughtsGame.Cheesboard);
            string command = string.Empty;
            ICheesboardFieldCoordinates sourceField = CheesboardFieldCoordinates.Null;
            ICheesboardFieldCoordinates destinationField = CheesboardFieldCoordinates.Null;

            while ("Q" != command)
            {
                draughtsCheesboardPrinter.PrintCheesboard();

                Console.WriteLine();
                Console.WriteLine("Player: " + draughtsGame.ActivePlayer);
                Console.WriteLine("Enter your move...");

                
                command = Console.ReadLine();
                IList<string>moveCoordinates = command.Split(new char[] { ',' });

                draughtsGame.Move(moveCoordinates.ElementAt(0), moveCoordinates.ElementAt(1));
            }

            Console.WriteLine("The End");
            Console.ReadKey();
        }
    }
}
