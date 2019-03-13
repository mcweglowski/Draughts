using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Interfaces
{
    public interface IDraughtsEngine
    {
        ICheesboard Cheesboard { get; }
        bool Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField);
        bool Move(string sourceField, string destinationField);
        string GameCommand { get; }
        PlayerColor ActivePlayer { get; }
    }
}
