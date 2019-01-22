using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class CheesboardInitializer : ICheesboardInitializer
    {
        private ICheesboard cheesboard;
        private CheesboardInitializer() { }
        public CheesboardInitializer(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void SetCheesboard(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public void InitNewCheesboard()
        {
            CheesboardFieldCoordinates fieldCoordinates = new CheesboardFieldCoordinates();
            FieldColor lastFieldColor = FieldColor.Black;
            for (fieldCoordinates.Row = CheesboardRow.One; (int)fieldCoordinates.Row < cheesboard.GetCheesboardHeight(); fieldCoordinates.Row++)
            {
                lastFieldColor = GetOppositeFieldStatus(lastFieldColor);
                for (fieldCoordinates.Column = CheesboardColumn.A; (int)fieldCoordinates.Column < cheesboard.GetCheesboardWidth(); fieldCoordinates.Column++)
                {
                    FieldColor newFieldColor = GetOppositeFieldStatus(lastFieldColor);
                    lastFieldColor = SetNewFieldStaus(fieldCoordinates, newFieldColor);
                }
            }
        }

        private FieldColor SetNewFieldStaus(CheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            cheesboard.SetFieldColor(fieldCoordinates, fieldColor);
            return fieldColor;
        }

        private FieldColor GetOppositeFieldStatus(FieldColor previousFieldColor)
        {
            if (FieldColor.White == previousFieldColor)
                return FieldColor.Black;

            return FieldColor.White;
        }
    }
}
