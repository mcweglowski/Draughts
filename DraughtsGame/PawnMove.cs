using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnMove : IMove
    {
        ICheesboard cheesboard;

        public static readonly IMove Null = new NullMove();
        private PawnMove()
        {

        }

        public PawnMove(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public bool Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField)
        {
            IPawn pawn = cheesboard.PickPawn(sourceField);
            cheesboard.SetPawn(destinationField, pawn);

            return true;
        }
    }
}
