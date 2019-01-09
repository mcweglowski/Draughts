﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            CheesboardField expectedCheeseboardField = CheesboardField.NotDefined;

            Cheesboard cheesboard = new Cheesboard();
            CheesboardField actualCheeseboardField = cheesboard.GetFieldState(new CheesboardFieldCoordinates() { Row = CheesboardRow.One, Column = CheesboardColumn.A });

            Assert.AreEqual(expectedCheeseboardField, actualCheeseboardField, "For not initialized cheesebord, first field should be undefined.");
        }

        [TestMethod()]
        public void GetFieldStateForH8WhenNewCheesboardShouldBeUndefined()
        {
            CheesboardField expectedCheeseboardField = CheesboardField.NotDefined;

            Cheesboard cheesboard = new Cheesboard();
            CheesboardField actualCheeseboardField = cheesboard.GetFieldState(new CheesboardFieldCoordinates() { Row = CheesboardRow.Eight, Column = CheesboardColumn.H });

            Assert.AreEqual(expectedCheeseboardField, actualCheeseboardField, "For not initialized cheesebord, last field should be undefined.");
        }

        [TestMethod()]
        public void SetFieldStateH8ChangesStatusFromNotDefinedToEmptyBlack()
        {
            CheesboardField expectedFieldState = CheesboardField.EmptyBlack;            

            Cheesboard cheesboard = new Cheesboard();
            cheesboard.SetFieldState(new CheesboardFieldCoordinates() { Row = CheesboardRow.Eight, Column = CheesboardColumn.H }, CheesboardField.EmptyBlack);

            CheesboardField actualFieldState = cheesboard.GetFieldState(new CheesboardFieldCoordinates() { Row = CheesboardRow.Eight, Column = CheesboardColumn.H });

            Assert.AreEqual(expectedFieldState, actualFieldState, "H8 Field should be EmptyBlack.");
        }
    }
}