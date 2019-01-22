using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;

namespace DraughtsGame.Tests_Cheesboard
{
    [TestClass()]
    public class CheesboardTests
    {
        [TestMethod()]
        public void GetCheesboardHeightShouldBe8Test()
        {
            int expectedHeight = 8;
            int actualHeight;
            Cheesboard cheeseboard = new Cheesboard();
            actualHeight = cheeseboard.GetCheesboardHeight();

            Assert.AreEqual(expectedHeight, actualHeight, "Cheesboard height should be 8.");
        }

        [TestMethod()]
        public void GetCheesboardWidthShouldBe8Test()
        {
            int expectedWidth = 8;
            int actualWidth;
            Cheesboard cheeseboard = new Cheesboard();
            actualWidth = cheeseboard.GetCheesboardWidth();

            Assert.AreEqual(expectedWidth, actualWidth, "Cheesboard height should be 8.");
        }

        [TestMethod()]
        public void GetFieldStateForA1WhenNewCheesboardShouldBeUndefined()
        {
            FieldColor expectedFieldColor = FieldColor.NotDefined;
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);

            Cheesboard cheesboard = new Cheesboard();
            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(expectedFieldColor, actualFieldColor, "For not initialized cheesebord, first field should be undefined.");
        }

        [TestMethod()]
        public void GetFieldStateForH8WhenNewCheesboardShouldBeUndefined()
        {
            FieldColor expectedFieldColor = FieldColor.NotDefined;
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.H);

            Cheesboard cheesboard = new Cheesboard();
            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(expectedFieldColor, actualFieldColor, "For not initialized cheesebord, last field should be undefined.");
        }

        [TestMethod()]
        public void SetFieldStateH8ChangesStatusFromNotDefinedToEmptyBlack()
        {
            FieldColor expectedFieldColor = FieldColor.Black;
            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates() { Row = CheesboardRow.Eight, Column = CheesboardColumn.H };

            Cheesboard cheesboard = new Cheesboard();
            cheesboard.SetFieldColor(cheesboardFieldCoordinates, FieldColor.Black);
            FieldColor actualFieldColor = cheesboard.GetFieldColor(cheesboardFieldCoordinates);

            Assert.AreEqual(expectedFieldColor, actualFieldColor, "H8 Field should be Black.");
        }
    }
}