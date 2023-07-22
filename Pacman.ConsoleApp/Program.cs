// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to Pacman World!!");

var files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\test_files", "*.txt");

var pacmanService = new Pacman.Service.PacmanService();

foreach (var file in files)
{
    Console.WriteLine("Processing ...." +file);

    var response = pacmanService.ProcessFromFile(file);

    Console.WriteLine("finalXposition=" + response.Item1);
    Console.WriteLine("finalYposition=" + response.Item2);
    Console.WriteLine("totalCoins=" + response.Item3);
}
