using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsGameTwoRowsInitializer
    {
        private ICheesboard cheesboard;

        public DraughtsGameTwoRowsInitializer(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void InitializeNewGame()
        {
            SetupWhitePawns();
            SetupRedPawns();
        }

        private void SetupRedPawns()
        {
            for (CheesboardRow Row = CheesboardRow.Seven; Row <= CheesboardRow.Eight; Row++ )
            {
                for (CheesboardColumn Column = GetFirstBlackFieldForRow(Row); (int)Column < cheesboard.GetCheesboardWidth(); Column = Column + 2)
                {
                    cheesboard.SetFieldState(Row, Column, CheesboardField.RedPawn);
                }
            }
        }

        private void SetupWhitePawns()
        {
            for (CheesboardRow Row = CheesboardRow.One; Row < CheesboardRow.Three; Row++)
            {
                for (CheesboardColumn Column = GetFirstBlackFieldForRow(Row); (int)Column < cheesboard.GetCheesboardWidth(); Column = Column + 2)
                {
                    cheesboard.SetFieldState(Row, Column, CheesboardField.WhitePawn);
                }
            }
        }

        private CheesboardColumn GetFirstBlackFieldForRow(CheesboardRow Row)
        {
            if (0 == (int)Row % 2)
            {
                return CheesboardColumn.A;
            }

            return CheesboardColumn.B;
        }
    }
}
