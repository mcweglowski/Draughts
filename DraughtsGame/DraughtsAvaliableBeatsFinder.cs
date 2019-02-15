using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class DraughtsAvaliableBeatsFinder
    {
		ICheesboard cheesboard;
        public DraughtsAvaliableBeatsFinder(ICheesboard cheesboard)
        {
            this.cheesboard = cheesboard;
        }

        public IList<CheesboardFieldCoordinates> GetAvaliableBeats(CheesboardFieldCoordinates sourceField)
        {
			PlayerColor activePlayerColor = cheesboard.GetPawn(sourceField).GetPlayerColor();
			IList<CheesboardFieldCoordinates> result = new List<CheesboardFieldCoordinates>();

            if (sourceField.Row - 2 >= CheesboardRow.One && sourceField.Column - 2 >= CheesboardColumn.A)
			{
				if (cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row - 2, sourceField.Column - 2)))
				{
					if (false == cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row - 1, sourceField.Column - 1)))
					{
						if (activePlayerColor != cheesboard.GetPawn(new CheesboardFieldCoordinates(sourceField.Row - 1, sourceField.Column - 1)).GetPlayerColor())
						{
							result.Add(new CheesboardFieldCoordinates(sourceField.Row - 2, sourceField.Column - 2));
						}
					}
				}
			}

			if (sourceField.Row - 2 >= CheesboardRow.One && sourceField.Column + 2 <= CheesboardColumn.H)
			{
				if (cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row - 2, sourceField.Column + 2)))
				{
					if (false == cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row - 1, sourceField.Column + 1)))
					{
						if (activePlayerColor != cheesboard.GetPawn(new CheesboardFieldCoordinates(sourceField.Row - 1, sourceField.Column + 1)).GetPlayerColor())
						{
							result.Add(new CheesboardFieldCoordinates(sourceField.Row - 2, sourceField.Column + 2));
						}
					}
				}
			}

			if (sourceField.Row + 2 <= CheesboardRow.Eight && sourceField.Column - 2 >= CheesboardColumn.A)
			{
				if (cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row + 2, sourceField.Column - 2)))
				{
					if (false == cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row + 1, sourceField.Column - 1)))
					{
						if (activePlayerColor != cheesboard.GetPawn(new CheesboardFieldCoordinates(sourceField.Row + 1, sourceField.Column - 1)).GetPlayerColor())
						{
							result.Add(new CheesboardFieldCoordinates(sourceField.Row + 2, sourceField.Column - 2));
						}
					}
				}
			}

			if (sourceField.Row + 2 < CheesboardRow.Eight && sourceField.Column + 2 <= CheesboardColumn.H)
			{
				if (cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row + 2, sourceField.Column + 2)))
				{
					if (false == cheesboard.IsFieldEmpty(new CheesboardFieldCoordinates(sourceField.Row + 1, sourceField.Column + 1)))
					{
						if (activePlayerColor != cheesboard.GetPawn(new CheesboardFieldCoordinates(sourceField.Row + 1, sourceField.Column + 1)).GetPlayerColor())
						{
							result.Add(new CheesboardFieldCoordinates(sourceField.Row + 2, sourceField.Column + 2));
						}
					}
				}
			}

			return result;
		}
    }
}
