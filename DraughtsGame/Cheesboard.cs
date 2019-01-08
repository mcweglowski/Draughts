using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Cheesboard : ICheesboard
    {

        private CheeseboardField[,] cheesboard = new CheeseboardField[Enum.GetNames(typeof(CheesboardColumn)).Length, Enum.GetNames(typeof(CheesboardRow)).Length];
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

        public CheeseboardField GetFieldState(CheesboardRow row, CheesboardColumn column)
        {
            return cheesboard[(int)row, (int)column];
        }

        public void SetFieldState(CheesboardRow row, CheesboardColumn column, CheeseboardField fieldState)
        {
            throw new NotImplementedException();
        }
    }
}
