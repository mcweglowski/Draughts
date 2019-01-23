using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnBeat : IPawnMove
    {
        private ICheesboard cheeseboard;

        private PawnBeat()
        {

        }

        public PawnBeat(ICheesboard cheeseboard)
        {
            this.cheeseboard = cheeseboard;
        }

        public void Move(ICheesboardFieldCoordinates sourceFieldCoordinates, ICheesboardFieldCoordinates destinationFieldCoordinates)
        {
            throw new NotImplementedException();
        }
    }
}
