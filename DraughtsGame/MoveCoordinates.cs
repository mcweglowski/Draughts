using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class MoveCoordinate
    {
        public MoveCoordinate(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
