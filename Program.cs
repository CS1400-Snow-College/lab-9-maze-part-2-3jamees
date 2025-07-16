// See https://aka.ms/new-console-template for more information
// Author: James King II
// Date: July 15, 2025
// Lab: Lab 9 - Maze #2

{
    Console.WriteLine("Welcome to Maze #2!");
    Console.WriteLine("Navigate through the maze, avoid the bad guys, and collect all coins.");
    Console.WriteLine("Press any key to begin...");
    Console.ReadKey();
}

    string[] mapRows = File.ReadAllLines("map.txt");
    Console.Clear();
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}

Console.SetCursorPosition(0, 0); 
ConsoleKey key;

do
{
    key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.UpArrow:
            Console.CursorTop--;
            break;
        case ConsoleKey.DownArrow:
            Console.CursorTop++;
            break;
        case ConsoleKey.LeftArrow:
            Console.CursorLeft--;
            break;
        case ConsoleKey.RightArrow:
            Console.CursorLeft++;
            break;
    }

} while (key != ConsoleKey.Escape);



