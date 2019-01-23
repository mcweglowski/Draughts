using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnMove : IPawnMove
    {
        ICheesboard cheesboard;

        private PawnMove()
        {

        }

        public PawnMove(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField)
        {
            IPawn pawn = cheesboard.PickPawn(sourceField);
            cheesboard.SetPawn(destinationField, pawn);
        }
    }
}
