using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsPawnMoveValidator
    {
        private ICheesboard cheesboard;

        private DraughtsPawnMoveValidator()
        {

        }

        public DraughtsPawnMoveValidator(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public IMove IsMoveAvaliable(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates destinationField)
        {
            if (false == IsFieldEmpty(destinationField))
            {
                return PawnMove.Null;
            }

            IList<MoveParameters> avaliableDestinationFields = GetAvaliableDestinationFields(sourceField);
            return IsDestinationFieldInAvaliableDestinationFieldsForPawn(destinationField, avaliableDestinationFields);
        }

        private IMove IsDestinationFieldInAvaliableDestinationFieldsForPawn(ICheesboardFieldCoordinates destinationField, IList<MoveParameters> avaliableDestinationFields)
        {
            MoveType moveType = avaliableDestinationFields.Where(x => x.CheesboardFieldCoordinates.Row == destinationField.Row && x.CheesboardFieldCoordinates.Column == destinationField.Column).Select(x => x.MoveType).DefaultIfEmpty(MoveType.None).FirstOrDefault();

            switch (moveType)
            {
                case MoveType.Move:
                        return new PawnMove(cheesboard);
                case MoveType.Beat:
                        return new PawnBeat(cheesboard);
                case MoveType.None:
                        return new NullMove();
                default:
                    throw new Exception("Fatal error: not implemented move type.");
            }
        }

        private IList<MoveParameters> GetAvaliableDestinationFields(ICheesboardFieldCoordinates sourceField)
        {
            IList<MoveParameters> avaliableDestinationFields = new List<MoveParameters>();
            IPawn pawn = cheesboard.GetPawn(sourceField);
            IList<MoveCoordinate> moveCoordinates = pawn.GetMoveCoordinates();
            ICheesboardFieldCoordinates cheesboardFiedAvaliableForBasicMove;

            foreach (MoveCoordinate moveCoordinate in moveCoordinates)
            {
                cheesboardFiedAvaliableForBasicMove = GenerateAvaliableMove(sourceField, moveCoordinate);
                avaliableDestinationFields.Add(new MoveParameters() { CheesboardFieldCoordinates = cheesboardFiedAvaliableForBasicMove, MoveType = MoveType.Move } );

                cheesboardFiedAvaliableForBasicMove = GetAvaliableBeatingMove(sourceField, cheesboardFiedAvaliableForBasicMove, moveCoordinate);
                avaliableDestinationFields.Add(new MoveParameters() { CheesboardFieldCoordinates = cheesboardFiedAvaliableForBasicMove, MoveType = MoveType.Beat }) ;
            }

            return avaliableDestinationFields;
        }

        private ICheesboardFieldCoordinates GenerateAvaliableMove(ICheesboardFieldCoordinates sourceField, MoveCoordinate moveCoordinate)
        {
            CheesboardRow avaliableCheesboardRow = sourceField.Row + moveCoordinate.Row;
            CheesboardColumn avaliableCheesboardColumn = sourceField.Column + moveCoordinate.Column;

            return new CheesboardFieldCoordinates(avaliableCheesboardRow, avaliableCheesboardColumn);
        }

        private ICheesboardFieldCoordinates GetAvaliableBeatingMove(ICheesboardFieldCoordinates sourceField, ICheesboardFieldCoordinates cheesboardFiedAvaliableForBasicMove, MoveCoordinate moveCoordinate)
        {
            IPawn PawnDuringMove = cheesboard.GetPawn(sourceField);
            IPawn PawnInMiddleField = cheesboard.GetPawn(cheesboardFiedAvaliableForBasicMove);

            if (true == IsPawnInTheMiddleDifferentColorThanMovedPawn(PawnDuringMove, PawnInMiddleField))
            {
                return GenerateAvaliableMove(cheesboardFiedAvaliableForBasicMove, moveCoordinate);
            }

            return CheesboardFieldCoordinates.Null;
        }

        private bool IsPawnInTheMiddleDifferentColorThanMovedPawn(IPawn PawnDuringMove, IPawn PawnInTheMiddle)
        {
            if (Pawn.Null == PawnInTheMiddle)
            {
                return false;
            }

            if (PawnDuringMove.GetPlayerColor() == PawnInTheMiddle.GetPlayerColor())
            {
                return false;
            }

            return true;
        }

        private bool IsFieldEmpty(ICheesboardFieldCoordinates fieldCoordinates)
        {
            return cheesboard.IsFieldEmpty(fieldCoordinates);
        }
    }
    
    public class MoveParameters
    {
        public ICheesboardFieldCoordinates CheesboardFieldCoordinates { get; set; }
        public MoveType MoveType { get; set; }
    }
}
