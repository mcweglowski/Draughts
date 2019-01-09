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
            CheesboardFieldCoordinates fieldCoordinates = new CheesboardFieldCoordinates();
            for (fieldCoordinates.Row = CheesboardRow.Seven; fieldCoordinates.Row <= CheesboardRow.Eight; fieldCoordinates.Row++ )
            {
                for (fieldCoordinates.Column = GetFirstBlackFieldForRow(fieldCoordinates.Row); (int)fieldCoordinates.Column < cheesboard.GetCheesboardWidth(); fieldCoordinates.Column = fieldCoordinates.Column + 2)
                {
                    cheesboard.SetFieldState(fieldCoordinates, CheesboardField.RedPawn);
                }
            }
        }

        private void SetupWhitePawns()
        {
            CheesboardFieldCoordinates fieldCoordinates = new CheesboardFieldCoordinates();
            for (fieldCoordinates.Row = CheesboardRow.One; fieldCoordinates.Row < CheesboardRow.Three; fieldCoordinates.Row++)
            {
                for (fieldCoordinates.Column = GetFirstBlackFieldForRow(fieldCoordinates.Row); (int)fieldCoordinates.Column < cheesboard.GetCheesboardWidth(); fieldCoordinates.Column = fieldCoordinates.Column + 2)
                {
                    cheesboard.SetFieldState(fieldCoordinates, CheesboardField.WhitePawn);
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
