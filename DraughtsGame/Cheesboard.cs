using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame
{
    public class Cheesboard : ICheesboard
    {
        private ICheesboardField[,] cheesboard = new ICheesboardField[Enum.GetNames(typeof(CheesboardColumn)).Length - 1, Enum.GetNames(typeof(CheesboardRow)).Length - 1];
        private const int ColumnsDimension = 0;
        private const int RowsDimension = 1;

        public Cheesboard()
        {
            ResetCheesboardFields();
        }

        private void ResetCheesboardFields()
        {
            for (int row = 0; row < GetCheesboardHeight(); row++)                
            {
                for (int column = 0; column < GetCheesboardWidth(); column++)
                {
                    cheesboard[row, column] = CheesboardField.Null;
                }
            }
        }

        public int GetCheesboardHeight()
        {
            return cheesboard.GetLength(RowsDimension);
        }

        public int GetCheesboardWidth()
        {
            return cheesboard.GetLength(ColumnsDimension);
        }

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            return cheesboardField.GetColor();
        }

        public void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            cheesboardField.SetPawn(pawn);
        }
        public IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            IPawn pawn = cheesboardField.PickPawn();
            return pawn;
        }

        public void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);

            if (CheesboardField.Null != cheesboardField)
            {
                throw new Exception("Field already established. It can not be redefined again.");
            }

            SetField(fieldCoordinates, new CheesboardField(fieldColor));
        }

        public bool IsFieldEmpty(ICheesboardFieldCoordinates fieldCoordinates)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            return cheesboardField.IsEmpty();
        }

		public bool IsFieldOccupied(CheesboardFieldCoordinates fieldCoordinates)
		{
			ICheesboardField cheesboardField = GetField(fieldCoordinates);
			return false == cheesboardField.IsEmpty();
		}

		private ICheesboardField GetField(ICheesboardFieldCoordinates fieldCoordinates)
        {
            if (false == IsColumnInRange(fieldCoordinates.Column))
            {
                return CheesboardField.Null;
            }

            if (false == IsRowInRange(fieldCoordinates.Row))
            {
                return CheesboardField.Null;
            }

            return cheesboard[(int)fieldCoordinates.Row, (int)fieldCoordinates.Column];
        }

        private bool IsRowInRange(CheesboardRow Row)
        {
            return Row >= 0 && (int)Row < cheesboard.GetLength(RowsDimension);
        }

        private bool IsColumnInRange(CheesboardColumn Column)
        {
            return Column >= 0 && (int)Column < cheesboard.GetLength(ColumnsDimension);
        }

        private void SetField(ICheesboardFieldCoordinates fieldCoordinates, CheesboardField cheesboardField)
        {
            cheesboard[(int)fieldCoordinates.Row, (int)fieldCoordinates.Column] = cheesboardField;
        }

        public IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            return cheesboardField.GetPawn();
        }

        public void InitializeGame(IGameInitializer gameInitializer)
        {
            gameInitializer.InitializeNewGame(this);
        }

        public string GetColumnName(int index)
        {
            return Enum.GetName(typeof(CheesboardColumn), index);
        }

        public string GetRowName(int index)
        {
            return Enum.GetName(typeof(CheesboardRow), index);
        }
    }
}
