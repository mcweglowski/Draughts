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
    }

    class CheesboardStub : ICheesboard
    {
        public int blackFieldsCount = 0;
        public int whiteFieldsCount = 0;
        public int otherFieldsCount = 0;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWith()
        {
            return 8;
        }

        public DraughtsField GetFieldState(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void SetFieldState(int row, int column, DraughtsField fieldState)
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