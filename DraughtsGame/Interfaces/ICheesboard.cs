using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates);
        bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates);
        void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor);
        void SetPawn(CheesboardFieldCoordinates fieldCoordinates, IPawn pawn);
        IPawn PickPawn(CheesboardFieldCoordinates fieldCoordinates);
        IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
    }
}
