using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnMove
    {
        ICheesboard cheesboard;
        public PawnMove(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void Move(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField)
        {
            IPawn pawn = cheesboard.PickPawn(sourceField);
            cheesboard.SetPawn(destinationField, pawn);
        }
    }
}
