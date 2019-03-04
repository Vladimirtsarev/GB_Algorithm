using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 3. Исполнитель Калькулятор преобразует целое число, записанное на экране.
 * У исполнителя две команды, каждой команде присвоен номер:
 * Прибавь 1 2.Умножь на 2 Первая команда увеличивает число на экране на 1,
 * вторая увеличивает это число в 2 раза. Сколько существует программ, 
 * которые число 3 преобразуют в число 20? 
 * а) с использованием массива; 
 * б) с использованием рекурсии.
 */

namespace _3_Calc
{
    public class Doubler
    {
        int current = 3;
        int finish = 20;

        public Doubler(int f)
        {
            Random rnd = new Random();
            finish = rnd.Next(0, f);
            finish = 20;
        }

        public void Plus1()
        {
            current++;
        }

        public void Multiply2()
        {
            current = current * 2;
        }

        public int Current
        {
            get
            {
                return current;
            }
        }
        public int Finish
        {
            get
            {
                return finish;
            }
        }
    }

    class Program
    {
        static Doubler D = new Doubler(56);
        static int step = 0;

        static void Main(string[] args)
        {
            Console.Title = "Калькулятор";
            bool flag = true;
            while (flag)
            {
                switch (Menu())
                {
                    case "1": D.Plus1(); break;
                    case "2": D.Multiply2(); break;
                    
                    case "0": flag = false; break;
                    default:
                        Console.WriteLine("Неверный ввод, для повтора нажмите эникей");
                        Console.ReadKey();
                        break;
                }
                if (D.Current == D.Finish)
                {
                    flag = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0} ходов", step);
                    Console.ReadKey();
                }
                if (D.Current > D.Finish)
                {
                    flag = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nПеребор");
                    Console.ReadKey();
                }

            }
        }

        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        /// <returns></returns>
        private static string Menu()
        {
            Console.Clear();
            Console.WriteLine("Число, которое нужно достичь: {0}", D.Finish);
            Console.WriteLine("Текущее число равно {0}", D.Current);
            Console.WriteLine("Количесво ходов: " + step);
            Console.WriteLine("1. Прибавить 1");
            Console.WriteLine("2. Удвоить");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");
            step++;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1: return "1";
                case ConsoleKey.D2: return "2";
                case ConsoleKey.D3: return "3";
                case ConsoleKey.D0: return "0";
                default: return Console.ReadLine();
            }

        }
    }

    
}
