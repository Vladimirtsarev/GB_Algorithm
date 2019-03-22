using System;
using System.IO;

/*
 * Царёв ВА
 *  
 * 2. Реализовать быструю сортировку.
 * 
 */

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[ReadFile("data.txt").Length]; // определяем массив
            A = ReadFile("data.txt");                       // читаем массив из файла

            PrintArray(A);                                   // выводим массив на экран

            QuickSort(ref A);                               // быстрая сортировка

            PrintArray(A);                                   // выводим массив на экран

            Exit();
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="A">массив</param>
        static void QuickSort(ref int[] A)
        {
            Console.WriteLine("Быстрая сортировка");
            int k = A.Length;
            QuickSortR(A, 0, k-1);
        }

        /// <summary>
        /// Быстрая сортировка рекурсивный 
        /// </summary>
        /// <param name="A">массив</param>
        /// <param name="first">индекс первого</param>
        /// <param name="last">индекс последнего</param>
        static void QuickSortR(int[] A, int first, int last)
        {
            int i = first, j = last, x = A[(first + last) / 2];

            do
            {
                while (A[i] < x)
                    i++;
                while (A[j] > x)
                    j--;

                if (i <= j)
                {
                    if (A[i] > A[j])
                        Swap(ref A[i], ref A[j]);
                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSortR(A, i, last);
            if (first < j)
                QuickSortR(A, first, j);
        }

        static void Swap(ref int v1, ref int v2)
        {
            int tmp = v1;
            v1 = v2;
            v2 = tmp;
        }

        /// <summary>
        /// Выводим массив на экран
        /// </summary>
        /// <param name="AdMtrx">массив</param>
        static void PrintArray(int[] A)
        {
            Console.WriteLine("Массив:");
            Console.Write("\t");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0} ", A[i]);
            }
            Console.Write("\n");
        }

        /// <summary>
        /// Читаем массив из файла и возращает его
        /// </summary>
        /// <param name="fname">путь к файлу</param>
        /// <returns>матрица смежности</returns>
        static int[] ReadFile(string fname)
        {
            if (!File.Exists(fname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Файла {0} не существует", fname);
                Console.ForegroundColor = ConsoleColor.Gray;
                Exit();
                Environment.Exit(0);
            }
            string str = File.ReadAllText(fname);

            string[] str2 = str.Split(' ');
            int[] mas = new int[str2.Length];

            int j = 0;
            foreach (string s in str2)
            {
                mas[j++] = int.Parse(s);
            }

            return mas;
        }

        /// <summary>
        /// Выход
        /// </summary>
        static void Exit()
        {
            Console.WriteLine("\n\nНажмите эникей");
            Console.ReadKey();
        }
    }
}
