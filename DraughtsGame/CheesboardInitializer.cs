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
            DraughtsField lastFieldStatus = DraughtsField.EmptyWhite;
            for (int Row = 0; Row < cheesboard.GetCheesboardHeight(); Row++)
            {
                for (int Column = 0; Column < cheesboard.GetCheesboardWith(); Column++)
                {
                    DraughtsField newFieldStatus = GetNewFieldStatus(lastFieldStatus);
                    lastFieldStatus = SetNewFieldStaus(Column, Row, newFieldStatus);
                }
            }
        }

        private DraughtsField SetNewFieldStaus(int Column, int Row, DraughtsField fieldState)
        {
            cheesboard.SetFieldState(Column, Row, fieldState);
            return fieldState;
        }

        private DraughtsField GetNewFieldStatus(DraughtsField previousFieldState)
        {
            if (DraughtsField.EmptyWhite == previousFieldState)
                return DraughtsField.EmptyBlack;

            return DraughtsField.EmptyWhite;
        }
    }
}
