using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

            IPawn actualPawn = cheesboard.PawnA1;

            Assert.AreEqual(Pawn.Null, actualPawn, "A1 field should be empty after Pawn move.");
        }

        [TestMethod()]
        public void MoveShouldSetDestinationFieldInRedPawnState()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates() { Row = CheesboardRow.One, Column = CheesboardColumn.A };
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates() { Row = CheesboardRow.Two, Column = CheesboardColumn.B };

            PawnMove movePawn = new PawnMove(cheesboard);
            movePawn.Move(sourceField, destinationField);

            PlayerColor actualPlayerColor = cheesboard.PawnB2.GetPlayerColor();

            Assert.AreEqual(PlayerColor.Red, actualPlayerColor, "B2 field should be Red after Pawn move.");
        }
    }

    internal class CheesboardStub : ICheesboard
    {
        public IPawn PawnA1 {get; set;}
        public IPawn PawnB2 {get; set;}

        public CheesboardStub()
        {
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
            return null;
        }

        public FieldColor GetFieldColor(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldColor(CheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            throw new System.NotImplementedException();
        }

        public void SetPawn(CheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            if (fieldCoordinates.Column == CheesboardColumn.A && fieldCoordinates.Row == CheesboardRow.One)
                PawnA1 = pawn;

            if (fieldCoordinates.Column == CheesboardColumn.B && fieldCoordinates.Row == CheesboardRow.Two)
                PawnB2 = pawn;
        }

        public IPawn PickPawn(CheesboardFieldCoordinates fieldCoordinates)
        {
            return new Pawn(PlayerColor.Red, new List<MoveCoordinate>());
        }

        public IPawn GetPawn(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }
    }
}