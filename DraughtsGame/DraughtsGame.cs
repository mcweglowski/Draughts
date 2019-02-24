using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsGame
    {
        public ICheesboard cheesboard { get; } = new Cheesboard(new CheesboardInitializer());

        public DraughtsGame()
        {
            cheesboard.InitializeGame(new DraughtsGameTwoRowsInitializer());
        }
    }
}
