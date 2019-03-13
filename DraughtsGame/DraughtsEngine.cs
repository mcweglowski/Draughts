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
        public ICheesboard Cheesboard { get; }
        IActivePlayerManager activePlayerManager = new ActivePlayerManager();
        StringToCheesboardFieldConverter stringToCheesboardFieldConverter = new StringToCheesboardFieldConverter();

        public string GameCommand { get; }

        public PlayerColor ActivePlayer
        {
            get { return activePlayerManager.ActivePlayer; }
        }

        private DraughtsEngine()
        {

        }

        public DraughtsEngine(ICheesboard cheesboard, IGameInitializer gameInitializer)
        {
            Cheesboard = cheesboard;
            Cheesboard.InitializeGame(gameInitializer);
        }

        public bool Move(string sourceField, string destinationField)
        {
            ICheesboardFieldCoordinates sourceFieldCoordinates = stringToCheesboardFieldConverter.Convert(sourceField);
            ICheesboardFieldCoordinates destinationFieldCoordinates = stringToCheesboardFieldConverter.Convert(destinationField);

            return Move(sourceFieldCoordinates, destinationFieldCoordinates);

        }

        public bool Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField)
        {
            IPawn pawn = Cheesboard.GetPawn(sourceField);

            if (true == pawn.Move(sourceField, destinationField))
            {
                activePlayerManager.SwitchPlayer();
                return true;
            }

            return false;
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
