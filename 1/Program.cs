using System;

/*
 * Царёв ВА
 * 
 * 1.	Реализовать простейшую хэш-функцию. На вход функции подается строка, 
 * на выходе получается сумма кодов символов.
 *
 */

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
                 
            Console.WriteLine("Сумма: {0}", Hashsum(Console.ReadLine()));

            Console.WriteLine("\nНажмите эникей");
            Console.ReadKey();
        }

        /// <summary>
        /// Принимает строку и отдает сумму кодов символов
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>сумма</returns>
        static int Hashsum(string str)
        {
            int sum = 0;
            int[] chMas = new int[str.Length];
            int i = 0;
            foreach (char c in str)
                chMas[i++] = (int)c;

            foreach (int item in chMas)
                sum += item;

            return sum;
        }

        /// <summary>
        /// Принимает строку и отдает строку
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>строка</returns>
        static string Hashsum2(string str)
        {
            char[] chMas = new char[str.Length];
            int i = 0;
            foreach (char c in str)
                chMas[i++] = c;

            
            return "";
        }
    }
}
