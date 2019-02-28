using System;

/*
 * 12. Написать функцию нахождения максимального из трех чисел.
 */


namespace MAX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Поиск максимального из 3х";
            int i = 0;
            int[] x = new int[3];
            Console.Clear();
            do
            {
                i++;
                Console.WriteLine("Введите число {0} для поиска максимального", i);
                x[i - 1] = int.Parse(Console.ReadLine());

            } while (i < 3);
            Console.WriteLine("Максимальное число: " + GetMax(x[0], x[1], x[2]));
            Console.WriteLine("Эникей для выхода");

            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает наибольшее из 3х чисел
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <returns>float</returns>
        private static float GetMax(float x1, float x2, float x3)
        {
            float x = x1;
            x = x > x2 ? x : x2;
            x = x > x3 ? x : x3;
            return x;
        }
    }
}
