using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Cheesboard : ICheesboard
    {

        private CheesboardField[,] cheesboard = new CheesboardField[Enum.GetNames(typeof(CheesboardColumn)).Length, Enum.GetNames(typeof(CheesboardRow)).Length];
        private const int WidthDimension = 0;
        private const int HeightDimension = 1;

        public int GetCheesboardHeight()
        {
            return cheesboard.GetLength(HeightDimension);
        }

        public int GetCheesboardWidth()
        {
            return cheesboard.GetLength(WidthDimension);
        }

        public CheesboardField GetFieldState(CheesboardFieldCoordinates fieldCoordinates)
        {
            return cheesboard[(int)fieldCoordinates.Row, (int)fieldCoordinates.Column];
        }

        public void SetFieldState(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
            cheesboard[(int)fieldCoordinates.Row, (int)fieldCoordinates.Column] = fieldState;
        }
    }
}
