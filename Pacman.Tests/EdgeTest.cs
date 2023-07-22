using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.Tests
{
    [TestClass]
    public class EdgeTest
    {
        private Service.PacmanService _service;
        private Service.Class.PacmanBoard _board;

        public EdgeTest()
        {
            _service = new Service.PacmanService();
        }

        [TestMethod]
        public void TestEdge_InValidParameters()
        {
            var response = _service.ProcessFromFile("wronglocation.txt");
            Assert.AreEqual(response.Item1, -1);
            Assert.AreEqual(response.Item2, -1);
            Assert.AreEqual(response.Item3, 0);
        }

        [TestMethod]
        public void TestEdge_OutOfBoard()
        {
            _board = new Service.Class.PacmanBoard();
            _board.Dimension = new Service.Class.Coordinate(10, 10);
            _board.Position = new Service.Class.Coordinate(13, 13);
            _board.Movements = "NN".ToCharArray();

            var response = _service.ProcessMovements(_board);
            Assert.AreEqual(response.Item1, -1);
            Assert.AreEqual(response.Item2, -1);
            Assert.AreEqual(response.Item3, 0);
        }

        [TestMethod]
        public void TestEdge_MinimumMovements()
        {
            _board = new Service.Class.PacmanBoard();
            _board.Dimension = new Service.Class.Coordinate(10, 10);
            _board.Position = new Service.Class.Coordinate(5, 5);
            _board.Movements = "".ToCharArray();

            var response = _service.ProcessMovements(_board);
            Assert.AreEqual(response.Item1, -1);
            Assert.AreEqual(response.Item2, -1);
            Assert.AreEqual(response.Item3, 0);
        }
    }
}
