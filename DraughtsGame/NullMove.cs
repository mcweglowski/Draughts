using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class NullMove : IMove
    {
        public bool Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField)
        {
            return false;
        }
    }
}
