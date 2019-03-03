using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class ActivePlayerManager : IActivePlayerManager
    {
        public PlayerColor ActivePlayer => throw new NotImplementedException();

        public void SwitchPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
