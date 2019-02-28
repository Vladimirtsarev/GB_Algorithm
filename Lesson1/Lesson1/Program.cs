/*
 * Царёв В.А.
 * 
 * 1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); где m-масса тела в килограммах, h - рост в метрах.
 * 
 * 2. Найти максимальное из четырех чисел. Массивы не использовать.
 * 
 * 3. Написать программу обмена значениями двух целочисленных переменных:
 * a. с использованием третьей переменной;
 * b. *без использования третьей переменной.
 * 
 * 4. Написать программу нахождения корней заданного квадратного уравнения.
 * 
 * 5. С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.
 * 
 * 6. Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом «год», «года» или «лет».
 * 
 * 7. С клавиатуры вводятся числовые координаты двух полей шахматной доски (x1,y1,x2,y2). Требуется определить,
 * относятся ли к поля к одному цвету или нет.
 * 
 * 8. Ввести a и b и вывести квадраты и кубы чисел от a до b.
 * 
 * 9. Даны целые положительные числа N и K. Используя только операции сложения и вычитания, 
 * найти частное от деления нацело N на K, а также остаток от этого деления.
 * 
 * 10. Дано целое число N (> 0). С помощью операций деления нацело и взятия остатка от деления определить,
 * имеются ли в записи числа N нечетные цифры. Если имеются, то вывести True, если нет — вывести False.
 * 
 * 11. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать среднее арифметическое всех
 * положительных четных чисел, оканчивающихся на 8.
 * 
 * 12. Написать функцию нахождения максимального из трех чисел.
 * 
 * 13. * Написать функцию, генерирующую случайное число от 1 до 100.
 * с использованием стандартной функции rand()
 * без использования стандартной функции rand()
 * 
 * 14. * Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам
 * своего квадрата. Например, 25^2 = 625. Напишите программу, которая вводит натуральное число
 * N и выводит на экран все автоморфные числа, не превосходящие N.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 0;
            int weight = 0;
            int x = 45;
            int y = 4;

            Console.Title = "Индекс массы тела";
            PrintW(x, y);
            //Console.ReadKey();
            Print("|    Ввод данных     |", x, y + 1, ConsoleColor.Yellow);
            Print("Рост:", x + 4, y + 3, ConsoleColor.White);
            height = int.Parse(Read(x + 10, y + 3));
            Print("Рост:", x + 4, y + 3, ConsoleColor.Green);
            Print("Вес:", x + 5, y + 4, ConsoleColor.White);
            weight = int.Parse(Read(x + 10, y + 4));
            Print("Вес:", x + 5, y + 4, ConsoleColor.Green);
            Print("ИМТ: " + IMT(height, weight), x + 5, y + 6, ConsoleColor.Red);
            Print("Нажмите эникей для выхода", x - 1, y + 15, ConsoleColor.Gray);
            Console.ReadKey();
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
        /// Возвращает ИМТ
        /// </summary>
        /// <param name="h">Рост в см</param>
        /// <param name="w">Вес в кг</param>
        /// <returns></returns>
        static int IMT(int h, int w)
        {
            float f = 0.0f;
            f = (float)h / 100;
            return (int)(w / (f * f));
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

        /// <summary>
        /// Вывод меню
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void PrintW(int x, int y)
        {
            Print("----------------------", x, y++, ConsoleColor.Yellow);
            Print("|Ввод данных: эникей |", x, y++, ConsoleColor.Yellow);
            Print("----------------------", x, y++, ConsoleColor.Yellow);
            Print("|   Рост:            |", x, y++, ConsoleColor.Yellow);
            Print("|    Вес:            |", x, y++, ConsoleColor.Yellow);
            Print("----------------------", x, y++, ConsoleColor.Yellow);
        }
    }

}
    
