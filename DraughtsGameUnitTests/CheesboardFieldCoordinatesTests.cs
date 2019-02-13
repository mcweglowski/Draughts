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

		[TestMethod()]
		public void TestEqualsOperatorOverride()
		{
			CheesboardFieldCoordinates firstField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A);
			CheesboardFieldCoordinates secondField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A);

			Assert.IsTrue(firstField == secondField);
		}

		[TestMethod()]
		public void TestNotEqualsOperatorOverride()
		{
			CheesboardFieldCoordinates firstField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A);
			CheesboardFieldCoordinates secondField = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.D);

			Assert.IsTrue(firstField != secondField);
		}

		[TestMethod()]
		public void TestEqualsOperator()
		{
			CheesboardFieldCoordinates firstField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A);
			CheesboardFieldCoordinates secondField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A);

			Assert.IsTrue(firstField.Equals(secondField));
		}
	}
}