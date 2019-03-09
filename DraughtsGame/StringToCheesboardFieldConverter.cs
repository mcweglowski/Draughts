using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class StringToCheesboardFieldConverter
    {
        public ICheesboardFieldCoordinates Convert(string coordinates)
        {
            if (false == IsTwoCharsInCoordinates(coordinates))
            {
                return CheesboardFieldCoordinates.Null;
            }

            coordinates = coordinates.ToUpper();
            char column = coordinates[0];
            char row = coordinates[1];

            CheesboardColumn cheesboardColumn = ConvertCharToColumn(column);
            CheesboardRow cheesboardRow = ConvertCharToRow(row);

            return GenerateCheesboardFieldCoordinates(cheesboardColumn, cheesboardRow);
        }

        private CheesboardRow ConvertCharToRow(char row)
        {
            switch (row)
            {
                case '1':
                    return CheesboardRow.One;
                case '2':
                    return CheesboardRow.Two;
                case '3':
                    return CheesboardRow.Three;
                case '4':
                    return CheesboardRow.Four;
                case '5':
                    return CheesboardRow.Five;
                case '6':
                    return CheesboardRow.Six;
                case '7':
                    return CheesboardRow.Seven;
                case '8':
                    return CheesboardRow.Eight;
                default:
                    return CheesboardRow.NotDefined;
            }
        }

        private CheesboardColumn ConvertCharToColumn(char column)
        {
            switch (column)
            {
                case 'A':
                    return CheesboardColumn.A;
                case 'B':
                    return CheesboardColumn.B;
                case 'C':
                    return CheesboardColumn.C;
                case 'D':
                    return CheesboardColumn.D;
                case 'E':
                    return CheesboardColumn.E;
                case 'F':
                    return CheesboardColumn.F;
                case 'G':
                    return CheesboardColumn.G;
                case 'H':
                    return CheesboardColumn.H;
                default:
                    return CheesboardColumn.NotDefined;
            }
        }
        private bool IsTwoCharsInCoordinates(string coordinates)
        {
            return 2 == coordinates.Length;
        }

        private ICheesboardFieldCoordinates GenerateCheesboardFieldCoordinates(CheesboardColumn column, CheesboardRow row)
        {
            if (CheesboardColumn.NotDefined != column && CheesboardRow.NotDefined != row)
            {
                return new CheesboardFieldCoordinates(row, column);
            }

            return CheesboardFieldCoordinates.Null;
        }
    }
}
