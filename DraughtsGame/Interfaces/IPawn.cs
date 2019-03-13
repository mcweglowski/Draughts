using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface IPawn
    {
        IList<MoveCoordinate> GetMoveCoordinates();
        PlayerColor GetPlayerColor();
        bool Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField);
    }
}
