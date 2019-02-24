using DraughtsGame;
using DraughtsGame.Interfaces;
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
        public void TestIfTwoRowsGameInitializeShouldChangeA1FromNotDefinedToWhitePlayerPawn()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.A1;
            PlayerColor actualPlayerColor = actualPawn.GetPlayerColor();

            Assert.AreEqual(PlayerColor.White, actualPlayerColor, "A1 field pawn should be White.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitialized_A2shouldBeWithoutPawn()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.A2;

            Assert.AreEqual(Pawn.Null, actualPawn, "There should not be pawn on A2 field.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitialized_B1shouldBeWithoutPawn()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.B1;

            Assert.AreEqual(Pawn.Null, actualPawn, "There should not be pawn on B1 field.");
        }


        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedWhitePawnOnB2()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.B2;
            PlayerColor actualColor = actualPawn.GetPlayerColor();

            Assert.AreEqual(PlayerColor.White, actualColor, "B2 field pawn should be White Pawn.");
        }

        [TestMethod()]
        public void TestTwoRowsGameInitialized_A8shouldBeWithoutPawn()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.A8;

            Assert.AreEqual(Pawn.Null, actualPawn, "A8 field should be empty.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitialized_B7shouldBeWithoutPawn()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.B7;

            Assert.AreEqual(Pawn.Null, actualPawn, "B7 field should be empty.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedRedPawnOnA7()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.A7;
            PlayerColor actualColor = actualPawn.GetPlayerColor();

            Assert.AreEqual(PlayerColor.Red, actualColor, "A7 field pawn should be Red Pawn.");
        }

        [TestMethod()]
        public void TestIfTwoRowsGameInitializedPlacedRedPawnOnB8()
        {
            CheesboardStub cheesboard = new CheesboardStub();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();

            IPawn actualPawn = cheesboard.B8;
            PlayerColor actualColor = actualPawn.GetPlayerColor();

            Assert.AreEqual(PlayerColor.Red, actualColor, "B8 field pawn should be Red Pawn.");
        }
    }

    internal class CheesboardStub : ICheesboard
    {
        public int WhitePawnsCount = 0;
        public int RedPawnsCount = 0;

        public IPawn A1 = Pawn.Null;
        public IPawn A2 = Pawn.Null;
        public IPawn B1 = Pawn.Null;
        public IPawn B2 = Pawn.Null;
        public IPawn A8 = Pawn.Null;
        public IPawn B8 = Pawn.Null;
        public IPawn A7 = Pawn.Null;
        public IPawn B7 = Pawn.Null;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWidth()
        {
            return 8;
        }

        public string GetColumnName(int columnIndex)
        {
            throw new System.NotImplementedException();
        }

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public CheesboardField GetFieldState(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public char GetRowName(int index)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeGame(IGameInitializer gameInitializer)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFieldOccupied(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldState(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
        }

        public void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            if (PlayerColor.Red == pawn.GetPlayerColor())
            {
                RedPawnsCount++;
            }
            else if (PlayerColor.White == pawn.GetPlayerColor())
            {
                WhitePawnsCount++;
            }

            if (CheesboardRow.One == fieldCoordinates.Row && CheesboardColumn.A == fieldCoordinates.Column)
            {
                A1 = pawn;
            }

            if (CheesboardRow.One == fieldCoordinates.Row && CheesboardColumn.B == fieldCoordinates.Column)
            {
                B1 = pawn;
            }

            if (CheesboardRow.Two == fieldCoordinates.Row && CheesboardColumn.A == fieldCoordinates.Column)
            {
                A2 = pawn;
            }

            if (CheesboardRow.Two == fieldCoordinates.Row && CheesboardColumn.B == fieldCoordinates.Column)
            {
                B2 = pawn;
            }

            if (CheesboardRow.Eight == fieldCoordinates.Row && CheesboardColumn.A == fieldCoordinates.Column)
            {
                A8 = pawn;
            }

            if (CheesboardRow.Eight == fieldCoordinates.Row && CheesboardColumn.B == fieldCoordinates.Column)
            {
                B8 = pawn;
            }

            if (CheesboardRow.Seven == fieldCoordinates.Row && CheesboardColumn.A == fieldCoordinates.Column)
            {
                A7 = pawn;
            }

            if (CheesboardRow.Seven == fieldCoordinates.Row && CheesboardColumn.B == fieldCoordinates.Column)
            {
                B7 = pawn;
            }
        }

        char ICheesboard.GetColumnName(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}
