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
            CheeseboardField lastFieldStatus = CheeseboardField.EmptyBlack;
            for (CheesboardRow Row = CheesboardRow.One; (int)Row < cheesboard.GetCheesboardHeight(); Row++)
            {
                lastFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                for (CheesboardColumn Column = CheesboardColumn.A; (int)Column < cheesboard.GetCheesboardWidth(); Column++)
                {
                    CheeseboardField newFieldStatus = GetOppositeFieldStatus(lastFieldStatus);
                    lastFieldStatus = SetNewFieldStaus(Row, Column, newFieldStatus);
                }
            }
        }

        private CheeseboardField SetNewFieldStaus(CheesboardRow Row, CheesboardColumn Column, CheeseboardField fieldState)
        {
            cheesboard.SetFieldState(Row, Column, fieldState);
            return fieldState;
        }

        private CheeseboardField GetOppositeFieldStatus(CheeseboardField previousFieldState)
        {
            if (CheeseboardField.EmptyWhite == previousFieldState)
                return CheeseboardField.EmptyBlack;

            return CheeseboardField.EmptyWhite;
        }
    }
}
