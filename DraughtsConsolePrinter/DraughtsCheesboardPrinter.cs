using DraughtsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsConsolePrinter
{
    public class DraughtsCheesboardPrinter
    {
        ICheesboard cheesboard;
        public DraughtsCheesboardPrinter()
        {
            
        }
        public DraughtsCheesboardPrinter(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void printCheesboard(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;

            Console.Clear();

            PrintTopColumnNames();

            for (CheesboardRow Row = CheesboardRow.Eight; Row > 0; Row-- )
            {
                for (CheesboardColumn Column = CheesboardColumn.A; (int)Column <= cheesboard.GetCheesboardWidth(); Column++)
                {

                }
            }
        }

        private void PrintTopColumnNames()
        {
            StringBuilder TopColumnNames = new StringBuilder();
            TopColumnNames.Append("  ");

            foreach (string ColumnName in Enum.GetNames(typeof(CheesboardColumn)))
            {
                TopColumnNames.AppendFormat(" {0}", ColumnName);
            }
        }
    }
}
