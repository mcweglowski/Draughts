using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Interfaces
{
    public interface ICheesboardFieldCoordinates
    {
        CheesboardRow Row { get; }
        CheesboardColumn Column { get; }
        string ToString();
    }
}
