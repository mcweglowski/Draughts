using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Cheesboard : ICheesboard
    {
        private DraughtsField[,] cheesboard = new DraughtsField[8, 8];
        private const int WidthDimension = 0;
        private const int HeightDimension = 1;

        public int GetCheesboardHeight()
        {
            return cheesboard.GetLength(HeightDimension);
        }

        public int GetCheesboardWith()
        {
            return cheesboard.GetLength(WidthDimension);
        }

        public DraughtsField GetFieldState(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void SetFieldState(int row, int column, DraughtsField fieldState)
        {
            throw new NotImplementedException();
        }
    }
}
