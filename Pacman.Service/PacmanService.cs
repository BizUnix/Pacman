using Pacman.Service.Class;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pacman.Service
{
    public class PacmanService
    {
        public Tuple<int, int, int> ProcessFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var pacmanBoard = FileHelper.SetupPacmanBoard(fileName);
                // Validate input parameters
                if (pacmanBoard.HasValidParameters())
                {
                    return ProcessMovements(pacmanBoard);
                }
            }

            return new Tuple<int, int, int>(-1, -1, 0);
        }


        public Tuple<int, int, int> ProcessMovements(PacmanBoard pacmanBoard)
        {
            if (!pacmanBoard.HasValidParameters())
                return new Tuple<int, int, int>(-1, -1, 0);

            var coins = 0;
            var visited = new HashSet<string>();
            visited.Add($"{pacmanBoard.Position.X} {pacmanBoard.Position.Y}");

            for (int i = 0; i < pacmanBoard.Movements.Length; i++)
            {
                switch (pacmanBoard.Movements[i])
                {
                    case 'N':
                        if (pacmanBoard.MoveToNorth())
                        {
                            if (visited.Add($"{pacmanBoard.Position.X} {pacmanBoard.Position.Y}"))
                                coins++;
                        }
                        break;
                    case 'E':
                        if (pacmanBoard.MoveToEast())
                        {
                            if (visited.Add($"{pacmanBoard.Position.X} {pacmanBoard.Position.Y}"))
                                coins++;
                        }
                        break;
                    case 'S':
                        if (pacmanBoard.MoveToSouth())
                        {
                            if (visited.Add($"{pacmanBoard.Position.X} {pacmanBoard.Position.Y}"))
                                coins++;
                        }
                        break;
                    case 'W':
                        if (pacmanBoard.MoveToWest())
                        {
                            if (visited.Add($"{pacmanBoard.Position.X} {pacmanBoard.Position.Y}"))
                                coins++;
                        }
                        break;
                    default:
                        Console.WriteLine("Unhandled movement " + pacmanBoard.Movements[i]);
                        break;
                }
            }
            return new Tuple<int, int, int>(pacmanBoard.Position.X, pacmanBoard.Position.Y, coins);
        }

    }
}
