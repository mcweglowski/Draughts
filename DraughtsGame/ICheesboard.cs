using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        CheesboardField GetFieldState(CheesboardFieldCoordinates fieldCoordinates);
        void SetFieldState(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
    }
}
