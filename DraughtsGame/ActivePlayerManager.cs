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
        private PlayerColor activePlayer;

        public PlayerColor ActivePlayer
        {
            get { return activePlayer; }
        }

        public ActivePlayerManager()
        {
            activePlayer = PlayerColor.White;
        }

        public void SwitchPlayer()
        {
            if (PlayerColor.White == ActivePlayer)
            {
                activePlayer = PlayerColor.Red;
                return;
            }

            activePlayer = PlayerColor.White;
        }
    }
}
