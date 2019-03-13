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
        bool IsFieldEmpty(ICheesboardFieldCoordinates fieldCoordinates);
		bool IsFieldOccupied(CheesboardFieldCoordinates fieldCoordinates);
        void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor);
        void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn);
        IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates);
        IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates);
        int GetCheesboardWidth();
        int GetCheesboardHeight();
        void InitializeGame(IGameInitializer gameInitializer);
        string GetColumnName(int index);
        string GetRowName(int index);
    }
}
