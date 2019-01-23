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
        ICheesboard cheesboard;

        private DraughtsPawnMoveValidator()
        {

        }

        public DraughtsPawnMoveValidator(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public bool IsMoveAvaliable(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField)
        {
            if (false == IsFieldEmpty(destinationField))
            {
                return false;
            }

            IList<ICheesboardFieldCoordinates> avaliableDestinationFields = GetAvaliableDestinationFields(sourceField);
            return IsDestinationFieldInAvaliableDestinationFieldsForPawn(destinationField, avaliableDestinationFields);
        }

        private static bool IsDestinationFieldInAvaliableDestinationFieldsForPawn(CheesboardFieldCoordinates destinationField, IList<ICheesboardFieldCoordinates> avaliableDestinationFields)
        {
            return null != avaliableDestinationFields.FirstOrDefault(x => x.Row == destinationField.Row && x.Column == destinationField.Column);
        }

        private IList<ICheesboardFieldCoordinates> GetAvaliableDestinationFields(ICheesboardFieldCoordinates sourceField)
        {
            IList<ICheesboardFieldCoordinates> avaliableDestinationFields = new List<ICheesboardFieldCoordinates>();
            IPawn pawn = cheesboard.GetPawn(sourceField);
            IList<MoveCoordinate> moveCoordinates = pawn.GetMoveCoordinates();
            ICheesboardFieldCoordinates cheesboardFiedAvaliableForBasicMove;

            foreach (MoveCoordinate moveCoordinate in moveCoordinates)
            {
                cheesboardFiedAvaliableForBasicMove = GenerateAvaliableMove(sourceField, moveCoordinate);
                avaliableDestinationFields.Add(cheesboardFiedAvaliableForBasicMove);

                cheesboardFiedAvaliableForBasicMove = GetAvaliableBeatingMove(sourceField, cheesboardFiedAvaliableForBasicMove, moveCoordinate);
                avaliableDestinationFields.Add(cheesboardFiedAvaliableForBasicMove);
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

        private bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            return cheesboard.IsFieldEmpty(fieldCoordinates);
        }
    }
}
