using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.NullObjects
{
    public class NullCheesboardField : ICheesboardField
    {
        public FieldColor GetColor()
        {
            return FieldColor.NotDefined;
        }

        public IPawn GetPawn()
        {
            return Pawn.Null;
        }

        public bool IsEmpty()
        {
            return false;
        }

        public IPawn PickPawn()
        {
            return Pawn.Null;
        }

        public void SetColor(FieldColor fieldColor)
        {
        }

        public void SetPawn(IPawn pawn)
        {
        }
    }
}
