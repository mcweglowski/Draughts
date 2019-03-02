using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame.Interfaces;
using DraughtsGame;

namespace DraughtsGameUnitTests
{
    /// <summary>
    /// Summary description for DraughtsEngineTests
    /// </summary>
    [TestClass]
    public class DraughtsEngineTests
    {
        public DraughtsEngineTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void shouldHaveWhitePlayerAsActiveWhenGameStarts()
        {
            IDraughtsEngine draughtsEngine = new DraughtsEngine();
            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.AreEqual(PlayerColor.White, activePlayer);
        }

        [TestMethod]
        public void shouldSwithPlayerToOponentWhenMovePawnReturnTrue()
        {
            IDraughtsEngine draughtsEngine = new DraughtsEngine();
            bool moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A), new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.C));
            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.IsTrue(moveResult);
            Assert.AreEqual(PlayerColor.Red, activePlayer);
        }

        [TestMethod]
        public void shouldHaveWhitePlayerAsActiveAfterTwoSuccesfullMoves()
        {
            IDraughtsEngine draughtsEngine = new DraughtsEngine();
            bool moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A), new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.C));
            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.IsTrue(moveResult);
            Assert.AreEqual(PlayerColor.Red, activePlayer);

            moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.A), new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.C));
            activePlayer = draughtsEngine.ActivePlayer;
            Assert.AreEqual(PlayerColor.White, activePlayer);
        }

        [TestMethod]
        public void shouldNotSwitchPlayerWhenMoveFailed()
        {
            Assert.Fail();
        }
    }
}
