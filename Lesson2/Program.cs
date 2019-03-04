using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Царёв В.А.
 * 
 * 1. Реализовать функцию перевода из 10 системы в двоичную используя рекурсию.
 * 
 * 2. Реализовать функцию возведения числа a в степень b:
 * a. без рекурсии;
 * b. рекурсивно;
 * c. *рекурсивно, используя свойство чётности степени.
 * 
 * 3. Исполнитель Калькулятор преобразует целое число, записанное на экране.
 * У исполнителя две команды, каждой команде присвоен номер:
 * Прибавь 1 2.Умножь на 2 Первая команда увеличивает число на экране на 1,
 * вторая увеличивает это число в 2 раза. Сколько существует программ, 
 * которые число 3 преобразуют в число 20? 
 * а) с использованием массива; 
 * б) с использованием рекурсии.
 * 
 */

namespace _10to2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x10 = 0;
            int x = 45; // координаты формочки
            int y = 4;  // координаты формочки
            Console.Title = "Перевод в двоичную систему";
            PrintW(x, y);
            //Console.ReadKey();
            Print("|      Ввод данных          |", x, y + 1, ConsoleColor.Yellow);
            Print("Число в 10й системе:", x + 1 , y + 3, ConsoleColor.White);
            x10 = int.Parse(Read(x + 22, y + 3));
            Print("Число в 10й системе:", x + 1, y + 3, ConsoleColor.Green);
            Print("Число в 2й системе:", x + 2, y + 4, ConsoleColor.White);
            Print(ConvertTo2R(x10).ToString(), x + 22, y + 4, ConsoleColor.White);
            Print("Нажмите эникей для выхода", x - 1, y + 15, ConsoleColor.Gray);
            Console.ReadKey();
        }

        static string ConvertTo2(int x10)
        {
            int h= 1+(int)Math.Log(x10, 2);
            byte[] mas = new byte[h];
            int i = 0;
            string str = "";
            while (x10 > 1)
            {
                mas[i] = (byte) (x10 % 2);
                i++;
                
                x10 = x10 / 2;
            }
            mas[i] = (byte)(x10);
           
            for (i= mas.Length-1; i>=0; i--)
            {
                str += mas[i].ToString();
            }

            return str;
        }

        static int ConvertTo2R(int x10)
        {
            if ((x10 >= 0) && ((double)x10 / 2 < 1))
            {
                return x10 % 2;
            }
            else
            {
                return x10 % 2 + 10 * ConvertTo2R(x10 / 2);
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
            Print("|Число в 10й системе:       |", x, y++, ConsoleColor.Yellow);
            Print("| Число в 2й системе:       |", x, y++, ConsoleColor.Yellow);
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
