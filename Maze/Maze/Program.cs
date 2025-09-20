using System;

class Program
{
    static int playerX = 1, playerY = 1;
    static int exitX, exitY;

    static string[] map = new string[]
    {
        "█████████████████████████████████████████",
        "█     █       █     █           █       █",
        "█ ███ █ ███ █ █ ███ █ ███████ █ ███████ █",
        "█ █   █   █ █ █   █ █       █ █         █",
        "█ █ ███ █ █ █ █ █ █ █ ███ █ █ █ ███ ███ █",
        "█ █     █ █ █ █ █   █   █ █ █   █   █ █ █",
        "█ █ █████ █ █ █ █████ █ █ █ ███ █ ███ █ █",
        "█ █       █ █ █       █ █ █   █ █   █ █ █",
        "█ ███████ █ █ ███████ █ █ ███ █ █ ███ █ █",
        "█         █           █       █         █",
        "█ ███ ███ █ ███████ ███████ █ █████ ███ █",
        "█   █ █   █       █         █ █     █   █",
        "█ █ █ █ █████ █████████ ███ █ ███ █ ███ █",
        "█ █ █ █     █       █   █   █ █   █ █   █",
        "█ █ █ █ ███ ███ ███ █ █ ███ █ █ █ █ █ █ █",
        "█ █ █   █   █   █   █ █ █   █   █ █   █ █",
        "█ █████ █████ █ █████ █ █ █████ █ █████ █",
        "█       █     █       █ █       █       █",
        "███████ █████ ███████ █ ███████ ███████ █",
        "█       █     █       █       █         █",
        "█ █████ █ █████ █████ █████ █ █████ ███ █",
        "█     █ █       █   █       █       █   █",
        "█ ███ █ █████████ █████████ ███████ ███ █",
        "█   █                         █         █",
        "███████████████████████████████████████ E",
    };

    static void Main()
    {
        Console.CursorVisible = false;

        // Находим выход в карте
        FindExit();

        while (true)
        {
            Draw();

            // Проверка победы
            if (playerX == exitX && playerY == exitY)
            {
                Console.SetCursorPosition(0, map.Length + 1);
                Console.WriteLine("Вы победили!!! Нажмите любую клавишу...");
                Console.ReadKey(true);
                break;
            }

            var key = Console.ReadKey(true).Key;
            int newX = playerX, newY = playerY;

            switch (key)
            {
                case ConsoleKey.UpArrow: newX--; break;
                case ConsoleKey.DownArrow: newX++; break;
                case ConsoleKey.LeftArrow: newY--; break;
                case ConsoleKey.RightArrow: newY++; break;
                case ConsoleKey.Escape: return;
            }

            // Проверка границ и проходимости
            if (newX >= 0 && newX < map.Length &&
                newY >= 0 && newY < map[newX].Length &&
                (map[newX][newY] == ' ' || map[newX][newY] == 'E'))
            {
                playerX = newX;
                playerY = newY;
            }
        }
    }

    static void Draw()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (i == playerX && j == playerY)
                    Console.Write("*");
                else
                    Console.Write(map[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("Управление: стрелки, Esc - выход");
    }

    static void FindExit()
    {
        for (int i = 0; i < map.Length; i++)
        {
            int col = map[i].IndexOf('E');
            if (col != -1)
            {
                exitX = i;
                exitY = col;
                return;
            }
        }
    }
}