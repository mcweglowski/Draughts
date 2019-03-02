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
            IDraughtsEngine draughtsGame = new DraughtsEngine();
            DraughtsCheesboardPrinter draughtsCheesboardPrinter = new DraughtsCheesboardPrinter(draughtsGame.cheesboard);
            draughtsCheesboardPrinter.PrintCheesboard();

            Console.WriteLine("");
            Console.WriteLine("Make move...");
            Console.ReadKey();


            CheesboardFieldCoordinates sourceFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C);
            draughtsGame.Move(sourceFieldCoordinates, destinationFieldCoordinates);

            draughtsCheesboardPrinter.PrintCheesboard();

            Console.ReadKey();
        }
    }
}
