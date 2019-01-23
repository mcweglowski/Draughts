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
        IPawn PickPawn();
        IPawn GetPawn();
        void SetPawn(IPawn pawn);
        bool IsEmpty();
    }
}
