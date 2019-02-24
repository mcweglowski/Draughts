using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Draughts : IDraughts
    {
        public ICheesboard cheesboard { get; } = new Cheesboard(new CheesboardInitializer());

        public Draughts()
        {
            cheesboard.InitializeGame(new DraughtsGameTwoRowsInitializer());
        }

        public void Move(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField)
        {
            PawnMove pawnMove = new PawnMove(cheesboard);
            pawnMove.Move(sourceField, destinationField);
        }
    }
}
