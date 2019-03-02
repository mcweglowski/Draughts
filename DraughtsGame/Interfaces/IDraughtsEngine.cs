using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Interfaces
{
    public interface IDraughtsEngine
    {
        ICheesboard cheesboard { get; }
        bool Move(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField);
        string GameCommand { get; }
        PlayerColor ActivePlayer { get; }
    }
}
