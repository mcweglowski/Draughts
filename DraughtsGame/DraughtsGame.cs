using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsGame
    {
        ICheesboard cheesboard = new Cheesboard(new CheesboardInitializer());

        public DraughtsGame()
        {
        }
    }
}
