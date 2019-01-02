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

        public DraughtsField GetFieldState(string v)
        {
            throw new NotImplementedException();
        }

        public void SetFieldState(string position, DraughtsField fieldState)
        {
            throw new NotImplementedException();
        }
    }
}
