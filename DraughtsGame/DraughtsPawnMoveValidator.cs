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
            if (true == IsFieldEmpty(destinationField))
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

            foreach (MoveCoordinate moveCoordinate in moveCoordinates)
            {
                CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(sourceField.Row + moveCoordinate.Row, sourceField.Column + moveCoordinate.Column);
                avaliableDestinationFields.Add(cheesboardFieldCoordinates);
            }

            return avaliableDestinationFields;
        }

        private bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            return cheesboard.IsFieldEmpty(fieldCoordinates);
        }
    }
}
