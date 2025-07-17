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

int top = Console.CursorTop;
int left = Console.CursorLeft;

ConsoleKey key;

do
{
    key = Console.ReadKey(true).Key;


    int newTop = top;
    int newLeft = left;


    switch (key)
    {
        case ConsoleKey.UpArrow:
            newTop--;
            break;
        case ConsoleKey.DownArrow:
            newTop++;
            break;
        case ConsoleKey.LeftArrow:
            newLeft--;
            break;
        case ConsoleKey.RightArrow:
            newLeft++;
            break;
    }


    if (newTop >= 0 && newTop < mapRows.Length &&
        newLeft >= 0 && newLeft < mapRows[newTop].Length &&
        mapRows[newTop][newLeft] != '*')
    {
        top = newTop;
        left = newLeft;
        Console.SetCursorPosition(left, top);
    }

} while (key != ConsoleKey.Escape);

int badGuy1Top = 5, badGuy1Left = 5;
int badGuy2Top = 10, badGuy2Left = 10;
Random rand = new Random();


Console.SetCursorPosition(badGuy1Left, badGuy1Top);
Console.Write(' ');
Console.SetCursorPosition(badGuy2Left, badGuy2Top);
Console.Write(' ');


int move1 = rand.Next(4);
if (move1 == 0) badGuy1Top++;
else if (move1 == 1) badGuy1Top--;
else if (move1 == 2) badGuy1Left++;
else if (move1 == 3) badGuy1Left--;

int move2 = rand.Next(4);
if (move2 == 0) badGuy2Top++;
else if (move2 == 1) badGuy2Top--;
else if (move2 == 2) badGuy2Left++;
else if (move2 == 3) badGuy2Left--;


Console.SetCursorPosition(badGuy1Left, badGuy1Top);
Console.Write('%');
Console.SetCursorPosition(badGuy2Left, badGuy2Top);
Console.Write('%');


if ((top == badGuy1Top && left == badGuy1Left) ||
    (top == badGuy2Top && left == badGuy2Left))
{
    Console.Clear();
    Console.WriteLine("You Lose!");
    return;
}

int score = 0;

if (mapRows[top][left] == '^')
{
    mapRows[top] = mapRows[top].Remove(left, 1).Insert(left, " ");
    Console.SetCursorPosition(left, top); Console.Write(' ');
    score += 100;
}


Console.SetCursorPosition(0, mapRows.Length);
Console.Write("Score: " + score);

if (score >= 1000)
{
    int middleRow = mapRows.Length / 2;
    int middleCol = mapRows[middleRow].Length / 2;

    mapRows[middleRow] = mapRows[middleRow].Remove(middleCol, 1).Insert(middleCol, " ");
    Console.SetCursorPosition(middleCol, middleRow);
    Console.Write(' ');
}

DateTime startTime = DateTime.Now;
if (mapRows[top][left] == '#')
{
    Console.Clear();
    Console.WriteLine("Congratulations! You won!");
    Console.WriteLine($"Score: {score}");

    TimeSpan time = DateTime.Now - startTime;
    Console.WriteLine($"Time in maze: {time.TotalSeconds:F1} seconds");
    return;
}

