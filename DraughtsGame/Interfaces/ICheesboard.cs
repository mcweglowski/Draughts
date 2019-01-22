using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        FieldColor GetFieldColor(CheesboardFieldCoordinates fieldCoordinates);
        bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates);
        void SetFieldColor(CheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor);
        void SetPawn(CheesboardFieldCoordinates fieldCoordinates, IPawn pawn);
        IPawn PickPawn(CheesboardFieldCoordinates fieldCoordinates);
        IPawn GetPawn(CheesboardFieldCoordinates fieldCoordinates);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
    }
}
