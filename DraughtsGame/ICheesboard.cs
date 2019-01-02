using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public interface ICheesboard
    {
        DraughtsField GetFieldState(string position);
        void SetFieldState(string position, DraughtsField fieldState);
    }
}
