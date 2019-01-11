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
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_C1()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.C);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveB2_C3()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(actualIsMoveAvaliable, string.Format("White Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanNotMoveB2_A1()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.A);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("White Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_WhitePawnCanMoveB2_A3()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.A);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(actualIsMoveAvaliable, string.Format("White Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_B1()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.One, CheesboardColumn.B);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_B3()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.B);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_C2()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.C);

            cheesboard.SetFieldState(sourceField, CheesboardField.WhitePawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_PawnCanNotMoveB2_A2()
        {
            cheesboard.SetFieldState(new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B), CheesboardField.WhitePawn);

            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.A);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanMoveG7_F6()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.F);

            cheesboard.SetFieldState(sourceField, CheesboardField.RedPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(actualIsMoveAvaliable, string.Format("Red Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanNotMoveG7_F8()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.F);

            cheesboard.SetFieldState(sourceField, CheesboardField.RedPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("Red Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanMoveG7_H6()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.H);

            cheesboard.SetFieldState(sourceField, CheesboardField.RedPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsTrue(actualIsMoveAvaliable, string.Format("Red Pawn should have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_RedPawnCanNotMoveG7_H8()
        {
            CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
            CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.H);

            cheesboard.SetFieldState(sourceField, CheesboardField.RedPawn);

            DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
            bool actualIsMoveAvaliable = pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);

            Assert.IsFalse(actualIsMoveAvaliable, string.Format("Red Pawn should not have possibility to move from {0} to {1}", sourceField, destinationField));
        }

        [TestMethod()]
        public void IsMoveAvaliableTest_ThrowErrorWhenSourceFieldNotRedWhitePawn()
        {
            bool ExceptionRaised = false;
            try
            {
                CheesboardFieldCoordinates sourceField = new CheesboardFieldCoordinates(CheesboardRow.Seven, CheesboardColumn.G);
                CheesboardFieldCoordinates destinationField = new CheesboardFieldCoordinates(CheesboardRow.Eight, CheesboardColumn.H);

                cheesboard.SetFieldState(sourceField, CheesboardField.EmptyWhite);

                DraughtsPawnMoveValidator pawnMoveValidator = new DraughtsPawnMoveValidator(cheesboard);
                pawnMoveValidator.IsMoveAvaliable(sourceField, destinationField);
            }
            catch
            {
                ExceptionRaised = true;
            }

            Assert.IsTrue(ExceptionRaised, "When try to move anything different than Pawn, error should be thrown.");
        }



    }
}