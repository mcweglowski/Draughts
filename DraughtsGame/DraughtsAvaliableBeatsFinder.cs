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

			for (int Row = -1; Row <= 1; Row = Row + 2)
			{
				int destinationRowShift = Row * 2;
				CheesboardRow destinationFieldRow = sourceField.Row + destinationRowShift;
				CheesboardRow middleFieldRow = sourceField.Row + Row;
				for (int Column = -1; Column <= 1; Column = Column + 2)
				{
					int destinationColumnShift = Column * 2;
					CheesboardColumn destinationFieldColumn = sourceField.Column + destinationColumnShift;
					CheesboardColumn middleFieldColumn = sourceField.Column + Column;

					CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(destinationFieldRow, destinationFieldColumn);
					CheesboardFieldCoordinates middleField = new CheesboardFieldCoordinates(middleFieldRow, middleFieldColumn);

					if (cheesboard.IsFieldEmpty(destinationField))
					{
						if (false == cheesboard.IsFieldEmpty(middleField))
						{
							if (activePlayerColor != cheesboard.GetPawn(middleField).GetPlayerColor())
							{
								result.Add(destinationField);
							}
						}
					}

				}
			}

			return result;
		}
    }
}
