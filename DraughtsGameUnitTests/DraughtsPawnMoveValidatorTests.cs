using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Tests_PawnMoveValidatorTests
{
    [TestClass()]
    public class PawnMoveValidatorTests
    {
        ICheesboard cheesboard = new Cheesboard();

        [TestInitialize]
        public void TestInitialize()
        {
            CheesboardInitializer cheesboardInitializer = new CheesboardInitializer(cheesboard);
            cheesboardInitializer.InitNewCheesboard();
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveB2_C1()
        {            
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.C);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(actualIsMoveAvaliable, string.Format("White Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveB2_C3()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(actualIsMoveAvaliable, string.Format("White Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_A1()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_A3()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.A);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_B1()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.B);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_B3()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.B);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCantMoveB2_C2()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.C);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCantMoveB2_A2()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.A);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }
    }
}