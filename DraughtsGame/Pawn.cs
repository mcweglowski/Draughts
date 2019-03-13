using DraughtsGame.Interfaces;
using DraughtsGame.NullObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Pawn : IPawn
    {
        public static readonly IPawn Null = new NullPawn();
        private PlayerColor PawnColor { get; set; }

        public IList<MoveCoordinate> MoveDirections { get; set; } = new List<MoveCoordinate>();

        private ICheesboard cheesboard;

        public Pawn(PlayerColor pawnColor, IList<MoveCoordinate> moveCoordinates, ICheesboard cheesboard)
        {
            this.PawnColor = pawnColor;
            this.MoveDirections = moveCoordinates;
            this.cheesboard = cheesboard;
        }
        public Pawn(PlayerColor pawnColor)
        {
            this.PawnColor = pawnColor;
            this.MoveDirections = new List<MoveCoordinate>();
        }

        public IList<MoveCoordinate> GetMoveCoordinates()
        {
            return MoveDirections;
        }

        public PlayerColor GetPlayerColor()
        {
            return PawnColor;
        }

        public bool Move(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField)
        {
            DraughtsPawnMoveValidator draughtsPawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);

            IMove move = draughtsPawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            return move.Move(sourceField, destinationField);
        }
    }
}
