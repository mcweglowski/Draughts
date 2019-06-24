using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsGameTwoRowsInitializer : IInitializer
    {
        private ICheesboard cheesboard;

        public DraughtsGameTwoRowsInitializer()
        {

        }

        public DraughtsGameTwoRowsInitializer(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        private void InitializeNewGame(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
            InitializeNewGame();
        }


        public void InitializeNewGame()
        {
            SetupWhitePawns();
            SetupRedPawns();
        }

        private void SetupRedPawns()
        {
            PlayerColor playerColor = PlayerColor.Red;

            IList<MoveCoordinate> newPawnMoveCoordinates = GetMoveCoordinates(playerColor);

            CheesboardFieldCoordinates fieldCoordinates = new CheesboardFieldCoordinates();
            for (fieldCoordinates.Row = CheesboardRow.Seven; fieldCoordinates.Row <= CheesboardRow.Eight; fieldCoordinates.Row++ )
            {
                for (fieldCoordinates.Column = GetFirstBlackFieldForRow(fieldCoordinates.Row); (int)fieldCoordinates.Column < cheesboard.GetCheesboardWidth(); fieldCoordinates.Column = fieldCoordinates.Column + 2)
                {
                    cheesboard.SetPawn(fieldCoordinates, new Pawn(playerColor, newPawnMoveCoordinates, cheesboard));
                }
            }
        }

        private void SetupWhitePawns()
        {
            PlayerColor playerColor = PlayerColor.White;

            IList<MoveCoordinate> newPawnMoveCoordinates = GetMoveCoordinates(playerColor);
            CheesboardFieldCoordinates fieldCoordinates = new CheesboardFieldCoordinates();

            for (fieldCoordinates.Row = CheesboardRow.One; fieldCoordinates.Row < CheesboardRow.Three; fieldCoordinates.Row++)
            {
                for (fieldCoordinates.Column = GetFirstBlackFieldForRow(fieldCoordinates.Row); (int)fieldCoordinates.Column < cheesboard.GetCheesboardWidth(); fieldCoordinates.Column = fieldCoordinates.Column + 2)
                {
                    cheesboard.SetPawn(fieldCoordinates, new Pawn(playerColor, newPawnMoveCoordinates, cheesboard));
                }
            }
        }


        private IList<MoveCoordinate> GetMoveCoordinates(PlayerColor playerColor)
        {
            IList<MoveCoordinate> moveCoordinates = new List<MoveCoordinate>();
            int direction = GetRowDirection(playerColor);
            moveCoordinates.Add(new MoveCoordinate(direction, +1));
            moveCoordinates.Add(new MoveCoordinate(direction, -1));

            return moveCoordinates; ;
        }

        private int GetRowDirection(PlayerColor playerColor)
        {
            if (PlayerColor.Red == playerColor)
                return -1;
            return 1;
        }

        private CheesboardColumn GetFirstBlackFieldForRow(CheesboardRow Row)
        {
            if (0 == (int)Row % 2)
            {
                return CheesboardColumn.A;
            }

            return CheesboardColumn.B;
        }

        public void Initialize(ICheesboard cheesboard)
        {
            InitializeNewGame(cheesboard);
        }
    }
}
