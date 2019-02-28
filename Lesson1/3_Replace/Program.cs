using System;
/*
 * 3. Написать программу обмена значениями двух целочисленных переменных:
 * a. с использованием третьей переменной;
 * b. *без использования третьей переменной.
 */

namespace _Replace
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int x = 45;
            int y = 4;

            Console.Title = "Обмен переменных";
            PrintW(x, y);
            //Console.ReadKey();
            Print("|    Ввод данных     |", x, y + 1, ConsoleColor.Yellow);
            Print("Первая переменная:", x + 1, y + 3, ConsoleColor.White);
            a = int.Parse(Read(x + 20, y + 3));
            Print("Первая переменная:", x + 1, y + 3, ConsoleColor.Green);
            Print(a.ToString(), x + 20, y + 3, ConsoleColor.Red);
            Print("Вторая переменная:", x + 1, y + 4, ConsoleColor.White);
            b = int.Parse(Read(x + 20, y + 4));
            Print("Вторая переменная:", x + 1, y + 4, ConsoleColor.Green);
            Print(b.ToString(), x + 20, y + 4, ConsoleColor.Red);
            Print("Поменять местами - эникей", x - 1, y + 7, ConsoleColor.Gray);
            Console.ReadKey();
            Print(a.ToString(), x + 20, y + 3, ConsoleColor.Black);
            Print(b.ToString(), x + 20, y + 4, ConsoleColor.Black);
            Replace(ref a, ref b);
            Print(a.ToString(), x + 20, y + 3, ConsoleColor.Magenta);
            Print(b.ToString(), x + 20, y + 4, ConsoleColor.Magenta);

            Print("Нажмите эникей для выхода", x - 1, y + 15, ConsoleColor.Gray);
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод меню
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void PrintW(int x, int y)
        {
            Print("---------------------------", x, y++, ConsoleColor.Yellow);
            Print("|Ввод данных:             |", x, y++, ConsoleColor.Yellow);
            Print("---------------------------", x, y++, ConsoleColor.Yellow);
            Print("|Первая переменная:       |", x, y++, ConsoleColor.Yellow);
            Print("|Вторая переменная:       |", x, y++, ConsoleColor.Yellow);
            Print("---------------------------", x, y++, ConsoleColor.Yellow);
        }

        static void Print(string msg, int x, int y, ConsoleColor foregroundcolor)
        {
            // Установим позицию курсора на экране
            Console.SetCursorPosition(x, y);
            // Установим цвет символов
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg); //
        }

        static string Read(int x, int y)
        {
            ConsoleColor cc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            string s = Console.ReadLine();
            Console.ForegroundColor = cc;
            Print(s, x, y, ConsoleColor.Green);
            return s;
        }
        static void Replace(ref int a, ref int b)
        {
            //int c = b;
            //b = a;
            //a = c;

            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
