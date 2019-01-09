using DraughtsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DraughtsGameUnitTests
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

            Assert.AreEqual(CheesboardField.WhitePawn, cheesboard.B2, "B2 field pawn should be White.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedRedPawnOnH8()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            Assert.AreEqual(CheesboardField.RedPawn, cheesboard.H8, "H8 field pawn should be Red.");
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
        public CheesboardField H8;

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

            if (CheesboardRow.Eight == row && CheesboardColumn.H == column)
            {
                H8 = fieldState;
            }
        }
    }
}
