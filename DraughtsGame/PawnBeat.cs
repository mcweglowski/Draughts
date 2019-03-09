using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class PawnBeat : IMove
    {
        ICheesboard cheesboard;
        public static readonly IMove Null = new NullMove();
        private PawnBeat()
        {

        }

        public PawnBeat(ICheesboard cheeseboard)
        {
            this.cheesboard = cheeseboard;
        }

        public bool Move(ICheesboardFieldCoordinates sourceFieldCoordinates, ICheesboardFieldCoordinates destinationFieldCoordinates)
        {
            IPawn pawn = cheesboard.PickPawn(sourceFieldCoordinates);
            cheesboard.SetPawn(destinationFieldCoordinates, pawn);

            ICheesboardFieldCoordinates middleFieldCoordinates = GetMiddleField(sourceFieldCoordinates, destinationFieldCoordinates);
            cheesboard.PickPawn(middleFieldCoordinates);

            return true;
        }

        private ICheesboardFieldCoordinates GetMiddleField(ICheesboardFieldCoordinates sourceFieldCoordinates, ICheesboardFieldCoordinates destinationFieldCoordinates)
        {
            IList<CheesboardRow> cheeseboardRowsList = GetRowsList();
            CheesboardRow cheesboardRow = GetMiddleRow(cheeseboardRowsList, sourceFieldCoordinates.Row, destinationFieldCoordinates.Row);

            IList<CheesboardColumn> cheesboardColumnsList = GetColumnsList();
            CheesboardColumn cheesboardColumn = GetMiddleColumn(cheesboardColumnsList, sourceFieldCoordinates.Column, destinationFieldCoordinates.Column);

            return new CheesboardFieldCoordinates(cheesboardRow, cheesboardColumn);
        }

        private CheesboardRow GetMiddleRow(IList<CheesboardRow> cheesboardRows, CheesboardRow sourceRow, CheesboardRow destinationRow)
        {
            return cheesboardRows.First(x => true == IsRowInRowsRange(x, sourceRow, destinationRow));
        }

        private CheesboardColumn GetMiddleColumn(IList<CheesboardColumn> cheesboardColumns, CheesboardColumn sourceColumn, CheesboardColumn destinationColumn)
        {
            return cheesboardColumns.First(x => true == IsColumnInColumnsRange(x, sourceColumn, destinationColumn));
        }

        private IList<CheesboardRow> GetRowsList()
        {
            return Enum.GetValues(typeof(CheesboardRow)).Cast<CheesboardRow>().ToList();
        }

        private IList<CheesboardColumn> GetColumnsList()
        {
            return Enum.GetValues(typeof(CheesboardColumn)).Cast<CheesboardColumn>().ToList();
        }

        private bool IsRowInRowsRange(CheesboardRow testedRow, CheesboardRow sourceRow, CheesboardRow destinationRow)
        {
            if (testedRow > sourceRow && testedRow < destinationRow)
            {
                return true;
            }

            return testedRow < sourceRow && testedRow > destinationRow;
        }

        private bool IsColumnInColumnsRange(CheesboardColumn testedColumn, CheesboardColumn sourceColumn, CheesboardColumn destinationColumn)
        {
            if (testedColumn > sourceColumn && testedColumn < destinationColumn)
            {
                return true;
            }

            return testedColumn < sourceColumn && testedColumn > destinationColumn;
        }
    }
}
