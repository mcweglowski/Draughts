using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class CheesboardField : ICheesboardField
    {
        public static readonly ICheesboardField Null = new NullField();
        private FieldColor fieldColor;
        private IPawn pawn = Pawn.Null;
        public FieldColor GetColor()
        {
            return fieldColor;
        }

        public IPawn GetPawn()
        {
            return pawn;
        }

        public bool IsEmpty()
        {
            return Pawn.Null == pawn;
        }

        public IPawn PickPawn()
        {
            IPawn pawn = this.pawn;
            this.pawn = Pawn.Null;
            return pawn;
        }

        public void SetColor(FieldColor fieldColor)
        {
            this.fieldColor = fieldColor;
        }

        public void SetPawn(IPawn pawn)
        {
            this.pawn = pawn;
        }

        private class NullField : ICheesboardField
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
}
