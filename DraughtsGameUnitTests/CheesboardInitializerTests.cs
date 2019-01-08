using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Tests
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

            Assert.AreEqual(CheeseboardField.EmptyBlack, cheesboard.A1field, "A1 field should be EmptyBlack.");
        }

        [TestMethod]
        public void InitNewCheesboartH8FieldShouldBeEmptyBlack()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(CheeseboardField.EmptyBlack, cheesboard.H8field, "H8 field should be EmptyBlack.");
        }
    }

    class CheesboardStub : ICheesboard
    {
        public int blackFieldsCount = 0;
        public int whiteFieldsCount = 0;
        public int otherFieldsCount = 0;
        public CheeseboardField A1field;
        public CheeseboardField H8field;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWidth()
        {
            return 8;
        }

        public CheeseboardField GetFieldState(CheesboardRow row, CheesboardColumn column)
        {
            throw new NotImplementedException();
        }

        public void SetFieldState(CheesboardRow row, CheesboardColumn column, CheeseboardField fieldState)
        {
            CountFields(fieldState);
            SetA1Field(row, column, fieldState);
            SetH8Field(row, column, fieldState);
        }

        private void SetH8Field(CheesboardRow row, CheesboardColumn column, CheeseboardField fieldState)
        {
            if (CheesboardRow.Eight == row && CheesboardColumn.H == column)
                H8field = fieldState;
        }

        private void SetA1Field(CheesboardRow row, CheesboardColumn column, CheeseboardField fieldState)
        {
            if (CheesboardRow.One == row && CheesboardColumn.A == column)
                A1field = fieldState;
        }

        private void CountFields(CheeseboardField fieldState)
        {
            switch (fieldState)
            {
                case CheeseboardField.EmptyBlack:
                    blackFieldsCount++;
                    break;
                case CheeseboardField.EmptyWhite:
                    whiteFieldsCount++;
                    break;
                default:
                    otherFieldsCount++;
                    break;
            };
        }
    }
}