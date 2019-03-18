using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Царёв ВА
 * 
 * 1. Реализовать перевод из 10 в 2 систему счисления с использованием стека.
 * 
 * 2. Добавить в программу “реализация стека на основе односвязного списка” 
 * проверку на выделение памяти. Если память не выделяется,
 * то выводится соответствующее сообщение. Постарайтесь создать ситуацию,
 * когда память не будет выделяться (добавлением большого количества данных).
 * 
 * 3. Написать программу, которая определяет, является ли введенная скобочная
 * последовательность правильной. Примеры правильных скобочных выражений:
 * (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.
 * Например: (2+(2*2)) или [2/{5*(4+7)}]
 * 
 * 4. *Создать функцию, копирующую односвязный список (то есть создает в памяти 
 * копию односвязного списка, без удаления первого списка).
 * 
 * 5. **Реализовать алгоритм перевода из инфиксной записи арифметического
 * выражения в постфиксную.
 * 
 * 6. *Реализовать очередь.
 * 
 */

namespace _1
{
    class Program
    {
        static Stack<int> MyStack = new Stack<int>();

        static void Main()
        {
            
            int x10 = 0;
            int x = 45; // координаты формочки
            int y = 4;  // координаты формочки
            Console.Title = "Перевод в двоичную систему";
            PrintW(x, y);
            Print("|      Ввод данных          |", x, y + 1, ConsoleColor.Yellow);
            Print("Число в 10й системе:", x + 1, y + 3, ConsoleColor.White);
            x10 = int.Parse(Read(x + 22, y + 3));
            Print("Число в 10й системе:", x + 1, y + 3, ConsoleColor.Green);
            Print("Число в 2й системе:", x + 2, y + 4, ConsoleColor.White);
            Print(ConvertTo2Stack(x10).ToString(), x + 22, y + 4, ConsoleColor.White);

           

           
            Print("Нажмите эникей для выхода", x - 1, y + 15, ConsoleColor.Gray);

            Console.ReadKey();
        }

        /// <summary>
        /// Перевод в 2ную систему через стек
        /// </summary>
        /// <param name="x10">число в 10чной системе</param>
        /// <returns>число в 2чной системе</returns>
        static string ConvertTo2Stack(int x10)
        {
            StringBuilder sb = new StringBuilder(); 
                        
            while (x10 > 1)
            {
                
                MyStack.Push((byte)(x10 % 2));
               
                x10 = x10 / 2;
            }
            
            MyStack.Push((byte)(x10));

            Console.WriteLine("Cтек: ");
            foreach (int s in MyStack)
                Console.Write("{0} ", s);
            Console.WriteLine();

            while (MyStack.Count > 0)
            {
                sb.Append(MyStack.Pop());
                Console.WriteLine("Cтек POP -> {0}, количество элементов = {1}", sb[sb.Length-1], MyStack.Count);
            }

            if (MyStack.Count == 0)
                Console.WriteLine("Стек пуст!");
            
            return sb.ToString();
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
