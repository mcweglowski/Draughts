using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        CheesboardField GetFieldState(CheesboardRow row, CheesboardColumn column);
        void SetFieldState(CheesboardRow row, CheesboardColumn column, CheesboardField fieldState);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
    }
}
