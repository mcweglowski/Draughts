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
            CheesboardField lastFieldStatus = CheesboardField.EmptyBlack;
            for (CheesboardRow Row = CheesboardRow.One; (int)Row < cheesboard.GetCheesboardHeight(); Row++)
            {
                lastFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                for (CheesboardColumn Column = CheesboardColumn.A; (int)Column < cheesboard.GetCheesboardWidth(); Column++)
                {
                    CheesboardField newFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                    lastFieldStatus = SetNewFieldStaus(Row, Column, newFieldStatus);
                }
            }
        }

        private CheesboardField SetNewFieldStaus(CheesboardRow Row, CheesboardColumn Column, CheesboardField fieldState)
        {
            cheesboard.SetFieldState(Row, Column, fieldState);
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
