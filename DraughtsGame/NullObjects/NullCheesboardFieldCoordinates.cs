using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.NullObjects
{
    public class NullCheesboardFieldCoordinates : ICheesboardFieldCoordinates
    {
        public CheesboardRow Row
        {
            get { return CheesboardRow.NotDefined; }
        }

        public CheesboardColumn Column
        {
            get { return CheesboardColumn.NotDefined; }
        }
    }
}
