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
            CheesboardFieldCoordinates fieldCoordinates = new CheesboardFieldCoordinates();
            CheesboardField lastFieldStatus = CheesboardField.EmptyBlack;
            for (fieldCoordinates.Row = CheesboardRow.One; (int)fieldCoordinates.Row < cheesboard.GetCheesboardHeight(); fieldCoordinates.Row++)
            {
                lastFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                for (fieldCoordinates.Column = CheesboardColumn.A; (int)fieldCoordinates.Column < cheesboard.GetCheesboardWidth(); fieldCoordinates.Column++)
                {
                    CheesboardField newFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                    lastFieldStatus = SetNewFieldStaus(fieldCoordinates, newFieldStatus);
                }
            }
        }

        private CheesboardField SetNewFieldStaus(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
            cheesboard.SetFieldState(fieldCoordinates, fieldState);
            return fieldState;
        }

        private CheesboardField GetOppositeFieldStatus(CheesboardField previousFieldState)
        {
            if (CheesboardField.EmptyWhite == previousFieldState)
                return CheesboardField.EmptyBlack;

            return CheesboardField.EmptyWhite;
        }
    }
}
