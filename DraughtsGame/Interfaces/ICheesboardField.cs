using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboardField
    {
        FieldColor GetColor();
        void SetColor(FieldColor fieldColor);
        IPawn PickPawn();
        IPawn GetPawn();
        void SetPawn(IPawn pawn);
        bool IsEmpty();
    }
}
