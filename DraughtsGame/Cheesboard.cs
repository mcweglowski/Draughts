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
        private const int WidthDimension = 0;
        private const int HeightDimension = 1;

        public Cheesboard()
        {
            InitializeCheesboardFields();
        }

        private void InitializeCheesboardFields()
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
            return cheesboard.GetLength(HeightDimension);
        }

        public int GetCheesboardWidth()
        {
            return cheesboard.GetLength(WidthDimension);
        }

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            return cheesboardField.GetColor();
        }

        public void SetPawn(CheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            cheesboardField.SetPawn(pawn);
        }
        public IPawn PickPawn(CheesboardFieldCoordinates fieldCoordinates)
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

        public bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            ICheesboardField cheesboardField = GetField(fieldCoordinates);
            return cheesboardField.IsEmpty();
        }

        private ICheesboardField GetField(ICheesboardFieldCoordinates fieldCoordinates)
        {
            return cheesboard[(int)fieldCoordinates.Row, (int)fieldCoordinates.Column];
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
    }
}
