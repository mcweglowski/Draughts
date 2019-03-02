using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsEngine : IDraughtsEngine
    {
        public ICheesboard cheesboard { get; } = new Cheesboard(new CheesboardInitializer());

        public string GameCommand { get; }

        private PlayerColor activePlayer;

        public PlayerColor ActivePlayer
        {
            get { return activePlayer; }
        }


        public DraughtsEngine()
        {
            cheesboard.InitializeGame(new DraughtsGameTwoRowsInitializer());
            activePlayer = PlayerColor.White;
        }

        public bool Move(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField)
        {
            PawnMove pawnMove = new PawnMove(cheesboard);
            pawnMove.Move(sourceField, destinationField);

            activePlayer = SwitchPlayer(ActivePlayer);
            return true;
        }

        private PlayerColor SwitchPlayer(PlayerColor activePlayer)
        {
            if (PlayerColor.White == activePlayer)
            {
                return PlayerColor.Red;
            }

            return PlayerColor.White;
        }
    }
}
