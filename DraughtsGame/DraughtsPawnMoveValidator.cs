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
            throw new NotImplementedException();
        }
    }
}
