using DraughtsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DraughtsGameUnitTests
{
    public class DraughtsGameTwoRowsInitializerTest
    {
        public void TestIfTwoRowsGameInitialized()
        {
            ICheesboard cheesboard = new Cheesboard();

            DraughtsGameTwoRowsInitializer draughtsGameTwoRowsInitializer = new DraughtsGameTwoRowsInitializer(cheesboard);
            draughtsGameTwoRowsInitializer.InitializeNewGame();
        }
    }
}
