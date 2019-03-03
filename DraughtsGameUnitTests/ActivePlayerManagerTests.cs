using System;
using DraughtsGame;
using DraughtsGame.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DraughtsGameUnitTests
{
    [TestClass]
    public class ActivePlayerManagerTests
    {
        [TestMethod]
        public void shouldHaveWhitePlayerAsInitial()
        {
            IActivePlayerManager activePlayerManager = new ActivePlayerManager();

            Assert.AreEqual(PlayerColor.White, activePlayerManager.ActivePlayer);
        }

        [TestMethod]
        public void shouldSwitchPlayerToRed()
        {
            IActivePlayerManager activePlayerManager = new ActivePlayerManager();
            activePlayerManager.SwitchPlayer();

            Assert.AreEqual(PlayerColor.Red, activePlayerManager.ActivePlayer);
        }

        [TestMethod]
        public void shouldSwitchPlayerToWhiteAfterTwoChanges()
        {
            IActivePlayerManager activePlayerManager = new ActivePlayerManager();
            activePlayerManager.SwitchPlayer();
            activePlayerManager.SwitchPlayer();

            Assert.AreEqual(PlayerColor.Red, activePlayerManager.ActivePlayer);
        }
    }
}
