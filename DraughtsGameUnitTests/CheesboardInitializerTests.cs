﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraughtsGame;
using System;

namespace DraughtsGame.Tests_CheesboardInitializer
{
    [TestClass()]
    public class CheesboardInitializerTests
    {
        [TestMethod()]
        public void InitNewCheesboard32BlackFieldsExpectedTest()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(32, cheesboard.blackFieldsCount, string.Format("Initialized cheeseboard should have 32 black fields, but it has {0}.", cheesboard.blackFieldsCount));
        }

        [TestMethod()]
        public void InitNewCheesboard32WhiteFieldsExpectedTest()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(32, cheesboard.whiteFieldsCount, string.Format("Initialized cheeseboard should have 32 white fields, but it has {0}.", cheesboard.whiteFieldsCount));
        }

        [TestMethod()]
        public void InitNewCheesboardNoOtherThanWhiteBlackFieldsTest()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(0, cheesboard.otherFieldsCount, string.Format("Initialized cheeseboard should have 0 fields other than black or white, but it has {0} of them.", cheesboard.whiteFieldsCount));
        }

        [TestMethod]
        public void InitNewCheesboartA1FieldShouldBeEmptyBlack()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(CheesboardField.EmptyBlack, cheesboard.A1field, "A1 field should be EmptyBlack.");
        }

        [TestMethod]
        public void InitNewCheesboartH8FieldShouldBeEmptyBlack()
        {
            CheesboardStub cheesboard = new CheesboardStub();
            CheesboardInitializer draughtsCheesboardInitializer = new CheesboardInitializer(cheesboard);
            draughtsCheesboardInitializer.InitNewCheesboard();

            Assert.AreEqual(CheesboardField.EmptyBlack, cheesboard.H8field, "H8 field should be EmptyBlack.");
        }
    }

    class CheesboardStub : ICheesboard
    {
        public int blackFieldsCount = 0;
        public int whiteFieldsCount = 0;
        public int otherFieldsCount = 0;
        public CheesboardField A1field;
        public CheesboardField H8field;

        public int GetCheesboardHeight()
        {
            return 8;
        }

        public int GetCheesboardWidth()
        {
            return 8;
        }

        public CheesboardField GetFieldState(CheesboardFieldCoordinates fieldCoordinates)
        {
            throw new NotImplementedException();
        }

        public void SetFieldState(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
            CountFields(fieldState);
            SetA1Field(fieldCoordinates, fieldState);
            SetH8Field(fieldCoordinates, fieldState);
        }

        private void SetH8Field(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
            if (CheesboardRow.Eight == fieldCoordinates.Row && CheesboardColumn.H == fieldCoordinates.Column)
                H8field = fieldState;
        }

        private void SetA1Field(CheesboardFieldCoordinates fieldCoordinates, CheesboardField fieldState)
        {
            if (CheesboardRow.One == fieldCoordinates.Row && CheesboardColumn.A == fieldCoordinates.Column)
                A1field = fieldState;
        }

        private void CountFields(CheesboardField fieldState)
        {
            switch (fieldState)
            {
                case CheesboardField.EmptyBlack:
                    blackFieldsCount++;
                    break;
                case CheesboardField.EmptyWhite:
                    whiteFieldsCount++;
                    break;
                default:
                    otherFieldsCount++;
                    break;
            };
        }
    }
}