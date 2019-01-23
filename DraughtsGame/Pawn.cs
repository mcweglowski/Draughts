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

        public Pawn(PlayerColor pawnColor, IList<MoveCoordinate> moveCoordinates)
        {
            this.PawnColor = pawnColor;
            this.MoveDirections = moveCoordinates;
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

        private class NullPawn : IPawn
        {
            private readonly IList<MoveCoordinate> MoveDirections = new List<MoveCoordinate>();
            public PlayerColor GetPlayerColor()
            {
                return PlayerColor.NotDefined;
            }

            IList<MoveCoordinate> IPawn.GetMoveCoordinates()
            {
                return MoveDirections;
            }
        }

    }
}
