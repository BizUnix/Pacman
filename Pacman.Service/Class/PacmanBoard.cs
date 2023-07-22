using System.Collections.Generic;

namespace Pacman.Service.Class
{
    public class PacmanBoard
    {
        public PacmanBoard()
        {
            Walls = new HashSet<string>();
        }

        public Coordinate Dimension { get; set; }

        public Coordinate Position { get; set; }

        public char[] Movements { get; set; }

        public HashSet<string> Walls { get; set; }

        public bool HasValidParameters()
        {
            if (Dimension == null ||
                Position == null ||
                Movements?.Length < 1 ||
                Position.X > Dimension.X - 1 ||
                Position.Y > Dimension.Y - 1)
            {
                return false;
            }
            return true;
        }

        private bool CanMoveTo(int x, int y)
        {
            // Stopping on wall or on the edge
            if (Walls.Contains($"{x} {y}") || x > Dimension.X - 1 || y > Dimension.Y - 1)
                return false;
            return true;
        }

        public bool MoveToNorth()
        {
            if (CanMoveTo(Position.X, Position.Y+1))
            {
                Position.Y++;
                return true;
            }
            return false;
        }

        public bool MoveToEast()
        {
            if (CanMoveTo(Position.X+1, Position.Y))
            {
                Position.X++;
                return true;
            }
            return false;
        }

        public bool MoveToSouth()
        {
            if (CanMoveTo(Position.X, Position.Y - 1))
            {
                Position.Y--;
                return true;
            }
            return false;
        }

        public bool MoveToWest()
        {
            if (CanMoveTo(Position.X-1, Position.Y))
            {
                Position.X--;
                return true;
            }
            return false;
        }
    }
}
