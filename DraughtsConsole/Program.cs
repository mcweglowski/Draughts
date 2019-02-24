using DraughtsConsolePrinter;
using DraughtsGame;
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
            Draughts draughtsGame = new Draughts();
            DraughtsCheesboardPrinter draughtsCheesboardPrinter = new DraughtsCheesboardPrinter(draughtsGame.cheesboard);
            draughtsCheesboardPrinter.PrintCheesboard();

            Console.ReadKey();
        }
    }
}
