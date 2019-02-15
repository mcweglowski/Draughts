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
            int DestinationFieldCalculateOffset = 2;
			PlayerColor activePlayerColor = cheesboard.GetPawn(sourceField).GetPlayerColor();
			IList<CheesboardFieldCoordinates> result = new List<CheesboardFieldCoordinates>();

			for (int MiddleRow = -1; MiddleRow <= 1; MiddleRow = MiddleRow + DestinationFieldCalculateOffset)
			{
				int destinationRowShift = MiddleRow * DestinationFieldCalculateOffset;
				CheesboardRow destinationFieldRow = sourceField.Row + destinationRowShift;
				CheesboardRow middleFieldRow = sourceField.Row + MiddleRow;

                for (int Middle = -1; Middle <= 1; Middle = Middle + DestinationFieldCalculateOffset)
				{
					int destinationColumnShift = Middle * DestinationFieldCalculateOffset;
					CheesboardColumn destinationFieldColumn = sourceField.Column + destinationColumnShift;
					CheesboardColumn middleFieldColumn = sourceField.Column + Middle;

					CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(destinationFieldRow, destinationFieldColumn);
					CheesboardFieldCoordinates middleField = new CheesboardFieldCoordinates(middleFieldRow, middleFieldColumn);

					if (true == IsBeatAvaliable(middleField, destinationField, activePlayerColor))
					{
						result.Add(destinationField);
					}
				}
			}

			return result;
		}

		private bool IsBeatAvaliable(CheesboardFieldCoordinates middleField, CheesboardFieldCoordinates destinationField, PlayerColor activePlayerColor)
		{
			if (true == cheesboard.IsFieldOccupied(destinationField))
			{
				return false;
			}

			if (false == cheesboard.IsFieldOccupied(middleField))
			{
				return false;
			}

            IPawn middlePawn = cheesboard.GetPawn(middleField);
            return activePlayerColor != middlePawn.GetPlayerColor();
		}
    }
}
