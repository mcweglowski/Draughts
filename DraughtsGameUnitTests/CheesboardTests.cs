using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;

namespace DraughtsGame.Tests_Cheesboard
{
    [TestClass()]
    public class CheesboardTests
    {
        private ICheesboardInitializer cheesboardInitializer = new CheesboardInitializerMock();

        [TestMethod()]
        public void GetCheesboardHeightShouldBe8Test()
        {
            int expectedHeight = 8;
            int actualHeight;
            Cheesboard cheeseboard = new Cheesboard(cheesboardInitializer);
            actualHeight = cheeseboard.GetCheesboardHeight();

            Assert.AreEqual(expectedHeight, actualHeight, "Cheesboard height should be 8.");
        }

        [TestMethod()]
        public void GetCheesboardWidthShouldBe8Test()
        {
            int expectedWidth = 8;
            int actualWidth;
            Cheesboard cheeseboard = new Cheesboard(cheesboardInitializer);
            actualWidth = cheeseboard.GetCheesboardWidth();

            Assert.AreEqual(expectedWidth, actualWidth, "Cheesboard height should be 8.");
        }

        [TestMethod()]
        public void GetFieldStateForA1WhenNewCheesboardShouldBeUndefined()
        {
            FieldColor expectedFieldColor = FieldColor.NotDefined;
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);

            Cheesboard cheesboard = new Cheesboard(cheesboardInitializer);
            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(expectedFieldColor, actualFieldColor, "For not initialized cheesebord, first field should be undefined.");
        }

        [TestMethod()]
        public void GetFieldStateForH8WhenNewCheesboardShouldBeUndefined()
        {
            FieldColor expectedFieldColor = FieldColor.NotDefined;
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.H);

            Cheesboard cheesboard = new Cheesboard(cheesboardInitializer);
            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(expectedFieldColor, actualFieldColor, "For not initialized cheesebord, last field should be undefined.");
        }

        [TestMethod()]
        public void SetFieldStateH8ChangesStatusFromNotDefinedToEmptyBlack()
        {
            FieldColor expectedFieldColor = FieldColor.Black;
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates() { Row = CheesboardRow.Eight, Column = CheesboardColumn.H };

            Cheesboard cheesboard = new Cheesboard(cheesboardInitializer);
            cheesboard.SetFieldColor(cheesboardFieldCoordinates, FieldColor.Black);
            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(expectedFieldColor, actualFieldColor, "H8 Field should be Black.");
        }

        [TestMethod()]
        public void SetFieldState_FieldShouldBePossibleToDefineWhenIsNull()
        {
            Cheesboard cheesboard = new Cheesboard(cheesboardInitializer);
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);
            cheesboard.SetFieldColor(cheesboardFieldCoordinates, FieldColor.Black);

            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(FieldColor.Black, actualFieldColor, "Field color should be set up to Black");
        }

        [TestMethod()]
        public void SetFieldState_FieldShouldNotBePossibleToDefineWhenIsNotNull()
        {
            Cheesboard cheesboard = new Cheesboard(cheesboardInitializer);
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);
            cheesboard.SetFieldColor(cheesboardFieldCoordinates, FieldColor.Black);

            try
            {
                cheesboard.SetFieldColor(cheesboardFieldCoordinates, FieldColor.White);
            }
            catch
            {
                return;
            }

            Assert.Fail("Expected exception when field was already defined and there is another attempt to set it up.");
        }
    }

    class CheesboardInitializerMock : ICheesboardInitializer
    {
        public void InitNewCheesboard()
        {
        }

        public void SetCheesboard(ICheesboard cheesboard)
        {
        }
    }
}