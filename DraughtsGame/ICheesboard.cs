using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        DraughtsField GetFieldState(int row, int column);
        void SetFieldState(int row, int column, DraughtsField fieldState);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
    }
}
