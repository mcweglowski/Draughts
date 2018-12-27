using DraughtsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameUnitTests
{
    [TestClass]
    public class CheesboardUnitTests
    {
        [TestMethod]
        public void TestIfCheesboardCreatedWithA1AssignedToPlayer()
        {
            Cheesboard cheesboard = new Cheesboard();
            DraughtsField A1 = cheesboard.GetFieldState("A1");

            Assert.AreNotEqual(DraughtsField.EmptyBlack, A1, "A1 field in new cheeseboard can not be EmptyBlack.");
            Assert.AreNotEqual(DraughtsField.EmptyWhite, A1, "A1 field in new cheeseboard can not be EmptyWhite.");
        }

        [TestMethod]
        public void TestIfCheesboardCreatedWithH8AssignedToPlayer()
        {
            Cheesboard cheesboard = new Cheesboard();
            DraughtsField H8 = cheesboard.GetFieldState("H8");

            Assert.AreNotEqual(DraughtsField.EmptyBlack, H8, "H8 field in new cheeseboard can not be EmptyBlack.");
            Assert.AreNotEqual(DraughtsField.EmptyWhite, H8, "H8 field in new cheeseboard can not be EmptyWhite.");
        }

        [TestMethod]
        public void TestIfA1AndH8AssignedToDifferentPlayers()
        {
            Cheesboard cheesboard = new Cheesboard();
            DraughtsField A1 = cheesboard.GetFieldState("A1");
            DraughtsField H8 = cheesboard.GetFieldState("H8");

            Assert.AreNotEqual(A1, H8, "A1 should be assigned to diffrent player than H8.");
        }
    }
}
