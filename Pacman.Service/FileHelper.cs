using Pacman.Service.Class;
using System.IO;

namespace Pacman.Service
{
    internal class FileHelper
    {
        public static PacmanBoard SetupPacmanBoard(string fileName)
        {
            var inputParameters = new PacmanBoard();
            using (var streamReader = new StreamReader(fileName))
            {
                var lineCount = 0;
                var tmp = string.Empty;

                while ((tmp = streamReader.ReadLine()) != null)
                {
                    switch (lineCount)
                    {
                        case 0:
                            inputParameters.Dimension = GetCoordinateFromString(tmp);
                            break;
                        case 1:
                            inputParameters.Position = GetCoordinateFromString(tmp);
                            break;
                        case 2:
                            inputParameters.Movements = tmp.ToCharArray();
                            break;
                        default:
                            inputParameters.Walls.Add(tmp);
                            break;
                    }

                    lineCount++;
                }

            }
            return inputParameters;
        }

        private static Coordinate GetCoordinateFromString(string coordinateString)
        {
            if (coordinateString?.Length < 3)
            {
                return null;
            }

            var coordinateArray = coordinateString.Split(' ');
            
            if (coordinateArray.Length == 2 &&
                int.TryParse(coordinateArray[0], out int x) &&
                int.TryParse(coordinateArray[1], out int y))
            {
                return new Coordinate(x, y);
            }

            return null;
        }
    }
}
