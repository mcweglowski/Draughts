﻿using DraughtsGame;
using DraughtsGame.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameUnitTests_DraughtsAvaliableBeatsFinder
{
    [TestClass()]
    public class DraughtsAvaliableBeatsFinderTests
    {
        ICheesboard cheesboard;
        CheesboardFieldCoordinates sourceFieldD4 = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.D);
        CheesboardFieldCoordinates occupiedFieldC3 = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.C);
        CheesboardFieldCoordinates occupiedFieldC5 = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.C);
        CheesboardFieldCoordinates occupiedFieldE3 = new CheesboardFieldCoordinates(CheesboardRow.Three, CheesboardColumn.E);
        CheesboardFieldCoordinates occupiedFieldE5 = new CheesboardFieldCoordinates(CheesboardRow.Five, CheesboardColumn.E);

        [TestInitialize()]
        public void TestInitialize()
        {
            cheesboard = new Cheesboard();
        }

        [TestMethod()]
        public void shouldReturnFourAvaliableBeatMoves()
        {
            int expectedAvaliableBeats = 4;
            cheesboard.SetPawn(sourceFieldD4, new Pawn(PlayerColor.Red));
            cheesboard.SetPawn(occupiedFieldC3, new Pawn(PlayerColor.White));
            cheesboard.SetPawn(occupiedFieldC5, new Pawn(PlayerColor.White));
            cheesboard.SetPawn(occupiedFieldE3, new Pawn(PlayerColor.White));
            cheesboard.SetPawn(occupiedFieldE5, new Pawn(PlayerColor.White));

            DraughtsAvaliableBeatsFinder draughtsAvaliableBeatsFinder = new DraughtsAvaliableBeatsFinder(cheesboard);
            IList<CheesboardFieldCoordinates> avaliableBeats = draughtsAvaliableBeatsFinder.GetAvaliableBeats(sourceFieldD4);

            Assert.AreEqual(expectedAvaliableBeats, avaliableBeats.Count);
			Assert.IsNotNull(avaliableBeats.Single(x => x == new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B)));
			Assert.IsNotNull(avaliableBeats.Single(x => x == new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.B)));
			Assert.IsNotNull(avaliableBeats.Single(x => x == new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.F)));
			Assert.IsNotNull(avaliableBeats.Single(x => x == new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.F)));
		}

		[TestMethod]
        public void shouldReturnB2AsAvaliableBeatMove()
        {
            int expectedAvaliableBeats = 1;
            CheesboardFieldCoordinates expectedFieldB2 = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            cheesboard.SetPawn(sourceFieldD4, new Pawn(PlayerColor.Red));
            cheesboard.SetPawn(occupiedFieldC3, new Pawn(PlayerColor.White));

            DraughtsAvaliableBeatsFinder draughtsAvaliableBeatsFinder = new DraughtsAvaliableBeatsFinder(cheesboard);
            IList<CheesboardFieldCoordinates> avaliableBeats = draughtsAvaliableBeatsFinder.GetAvaliableBeats(sourceFieldD4);

            Assert.AreEqual(expectedAvaliableBeats, avaliableBeats.Count);
            Assert.IsNotNull(avaliableBeats.Where(x => x == expectedFieldB2).FirstOrDefault());
        }


        [TestMethod]
        public void shouldReturnC3F5AsAvaliableBeatMove()
        {
            int expectedAvaliableBeats = 2;
            CheesboardFieldCoordinates expectedFieldB2 = new CheesboardFieldCoordinates(CheesboardRow.Two, CheesboardColumn.B);
            CheesboardFieldCoordinates expectedFieldF6 = new CheesboardFieldCoordinates(CheesboardRow.Six, CheesboardColumn.F);

            cheesboard.SetPawn(sourceFieldD4, new Pawn(PlayerColor.Red));
            cheesboard.SetPawn(occupiedFieldC3, new Pawn(PlayerColor.White));
            cheesboard.SetPawn(occupiedFieldE5, new Pawn(PlayerColor.White));

            DraughtsAvaliableBeatsFinder draughtsAvaliableBeatsFinder = new DraughtsAvaliableBeatsFinder(cheesboard);
            IList<CheesboardFieldCoordinates> avaliableBeats = draughtsAvaliableBeatsFinder.GetAvaliableBeats(sourceFieldD4);

            Assert.AreEqual(expectedAvaliableBeats, avaliableBeats.Count);
            Assert.IsNotNull(avaliableBeats.Where(x => x == expectedFieldB2).FirstOrDefault());
			Assert.IsNotNull(avaliableBeats.Where(x => x == expectedFieldF6).FirstOrDefault());
		}
	}

}