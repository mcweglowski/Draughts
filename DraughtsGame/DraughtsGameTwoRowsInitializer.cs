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
        private const int RowsCount = 2;

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
        }

        private void SetupWhitePawns()
        {
            for (CheesboardRow Row = CheesboardRow.One; (int)Row < RowsCount; Row++)
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
