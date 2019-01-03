using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class CheesboardInitializer
    {
        private ICheesboard cheesboard;
        private CheesboardInitializer() { }
        public CheesboardInitializer(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void InitNewCheesboard()
        {
            DraughtsField lastFieldStatus = DraughtsField.EmptyBlack;
            for (int Row = 0; Row < cheesboard.GetCheesboardHeight(); Row++)
            {
                lastFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                for (int Column = 0; Column < cheesboard.GetCheesboardWith(); Column++)
                {
                    DraughtsField newFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                    lastFieldStatus = SetNewFieldStaus(Column, Row, newFieldStatus);
                }
            }
        }

        private DraughtsField SetNewFieldStaus(int Column, int Row, DraughtsField fieldState)
        {
            cheesboard.SetFieldState(Column, Row, fieldState);
            return fieldState;
        }

        private DraughtsField GetOppositeFieldStatus(DraughtsField previousFieldState)
        {
            if (DraughtsField.EmptyWhite == previousFieldState)
                return DraughtsField.EmptyBlack;

            return DraughtsField.EmptyWhite;
        }
    }
}
