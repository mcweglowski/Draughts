using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnBeat : IPawnMove
    {
        private ICheesboard cheeseboard;

        private PawnBeat()
        {

        }

        public PawnBeat(ICheesboard cheeseboard)
        {
            this.cheeseboard = cheeseboard;
        }

        public void Move(ICheesboardFieldCoordinates sourceFieldCoordinates, ICheesboardFieldCoordinates destinationFieldCoordinates)
        {
            ICheesboardFieldCoordinates middleFieldCoordinates = GetMiddleField(sourceFieldCoordinates, destinationFieldCoordinates);
            IPawn beaterPawn = cheeseboard.PickPawn(sourceFieldCoordinates);
            cheeseboard.SetPawn(destinationFieldCoordinates, beaterPawn);
            cheeseboard.PickPawn(middleFieldCoordinates);
        }

        private ICheesboardFieldCoordinates GetMiddleField(ICheesboardFieldCoordinates sourceFieldCoordinates, ICheesboardFieldCoordinates destinationFieldCoordinates)
        {
            IList<CheesboardRow> rows = Enum.GetValues(typeof(CheesboardRow)).Cast<CheesboardRow>().ToList();
            CheesboardRow cheesboardRow = rows.First(x => (x > sourceFieldCoordinates.Row && x < destinationFieldCoordinates.Row) || (x < sourceFieldCoordinates.Row && x > destinationFieldCoordinates.Row));

            IList<CheesboardColumn> columns = Enum.GetValues(typeof(CheesboardColumn)).Cast<CheesboardColumn>().ToList();
            CheesboardColumn cheesboardColumn = columns.First(x => (x > sourceFieldCoordinates.Column && x < destinationFieldCoordinates.Column) || (x < sourceFieldCoordinates.Column && x > destinationFieldCoordinates.Column));

            return new CheesboardFieldCoordinates(cheesboardRow, cheesboardColumn);
        }
    }
}
