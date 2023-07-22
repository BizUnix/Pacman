using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidationTests_InvalidPosition()
        {
            var board = new Service.Class.PacmanBoard();
            board.Dimension = new Service.Class.Coordinate(10, 10);
            board.Position = new Service.Class.Coordinate(13, 13);
            board.Movements = "NN".ToCharArray();

            Assert.IsFalse(board.HasValidParameters());
        }

        [TestMethod]
        public void ValidationTests_InvalidMovements()
        {
            var board = new Service.Class.PacmanBoard();
            board.Dimension = new Service.Class.Coordinate(10, 10);
            board.Position = new Service.Class.Coordinate(5, 5);
            board.Movements = "".ToCharArray();

            Assert.IsFalse(board.HasValidParameters());
        }
    }
}
