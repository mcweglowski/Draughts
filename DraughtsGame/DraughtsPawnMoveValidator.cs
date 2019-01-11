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
            CheesboardField sourceFieldState = cheesboard.GetFieldState(sourceField);
            CheesboardRow avaliableRow = sourceField.Row;

            if (CheesboardField.WhitePawn == sourceFieldState)
            {
                avaliableRow = sourceField.Row + 1;
            }
            else if (CheesboardField.RedPawn == sourceFieldState)
            {
                avaliableRow = sourceField.Row - 1;
            }
            else
            {
                throw new Exception(string.Format("DraughtsPawnMoveValidator.GetAvaliableDestinationFields unsupported move try. Source field: {0}, field state: {1}", sourceField.ToString(), sourceFieldState));
            }

            avaliableDestinationFields.Add(new CheesboardFieldCoordinates(avaliableRow, sourceField.Column + 1));
            avaliableDestinationFields.Add(new CheesboardFieldCoordinates(avaliableRow, sourceField.Column - 1));

            return avaliableDestinationFields;
        }
    }
}
