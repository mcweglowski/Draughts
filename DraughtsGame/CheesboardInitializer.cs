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
            DraughtsField previousField = DraughtsField.EmptyWhite;
            for (int Row = 0; Row < cheesboard.GetCheesboardHeight(); Row++)
            {
                for (int Column = 0; Column < cheesboard.GetCheesboardWith(); Column++)
                {
                    if (DraughtsField.EmptyWhite == previousField)
                    {
                        cheesboard.SetFieldState(Column, Row, DraughtsField.EmptyBlack);
                        previousField = DraughtsField.EmptyBlack;
                    }
                    else
                    {
                        cheesboard.SetFieldState(Column, Row, DraughtsField.EmptyWhite);
                        previousField = DraughtsField.EmptyWhite;
                    }
                }
            }
        }
    }
}
