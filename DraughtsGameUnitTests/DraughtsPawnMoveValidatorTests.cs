﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DraughtsGame.Interfaces;

namespace DraughtsGame.Tests_PawnMoveValidatorTests
{
    [TestClass()]
    public class PawnMoveValidatorTests
    {
        ICheesboard cheesboard;
        IPawn whitePawn;
        IPawn redPawn;

        [TestInitialize]
        public void TestInitialize()
        {
            cheesboard = new Cheesboard();

            IInitializer initializer = new CheesboardInitializer();
            initializer.Initialize(cheesboard);

            whitePawn = new Pawn(PlayerColor.White, new List<MoveCoordinate>() { new MoveCoordinate(1, -1), new MoveCoordinate(1, 1) }, cheesboard);
            redPawn = new Pawn(PlayerColor.Red, new List<MoveCoordinate>() { new MoveCoordinate(-1, -1), new MoveCoordinate(-1, 1) }, cheesboard);
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_C1()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.C);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move  = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveB2_C3()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(move.Move(sourceField, destinationField), string.Format("White Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_A1()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveB2_A3()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.A);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(move.Move(sourceField, destinationField), string.Format("White Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_B1()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.B);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_B3()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.B);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_C2()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.C);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_A2()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.A);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanMoveG7_F6()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.F);

            cheesboard.SetPawn(sourceField, redPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(move.Move(sourceField, destinationField), string.Format("Red Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanNotMoveG7_F8()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.F);

            cheesboard.SetPawn(sourceField, redPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("Red Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanMoveG7_H6()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.H);

            cheesboard.SetPawn(sourceField, redPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(move.Move(sourceField, destinationField), string.Format("Red Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanNotMoveG7_H8()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.H);

            cheesboard.SetPawn(sourceField, redPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), string.Format("Red Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCantMoveIfFieldOccupied()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.C);

            cheesboard.SetPawn(sourceField, whitePawn);
            cheesboard.SetPawn(destinationField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), "Move should not be possible, destination field is occupied.");
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCantMoveTwoFieldsForward()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.D);

            cheesboard.SetPawn(sourceField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(move.Move(sourceField, destinationField), "Pawn should not be able to move two fields forward if middle field is empty.");
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveTwoFieldsForwardWhenMiddleFieldOccupiedByOponent()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.B);
            CheesboardFieldCoordinates middleField = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.C);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.D);

            cheesboard.SetPawn(sourceField, whitePawn);
            cheesboard.SetPawn(middleField, redPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(move.Move(sourceField, destinationField), "Pawn should be able to move two fields forward if middle field is occupied by oponent pawn.");
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanMoveTwoFieldsForwardWhenMiddleFieldOccupiedByOponent()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.D);
            CheesboardFieldCoordinates middleField = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.C);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.B);

            cheesboard.SetPawn(sourceField, redPawn);
            cheesboard.SetPawn(middleField, whitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            IMove move = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(move.Move(sourceField, destinationField), "Pawn should be able to move two fields forward if middle field is occupied by oponent pawn.");
        }
    }
}