using DraughtsGame.Interfaces;
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
        public void MoveShouldSetDestinationFieldInRedPawnState()
        {
            ICheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates() { Row = CheesboardRow.One, Column = CheesboardColumn.A };
            ICheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates() { Row = CheesboardRow.Two, Column = CheesboardColumn.B };

            PawnMove movePawn = new PawnMove(cheesboard);
            movePawn.Move(sourceField, destinationField);

            PlayerColor actualPlayerColor = cheesboard.PawnB2.GetPlayerColor();

            Assert.AreEqual(PlayerColor.Red, actualPlayerColor, "B2 field should be Red after Pawn move.");
        }
    }

    internal class CheesboardStub : ICheesboard
    {
        public IPawn PawnA1 { get; set; } = Pawn.Null;
        public IPawn PawnB2 { get; set; } = Pawn.Null;

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

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            throw new System.NotImplementedException();
        }

        public void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            if (fieldCoordinates.Column == CheesboardColumn.A && fieldCoordinates.Row == CheesboardRow.One)
                PawnA1 = pawn;

            if (fieldCoordinates.Column == CheesboardColumn.B && fieldCoordinates.Row == CheesboardRow.Two)
                PawnB2 = pawn;
        }

        public IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            return new Pawn(PlayerColor.Red, new List<MoveCoordinate>());
        }

        public IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFieldOccupied(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeGame(IGameInitializer gameInitializer)
        {
            throw new System.NotImplementedException();
        }

        public string GetColumnName(int index)
        {
            throw new System.NotImplementedException();
        }

        public string GetRowName(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}