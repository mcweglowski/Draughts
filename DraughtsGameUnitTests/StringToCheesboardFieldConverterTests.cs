using DraughtsGame.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGame.Tests_StringToCheesboardFieldConverterTests
{
    [TestClass()]
    public class StringToCheesboardFieldConverterTests
    {
        [TestMethod()]
        public void shouldConvertStringToCheesboardField()
        {
            string A4 = "A4";
            ICheesboardFieldCoordinates expectedCheesboardFieldCoordinates = new CheesboardFieldCoordinates(CheesboardRow.Four, CheesboardColumn.A);

            StringToCheesboardFieldConverter stringToCheesboardFieldConverter = new StringToCheesboardFieldConverter();
            ICheesboardFieldCoordinates actualCheesboardFieldCoordinates = stringToCheesboardFieldConverter.Convert(A4);

            Assert.AreEqual(expectedCheesboardFieldCoordinates, actualCheesboardFieldCoordinates);
        }
    }
}
