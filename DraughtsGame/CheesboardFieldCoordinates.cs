using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class CheesboardFieldCoordinates
    {
        public CheesboardRow Row { get; set; }
        public CheesboardColumn Column { get; set; }
        public CheesboardFieldCoordinates()
        {

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
    }
}
