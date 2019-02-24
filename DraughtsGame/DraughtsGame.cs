using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Draughts
    {
        public ICheesboard cheesboard { get; } = new Cheesboard(new CheesboardInitializer());

        public Draughts()
        {
            cheesboard.InitializeGame(new DraughtsGameTwoRowsInitializer());
        }
    }
}
