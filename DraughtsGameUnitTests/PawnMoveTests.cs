using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DraughtsGame.Tests_MovePawn
{
    [TestClass()]
    public class PawnMoveTests
    {
        CheesboardStub cheesboard;

        [TestInitialize()]
        public void TestInitialize()
        {
            cheesboard = new CheesboardStub();
        }

        [TestMethod()]
        public void MoveShouldSetSourceFieldInEmptyBlackState()
        {
            
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates() { Row = CheesboardRow.One, Column = CheesboardColumn.A };
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates() { Row = CheesboardRow.Two, Column = CheesboardColumn.B };

            PawnMove movePawn = new PawnMove(cheesboard);
            movePawn.Move(sourceField, destinationField);

            Assert.AreEqual(CheesboardField.EmptyBlack, cheesboard.A1, "A1 field should be EmptyBlack after Pawn move.");
        }

        [TestMethod()]
        public void MoveShouldSetDestinationFieldInRedPawnState()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates() { Row = CheesboardRow.One, Column = CheesboardColumn.A };
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates() { Row = CheesboardRow.Two, Column = CheesboardColumn.B };

            PawnMove movePawn = new PawnMove(cheesboard);
            movePawn.Move(sourceField, destinationField);

            Assert.AreEqual(CheesboardField.RedPawn, cheesboard.B2, "B2 field should be RedPawn after Pawn move.");
        }
    }

    internal class CheesboardStub : ICheesboard
    {
        public CheesboardField A1 {get; set;}
        public CheesboardField B2 {get; set;}

        public CheesboardStub()
        {
            A1 = CheesboardField.RedPawn;
            B2 = CheesboardField.EmptyBlack;
        }

        public int GetCheesboardHeight()
        {
            throw new System.NotImplementedException();
        }

        public int GetCheesboardWidth()
        {
            throw new System.NotImplementedException();
        }

        public CheesboardField GetFieldState(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldState(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
            throw new System.NotImplementedException();
        }
    }
}