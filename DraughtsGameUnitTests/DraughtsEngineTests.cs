using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame.Interfaces;
using DraughtsGame;

namespace DraughtsGame.Tests_DraughtsEngine
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
            draughtsEngine.Cheesboard = new Cheesboard();
            draughtsEngine.AddInitializer(new CheesboardInitializer());
            draughtsEngine.AddInitializer(new DraughtsGameTwoRowsInitializer());
            draughtsEngine.InitializeGame();

            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.AreEqual(PlayerColor.White, activePlayer);
        }

        [TestMethod]
        public void shouldSwithPlayerToOponentWhenMovePawnReturnTrue()
        {
            IDraughtsEngine draughtsEngine = new DraughtsEngine();
            draughtsEngine.Cheesboard = new Cheesboard();
            draughtsEngine.AddInitializer(new CheesboardInitializer());
            draughtsEngine.AddInitializer(new DraughtsGameTwoRowsInitializer());
            draughtsEngine.InitializeGame();

            bool moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C));
            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.IsTrue(moveResult);
            Assert.AreEqual(PlayerColor.Red, activePlayer);
        }

        [TestMethod]
        public void shouldHaveWhitePlayerAsActiveAfterTwoSuccesfullMoves()
        {
            IDraughtsEngine draughtsEngine = new DraughtsEngine();
            draughtsEngine.Cheesboard = new Cheesboard();
            draughtsEngine.AddInitializer(new CheesboardInitializer());
            draughtsEngine.AddInitializer(new DraughtsGameTwoRowsInitializer());
            draughtsEngine.InitializeGame();

            bool moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C));
            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.IsTrue(moveResult);
            Assert.AreEqual(PlayerColor.Red, activePlayer);

            moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.A), new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.B));
            activePlayer = draughtsEngine.ActivePlayer;
            Assert.AreEqual(PlayerColor.White, activePlayer);
        }

        [TestMethod]
        public void shouldNotSwitchPlayerWhenMoveFailed()
        {
            IDraughtsEngine draughtsEngine = new DraughtsEngine();
            draughtsEngine.Cheesboard = new Cheesboard();
            draughtsEngine.AddInitializer(new CheesboardInitializer());
            draughtsEngine.AddInitializer(new DraughtsGameTwoRowsInitializer());

            bool moveResult = draughtsEngine.Move(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.D));
            PlayerColor activePlayer = draughtsEngine.ActivePlayer;

            Assert.IsFalse(moveResult);
            Assert.AreEqual(PlayerColor.White, activePlayer);
        }
    }

    public class CheesboardStub : ICheesboard
    {
        public int GetCheesboardHeight()
        {
            throw new NotImplementedException();
        }

        public int GetCheesboardWidth()
        {
            throw new NotImplementedException();
        }

        public string GetColumnName(int index)
        {
            throw new NotImplementedException();
        }

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public string GetRowName(int index)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldEmpty(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldOccupied(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            throw new NotImplementedException();
        }

        public void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            throw new NotImplementedException();
        }
    }
}
