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
            CheesboardField sourceFieldState = cheesboard.GetFieldState(sourceField);
            CheesboardFieldCoordinates cheesboardFieldCoordinatesOne;
            CheesboardFieldCoordinates cheesboardFieldCoordinatesTwo;

            if (CheesboardField.WhitePawn == sourceFieldState)
            {
                cheesboardFieldCoordinatesOne = new CheesboardFieldCoordinates(sourceField.Row + 1, sourceField.Column +1);
                cheesboardFieldCoordinatesTwo = new CheesboardFieldCoordinates(sourceField.Row + 1, sourceField.Column - 1);
            }
            else
            {
                cheesboardFieldCoordinatesOne = new CheesboardFieldCoordinates(sourceField.Row - 1, sourceField.Column + 1);
                cheesboardFieldCoordinatesTwo = new CheesboardFieldCoordinates(sourceField.Row - 1, sourceField.Column - 1);
            }

            if (destinationField.Column == cheesboardFieldCoordinatesOne.Column && destinationField.Row == cheesboardFieldCoordinatesOne.Row)
            {
                return true;
            }

            if (destinationField.Column == cheesboardFieldCoordinatesTwo.Column && destinationField.Row == cheesboardFieldCoordinatesTwo.Row)
            {
                return true;
            }

            return false;
        }
    }
}
