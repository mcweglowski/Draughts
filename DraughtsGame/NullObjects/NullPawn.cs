using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.NullObjects
{
    public class NullPawn : IPawn
    {
        private readonly IList<MoveCoordinate> MoveDirections = new List<MoveCoordinate>();
        public PlayerColor GetPlayerColor()
        {
            return PlayerColor.NotDefined;
        }

        public bool Move(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField)
        {
            return false;
        }

        IList<MoveCoordinate> IPawn.GetMoveCoordinates()
        {
            return MoveDirections;
        }
    }
}
