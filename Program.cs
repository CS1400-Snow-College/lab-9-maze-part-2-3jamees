// See https://aka.ms/new-console-template for more information
// Author: James King II
// Date: July 15, 2025
// Lab: Lab 9 - Maze #2


{
    Console.WriteLine("Welcome to Maze #2!");
    Console.WriteLine("Navigate through the maze, avoid the bad guys, and collect all coins.");
    Console.WriteLine("Press any key to begin...");
    Console.ReadKey();

    string[] mapRows = File.ReadAllLines("maze.txt");
    Console.Clear();

    foreach (string row in mapRows)
    {
        Console.WriteLine(row);
    }

    int top = 1, left = 1;
    int badGuy1Top = 5, badGuy1Left = 5;
    int badGuy2Top = 10, badGuy2Left = 10;
    int score = 0;
    Random rand = new Random();
    DateTime startTime = DateTime.Now;

    Console.SetCursorPosition(left, top);

    while (true)
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        int newTop = top;
        int newLeft = left;

        if (key == ConsoleKey.UpArrow) newTop--;
        if (key == ConsoleKey.DownArrow) newTop++;
        if (key == ConsoleKey.LeftArrow) newLeft--;
        if (key == ConsoleKey.RightArrow) newLeft++;
        if (key == ConsoleKey.Escape) break;

        if (newTop >= 0 && newTop < mapRows.Length &&
            newLeft >= 0 && newLeft < mapRows[newTop].Length &&
            mapRows[newTop][newLeft] != '*')
        {
            top = newTop;
            left = newLeft;
            Console.SetCursorPosition(left, top);
        }

           
            if (mapRows[top][left] == '^')
        {
            mapRows[top] = mapRows[top].Remove(left, 1).Insert(left, " ");
            Console.SetCursorPosition(left, top); Console.Write(' ');
            score += 100;
        }

            
            
            int scoreRow = Math.Min(mapRows.Length, Console.BufferHeight - 1);
            Console.SetCursorPosition(0, scoreRow);
            Console.Write("Score: " + score + "   ");


            
            if (score >= 1000)
        {
            int midRow = mapRows.Length / 2;
            int midCol = mapRows[midRow].Length / 2;

            mapRows[midRow] = mapRows[midRow].Remove(midCol, 1).Insert(midCol, " ");
            Console.SetCursorPosition(midCol, midRow);
            Console.Write(' ');
        }

            
            Console.SetCursorPosition(badGuy1Left, badGuy1Top); Console.Write(' ');
            Console.SetCursorPosition(badGuy2Left, badGuy2Top); Console.Write(' ');

            int move = rand.Next(4);
            if (move == 0) badGuy1Top++;
            if (move == 1) badGuy1Top--;
            if (move == 2) badGuy1Left++;
            if (move == 3) badGuy1Left--;

            move = rand.Next(4);
            if (move == 0) badGuy2Top++;
            if (move == 1) badGuy2Top--;
            if (move == 2) badGuy2Left++;
            if (move == 3) badGuy2Left--;

            Console.SetCursorPosition(badGuy1Left, badGuy1Top); Console.Write('%');
            Console.SetCursorPosition(badGuy2Left, badGuy2Top); Console.Write('%');

            
            if ((top == badGuy1Top && left == badGuy1Left) || (top == badGuy2Top && left == badGuy2Left))
        {
            Console.Clear();
            Console.WriteLine("You Lose!");
            return;
        }

            
            if (mapRows[top][left] == '#')
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You won!");
            Console.WriteLine("Score: " + score);
            TimeSpan time = DateTime.Now - startTime;
            Console.WriteLine("Time in maze: " + time.TotalSeconds.ToString("F1") + " seconds");
            return;
        }
    }
}

