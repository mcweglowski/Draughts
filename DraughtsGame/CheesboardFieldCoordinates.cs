using DraughtsGame.Interfaces;
using DraughtsGame.NullObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class CheesboardFieldCoordinates : ICheesboardFieldCoordinates
    {
        public static readonly ICheesboardFieldCoordinates Null = new NullCheesboardFieldCoordinates();

        public CheesboardRow Row { get; set; }
        public CheesboardColumn Column { get; set; }
        public CheesboardFieldCoordinates()
        {
            Row = CheesboardRow.NotDefined;
            Column = CheesboardColumn.NotDefined;
        }
        public CheesboardFieldCoordinates(CheesboardRow Row, CheesboardColumn Column)
        {
            this.Row = Row;
            this.Column = Column;
        }

        public override string ToString()
        {
            string RowDisplayNumber = ((int)(Row + 1)).ToString();
            return Column.ToString() + RowDisplayNumber;
        }

        public override bool Equals(object obj)
        {
            CheesboardFieldCoordinates cheesboardFieldCoordinates = obj as CheesboardFieldCoordinates;
            return Column == cheesboardFieldCoordinates.Column && Row == cheesboardFieldCoordinates.Row;
        }

        public static bool operator == (CheesboardFieldCoordinates x, CheesboardFieldCoordinates y)
        {
            return x.Column == y.Column && x.Row == y.Row;
        }

        public static bool operator != (CheesboardFieldCoordinates x, CheesboardFieldCoordinates y)
        {
            return x.Column != y.Column || x.Row != y.Row;
        }

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
