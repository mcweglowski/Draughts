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

        public void PrintCheesboard()
        {

            string ColumnNames = PrintTopColumnNames();

            IList<string> cheesboardRows = new List<string>();
            StringBuilder cheesboardRow = new StringBuilder();

            for (CheesboardRow Row = CheesboardRow.Eight; Row >= 0; Row-- )
            {
                cheesboardRow.Clear();
                cheesboardRow.AppendFormat("{0} ", ((int)Row) +1);
                for (CheesboardColumn Column = CheesboardColumn.A; (int)Column <= cheesboard.GetCheesboardWidth(); Column++)
                {
                    CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(Row, Column);
                    FieldColor currentFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);
                    IPawn currentPawn = cheesboard.GetPawn(cheesboardFieldCoordinates);
                    string printField = GetPrint(currentFieldColor, currentPawn);
                    cheesboardRow.Append(printField);
                }
                cheesboardRows.Add(cheesboardRow.ToString());
            }

            Console.Clear();
            Console.WriteLine(ColumnNames);
            Console.WriteLine();
            foreach (string printRow in cheesboardRows)
            {
                Console.WriteLine(printRow);
            }
        }

        private string GetPrint(FieldColor fieldColor, IPawn pawn)
        {
            if (FieldColor.White == fieldColor)
            {
                return "OO";
            }

            PlayerColor playerColor = pawn.GetPlayerColor();

            if (PlayerColor.Red == playerColor)
            {
                return "RR";
            }

            if (PlayerColor.White == playerColor)
            {
                return "WW";
            }

            return "  ";
        }

        private string PrintTopColumnNames()
        {
            StringBuilder TopColumnNames = new StringBuilder();
            TopColumnNames.Append("  ");

            for (int ColumnIndex = 0; ColumnIndex < cheesboard.GetCheesboardWidth(); ColumnIndex++)
            {
                TopColumnNames.AppendFormat("{0}{0}", cheesboard.GetColumnName(ColumnIndex));
            }

            return TopColumnNames.ToString();
        }
    }
}
