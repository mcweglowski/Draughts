using DraughtsGame.NullObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class CheesboardField : ICheesboardField
    {
        public static readonly ICheesboardField Null = new NullCheesboardField();
        private FieldColor fieldColor;
        private IPawn pawn = Pawn.Null;

        private CheesboardField()
        {

        }
        public CheesboardField(FieldColor fieldColor)
        {
            this.fieldColor = fieldColor;
        }
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

        public void SetPawn(IPawn pawn)
        {
            this.pawn = pawn;
        }
    }
}
