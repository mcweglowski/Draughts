using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnMove
    {
        ICheesboard cheesboard;
        public PawnMove(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void Move(CheesboardFieldCoordinates sourceField, CheesboardFieldCoordinates destinationField)
        {
            CheesboardField destinationFieldState = cheesboard.GetFieldState(sourceField);
            cheesboard.SetFieldState(destinationField, destinationFieldState);
            cheesboard.SetFieldState(sourceField, CheesboardField.EmptyBlack);
        }
    }
}
