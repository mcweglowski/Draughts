using DraughtsGame;
using DraughtsGame.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Tests_PawnBeat
{
    [TestClass()]
    public class PawnBeatTests
    {
        ICheesboard cheesboard = null;
        ICheesboardFieldCoordinates cheesboardFieldCoordinatesB2 = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
        ICheesboardFieldCoordinates cheesboardFieldCoordinatesC3 = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C);
        ICheesboardFieldCoordinates cheesboardFieldCoordinatesD4 = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.D);

        [TestInitialize()]
        public void TestInitialize()
        {
            cheesboard = new CheesboardStub();
        }

        [TestMethod()]
        public void shouldRemoveWhitePawnWhoisBeatenByRed()
        {
            PawnBeat pawnBeat = new PawnBeat(cheesboard);
            pawnBeat.Move(cheesboardFieldCoordinatesD4, cheesboardFieldCoordinatesB2);

            IPawn actualC3Pawn = cheesboard.GetPawn(cheesboardFieldCoordinatesC3);

            Assert.AreEqual(Pawn.Null, actualC3Pawn, "When beaten, white pawn should be removed from field.");
        }

        [TestMethod()]
        public void shouldNullSourceFieldWhenBeatIsDone()
        {
            PawnBeat pawnBeat = new PawnBeat(cheesboard);
            pawnBeat.Move(cheesboardFieldCoordinatesD4, cheesboardFieldCoordinatesB2);

            IPawn actualD4Pawn = cheesboard.GetPawn(cheesboardFieldCoordinatesD4);

            Assert.AreEqual(Pawn.Null, actualD4Pawn, "Source field should be empty when beat is done.");
        }

        [TestMethod()]
        public void shouldPutRedPawnInDestinationFieldWhenBeatIsDone()
        {
            PawnBeat pawnBeat = new PawnBeat(cheesboard);
            pawnBeat.Move(cheesboardFieldCoordinatesD4, cheesboardFieldCoordinatesB2);

            IPawn actualB2Pawn = cheesboard.GetPawn(cheesboardFieldCoordinatesD4);

            Assert.AreEqual(Pawn.Null, actualB2Pawn, "Red pawn should be placed on destination field.");
        }
    }

    internal class CheesboardStub : ICheesboard
    {
        public ICheesboardField B2 { get; } = new CheesboardField(FieldColor.Black);
        public ICheesboardField C3 { get; } = new CheesboardField(FieldColor.Black);
        public ICheesboardField D4 { get; } = new CheesboardField(FieldColor.Black);
        private IPawn RedPawn = new Pawn(PlayerColor.Red);
        private IPawn WhitePawn = new Pawn(PlayerColor.White);
    

        public CheesboardStub()
        {
            D4.SetPawn(RedPawn);
            C3.SetPawn(WhitePawn);
        }

        public int GetCheesboardHeight()
        {
            throw new NotImplementedException();
        }

        public int GetCheesboardWidth()
        {
            throw new NotImplementedException();
        }

        public FieldColor GetFieldColor(ICheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public IPawn GetPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            if (CheesboardColumn.B == fieldCoordinates.Column && CheesboardRow.Two == fieldCoordinates.Row)
            {
                return GetPawn(B2);
            }

            if (CheesboardColumn.C == fieldCoordinates.Column && CheesboardRow.Three == fieldCoordinates.Row)
            {
                return GetPawn(C3);
            }

            if (CheesboardColumn.D == fieldCoordinates.Column && CheesboardRow.Four == fieldCoordinates.Row)
            {
                return GetPawn(D4);
            }

            return Pawn.Null;
        }

        private IPawn GetPawn(ICheesboardField cheesboardField)
        {
            return cheesboardField.GetPawn();
        }

        public bool IsFieldEmpty(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public IPawn PickPawn(ICheesboardFieldCoordinates fieldCoordinates)
        {
            if (CheesboardColumn.B == fieldCoordinates.Column && CheesboardRow.Two == fieldCoordinates.Row)
            {
                return PickPawn(B2);
            }

            if (CheesboardColumn.C == fieldCoordinates.Column && CheesboardRow.Three == fieldCoordinates.Row)
            {
                return PickPawn(C3);
            }

            if (CheesboardColumn.D == fieldCoordinates.Column && CheesboardRow.Four == fieldCoordinates.Row)
            {
                return PickPawn(D4);
            }

            return Pawn.Null;
        }

        private IPawn PickPawn(ICheesboardField cheesboardField)
        {
            return cheesboardField.PickPawn();
        }

        public void SetFieldColor(ICheesboardFieldCoordinates fieldCoordinates, FieldColor fieldColor)
        {
            throw new NotImplementedException();
        }

        public void SetPawn(ICheesboardFieldCoordinates fieldCoordinates, IPawn pawn)
        {
            if (CheesboardColumn.B == fieldCoordinates.Column && CheesboardRow.Two == fieldCoordinates.Row)
            {
                SetPawn(B2, pawn);
            }

            if (CheesboardColumn.C == fieldCoordinates.Column && CheesboardRow.Three == fieldCoordinates.Row)
            {
                SetPawn(C3, pawn);
            }

            if (CheesboardColumn.D == fieldCoordinates.Column && CheesboardRow.Four == fieldCoordinates.Row)
            {
                SetPawn(D4, pawn);
            }
        }

        private void SetPawn(ICheesboardField cheesboardField, IPawn pawn)
        {
            cheesboardField.SetPawn(pawn);
        }

        public bool IsFieldOccupied(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }
    }
}
