using DraughtsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DraughtsGame.Tests_DraughtsGameTwoRowsInitializer
{
    [TestClass()]
    public class DraughtsGameTwoRowsInitializerTest
    {
        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlaced8WhitePawns()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(8, cheesboard.WhitePawnsCount, "There should be 8 white pawns.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlaced8RedPawns()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(8, cheesboard.RedPawnsCount, "There should be 8 red pawns.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializeNotDefinedOnA1()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.WhitePawn, cheesboard.A1, "A1 field pawn should be White.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedWhitePawnOnA2()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.NotDefined, cheesboard.A2, "A2 field pawn should be NotDefined.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedNotDefinedOnB1()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.NotDefined, cheesboard.B1, "B1 field pawn should be NotDefined.");
        }


        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedWhitePawnOnB2()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.WhitePawn, cheesboard.B2, "B2 field pawn should be White Pawn.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedNotDefinedOnA8()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.NotDefined, cheesboard.A8, "A8 field pawn should be NotDefined.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedNotDefinedOnB7()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.NotDefined, cheesboard.B7, "B7 field pawn should be NotDefined.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedRedPawnOnA7()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.RedPawn, cheesboard.A7, "A7 field pawn should be Red Pawn.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedRedPawnOnB8()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.RedPawn, cheesboard.B8, "B8 field pawn should be Red Pawn.");
        }
    }

    internal class CheesboardStub : ICheesboard
    {
        public int WhitePawnsCount = 0;
        public int RedPawnsCount = 0;

        public CheesboardField A1;
        public CheesboardField A2;
        public CheesboardField B1;
        public CheesboardField B2;
        public CheesboardField A8;
        public CheesboardField B8;
        public CheesboardField A7;
        public CheesboardField B7;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWidth()
        {
            return 8;
        }

        public CheesboardField GetFieldState(CheesboardRow row, CheesboardColumn column)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldState(CheesboardRow row, CheesboardColumn column, CheesboardField fieldState)
        {
            if (CheesboardField.RedPawn == fieldState)
            {
                RedPawnsCount++;
            }
            else if (CheesboardField.WhitePawn == fieldState)
            {
                WhitePawnsCount++;
            }

            if (CheesboardRow.One == row && CheesboardColumn.A == column)
            {
                A1 = fieldState;
            }

            if (CheesboardRow.One == row && CheesboardColumn.B == column)
            {
                B1 = fieldState;
            }

            if (CheesboardRow.Two == row && CheesboardColumn.A == column)
            {
                A2 = fieldState;
            }

            if (CheesboardRow.Two == row && CheesboardColumn.B == column)
            {
                B2 = fieldState;
            }

            if (CheesboardRow.Eight == row && CheesboardColumn.A == column)
            {
                A8 = fieldState;
            }

            if (CheesboardRow.Eight == row && CheesboardColumn.B == column)
            {
                B8 = fieldState;
            }

            if (CheesboardRow.Seven == row && CheesboardColumn.A == column)
            {
                A7 = fieldState;
            }

            if (CheesboardRow.Seven == row && CheesboardColumn.B == column)
            {
                B7 = fieldState;
            }
        }
    }
}
