using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        CheeseboardField GetFieldState(CheesboardRow row, CheesboardColumn column);
        void SetFieldState(CheesboardRow row, CheesboardColumn column, CheeseboardField fieldState);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
    }
}
