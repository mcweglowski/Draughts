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

            IList<CheesboardFieldCoordinates> avaliableDestinationFields = GetAvaliableDestinationFields(sourceField);
            return IsDestinationFieldInAvaliableDestinationFieldsForPawn(destinationField, avaliableDestinationFields);
        }

        private static bool IsDestinationFieldInAvaliableDestinationFieldsForPawn(CheesboardFieldCoordinates destinationField, IList<CheesboardFieldCoordinates> avaliableDestinationFields)
        {
            return null != avaliableDestinationFields.FirstOrDefault(x => x.Row == destinationField.Row && x.Column == destinationField.Column);
        }

        private IList<CheesboardFieldCoordinates> GetAvaliableDestinationFields(CheesboardFieldCoordinates sourceField)
        {
            IList<CheesboardFieldCoordinates> avaliableDestinationFields = new List<CheesboardFieldCoordinates>();
            IPawn pawn = cheesboard.GetPawn(sourceField);
            IList<MoveCoordinate> moveCoordinates = pawn.GetMoveCoordinates();
            CheesboardFieldCoordinates cheesboardFiedAvaliableForBasicMove;

            foreach (MoveCoordinate moveCoordinate in moveCoordinates)
            {
                cheesboardFiedAvaliableForBasicMove = GetAvaliableBasicMove(sourceField, moveCoordinate);
                if (cheesboardFiedAvaliableForBasicMove != null)
                {
                    avaliableDestinationFields.Add(cheesboardFiedAvaliableForBasicMove);
                }

                cheesboardFiedAvaliableForBasicMove = GetAvaliableBeatingMove(sourceField, cheesboardFiedAvaliableForBasicMove, moveCoordinate);
                if (cheesboardFiedAvaliableForBasicMove != null)
                {
                    avaliableDestinationFields.Add(cheesboardFiedAvaliableForBasicMove);
                }
            }

            return avaliableDestinationFields;
        }

        private CheesboardFieldCoordinates GetAvaliableBasicMove(CheesboardFieldCoordinates sourceField, MoveCoordinate moveCoordinate)
        {
            CheesboardRow avaliableCheesboardRow = sourceField.Row + moveCoordinate.Row;
            CheesboardColumn avaliableCheesboardColumn = sourceField.Column + moveCoordinate.Column;

            return new CheesboardFieldCoordinates(avaliableCheesboardRow, avaliableCheesboardColumn);
        }

        private CheesboardFieldCoordinates GetAvaliableBeatingMove(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates cheesboardFiedAvaliableForBasicMove, MoveCoordinate moveCoordinate)
        {
            IPawn pawnDuringMove = cheesboard.GetPawn(sourceField);
            IPawn pawnInMiddleField = cheesboard.GetPawn(cheesboardFiedAvaliableForBasicMove);

            if ((Pawn.Null != pawnInMiddleField) && (pawnDuringMove.GetPlayerColor() != pawnInMiddleField.GetPlayerColor()))
            {
                return GetAvaliableBasicMove(cheesboardFiedAvaliableForBasicMove, moveCoordinate);
            }

            return null;
        }

        private bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            return cheesboard.IsFieldEmpty(fieldCoordinates);
        }
    }
}
