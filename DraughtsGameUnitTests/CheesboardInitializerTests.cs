using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;
using DraughtsGame.Interfaces;

namespace DraughtsGame.Tests_CheesboardInitializer
{
    [TestClass()]
    public class CheesboardInitializerTests
    {
        [TestMethod()]
        public void InitNewCheesboard32BlackFieldsExpectedTest()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(32, cheesboard.blackFieldsCount, string.Format("Initialized cheeseboard should have 32 black fields, but it has {0}.", cheesboard.blackFieldsCount));
        }

        [TestMethod()]
        public void InitNewCheesboard32WhiteFieldsExpectedTest()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(32, cheesboard.whiteFieldsCount, string.Format("Initialized cheeseboard should have 32 white fields, but it has {0}.", cheesboard.whiteFieldsCount));
        }

        [TestMethod()]
        public void InitNewCheesboardNoOtherThanWhiteBlackFieldsTest()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(0, cheesboard.otherFieldsCount, string.Format("Initialized cheeseboard should have 0 fields other than black or white, but it has {0} of them.", cheesboard.whiteFieldsCount));
        }

        [TestMethod]
        public void InitNewCheesboartA1FieldShouldBeEmptyBlack()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(FieldColor.Black, cheesboard.A1field, "A1 field should be EmptyBlack.");
        }

        [TestMethod]
        public void InitNewCheesboartH8FieldShouldBeEmptyBlack()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(FieldColor.Black, cheesboard.H8field, "H8 field should be EmptyBlack.");
        }
    }

    class CheesboardStub : ICheesboard
    {
        public int blackFieldsCount = 0;
        public int whiteFieldsCount = 0;
        public int otherFieldsCount = 0;
        public FieldColor A1field;
        public FieldColor H8field;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWidth()
        {
            return 8;
        }

        public CheesboardField GetFieldState(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldState)
        {
            CountFields(fieldState);
            SetA1Field(fieldCoordinates, fieldState);
            SetH8Field(fieldCoordinates, fieldState);
        }

        private void SetH8Field(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            if (CheesboardRow.Eight == fieldCoordinates.Row && CheesboardColumn.H == fieldCoordinates.Column)
                H8field = fieldColor;
        }

        private void SetA1Field(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            if (CheesboardRow.One == fieldCoordinates.Row && CheesboardColumn.A == fieldCoordinates.Column)
                A1field = fieldColor;
        }

        private void CountFields(FieldColor fieldColor)
        {
            switch (fieldColor)
            {
                case FieldColor.Black:
                    blackFieldsCount++;
                    break;
                case FieldColor.White:
                    whiteFieldsCount++;
                    break;
                default:
                    otherFieldsCount++;
                    break;
            };
        }

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            throw new NotImplementedException();
        }

        public IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldOccupied(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public void InitializeGame(IGameInitializer gameInitializer)
        {
            throw new NotImplementedException();
        }

        public string GetColumnName(int index)
        {
            throw new NotImplementedException();
        }

        public string GetRowName(int index)
        {
            throw new NotImplementedException();
        }
    }
}