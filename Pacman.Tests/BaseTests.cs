using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.Tests
{
    [TestClass]
    public class BaseTests
    {
        private Service.PacmanService _service;
        private Service.Class.PacmanBoard _board;

        public BaseTests()
        {
            _service = new Service.PacmanService();
            _board = new Service.Class.PacmanBoard();
            _board.Dimension = new Service.Class.Coordinate(5, 5);
            _board.Position = new Service.Class.Coordinate(1, 2);
            _board.Movements = "NNESEESWNWW".ToCharArray();
            _board.Walls.Add("1 0");
            _board.Walls.Add("2 2");
            _board.Walls.Add("2 3");
        }

        [TestMethod]
        public void TestEdge_InValidParameters()
        {
            var response = _service.ProcessMovements(_board);
            Assert.AreEqual(response.Item1, 1);
            Assert.AreEqual(response.Item2, 4);
            Assert.AreEqual(response.Item3, 7);
        }
    }
}
