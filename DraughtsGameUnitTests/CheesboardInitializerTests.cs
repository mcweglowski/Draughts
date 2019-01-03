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

            Assert.AreEqual(DraughtsField.EmptyBlack, cheesboard.A1field, "A1 field should be EmptyBlack.");
        }

        [TestMethod]
        public void InitNewCheesboartH8FieldShouldBeEmptyBlack()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(DraughtsField.EmptyBlack, cheesboard.H8field, "H8 field should be EmptyBlack.");
        }
    }

    class CheesboardStub : ICheesboard
    {
        public int blackFieldsCount = 0;
        public int whiteFieldsCount = 0;
        public int otherFieldsCount = 0;
        public DraughtsField A1field;
        public DraughtsField H8field;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWidth()
        {
            return 8;
        }

        public DraughtsField GetFieldState(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void SetFieldState(int row, int column, DraughtsField fieldState)
        {
            CountFields(fieldState);
            SetA1Field(row, column, fieldState);
            SetF8Field(row, column, fieldState);
        }

        private void SetF8Field(int row, int column, DraughtsField fieldState)
        {
            if (7 == row && 7 == column)
                H8field = fieldState;
        }

        private void SetA1Field(int row, int column, DraughtsField fieldState)
        {
            if (0 == row && 0 == column)
                A1field = fieldState;
        }

        private void CountFields(DraughtsField fieldState)
        {
            switch (fieldState)
            {
                case DraughtsField.EmptyBlack:
                    blackFieldsCount++;
                    break;
                case DraughtsField.EmptyWhite:
                    whiteFieldsCount++;
                    break;
                default:
                    otherFieldsCount++;
                    break;
            };
        }
    }
}