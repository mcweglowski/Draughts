﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Tests
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
            CheeseboardField expectedCheeseboardField = CheeseboardField.NotDefined;

            Cheesboard cheesboard = new Cheesboard();
            CheeseboardField actualCheeseboardField = cheesboard.GetFieldState(CheesboardRow.One, CheesboardColumn.A);

            Assert.AreEqual(expectedCheeseboardField, actualCheeseboardField, "For not initialized cheesebord, first field should be undefined.");
        }

        [TestMethod()]
        public void GetFieldStateForH8WhenNewCheesboardShouldBeUndefined()
        {
            CheeseboardField expectedCheeseboardField = CheeseboardField.NotDefined;

            Cheesboard cheesboard = new Cheesboard();
            CheeseboardField actualCheeseboardField = cheesboard.GetFieldState(CheesboardRow.Eight, CheesboardColumn.H);

            Assert.AreEqual(expectedCheeseboardField, actualCheeseboardField, "For not initialized cheesebord, last field should be undefined.");
        }
    }
}