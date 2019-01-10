using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Tests_CheesboardFieldCoordinates
{
    [TestClass()]
    public class CheesboardFieldCoordinatesTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            string expectedCoordinatesString = "E5";

            CheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.E);
            string actualCoordinatesString = cheesboardFieldCoordinates.ToString();

            Assert.AreEqual(expectedCoordinatesString, actualCoordinatesString);
        }
    }
}