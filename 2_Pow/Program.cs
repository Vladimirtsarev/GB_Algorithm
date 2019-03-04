using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 2. Реализовать функцию возведения числа a в степень b:
 * a. без рекурсии;
 * b. рекурсивно;
 * c. *рекурсивно, используя свойство чётности степени.
 */

namespace _2_Pow
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int x = 45; // координаты формочки
            int y = 4;  // координаты формочки
            Console.Title = "Возведение в степень";
            PrintW(x, y);
            
            Print("|      Ввод данных          |", x, y + 1, ConsoleColor.Yellow);
            Print("Число ", x + 1, y + 3, ConsoleColor.White);
            a = int.Parse(Read(x + 7, y + 3));
            Print("Число ", x + 1, y + 3, ConsoleColor.Green);
            Print(" в степени", x + 8, y + 3, ConsoleColor.White);
            b = int.Parse(Read(x + 19, y + 3));
            Print(" в степени", x + 8, y + 3, ConsoleColor.Green);
            //Print(Pow_a(a, b).ToString(), x + 8, y + 4, ConsoleColor.White);
            //Print(Pow_b(a, b).ToString(), x + 8, y + 4, ConsoleColor.White);
            Print(Pow_c(a, b).ToString(), x + 8, y + 4, ConsoleColor.White);
            Print("Нажмите эникей для выхода", x - 1, y + 15, ConsoleColor.Gray);
            Console.ReadKey();
        }

        /// <summary>
        /// Возведение в степень без рекурсии
        /// </summary>
        /// <param name="a">число</param>
        /// <param name="b">степень</param>
        /// <returns>результат</returns>
        static int Pow_a(int a, int b)
        {
            int result = 1;
            for (int i = b; i > 0; i--)
            {
                result = result * a;
            }
            return result;
        }

        /// <summary>
        /// Возведение в степень с рекурсией
        /// </summary>
        /// <param name="a">число</param>
        /// <param name="b">степень</param>
        /// <returns>результат</returns>
        static int Pow_b(int a, int b)
        {
            int result = 1;
            if (b>=1)
            result = Pow_b(a, --b) * a;
            return result;
        }

        /// <summary>
        /// Возведение в степень с рекурсией чет
        /// </summary>
        /// <param name="a">число</param>
        /// <param name="b">степень</param>
        /// <returns>результат</returns>
        static int Pow_c(int a, int b)
        {
            if (b < 2)
            {
                return a;
            }
            int tmp = Pow_c(a, (b - b % 2) / 2) * Pow_c(a, (b - b % 2) / 2);
            if (b % 2 == 0)
            {
                return tmp;
            }
            else
            {
                return tmp * a;
            }
                       
        }


        static void Print(string msg, int x, int y, ConsoleColor foregroundcolor)
        {
            // Установим позицию курсора на экране
            Console.SetCursorPosition(x, y);
            // Установим цвет символов
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg); //
        }

        /// <summary>
        /// Вывод меню
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void PrintW(int x, int y)
        {
            Print("-----------------------------", x, y++, ConsoleColor.Yellow);
            Print("|   Ввод данных:  эникей    |", x, y++, ConsoleColor.Yellow);
            Print("-----------------------------", x, y++, ConsoleColor.Yellow);
            Print("|Число   в степени          |", x, y++, ConsoleColor.Yellow);
            Print("|Равно:                     |", x, y++, ConsoleColor.Yellow);
            Print("-----------------------------", x, y++, ConsoleColor.Yellow);
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
    }
}
