using System;
using System.IO;

/*
 * Царёв ВА
 * 
 * 1. Реализовать сортировку подсчётом.
 *  
 */

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[ReadFile("data.txt").Length]; // определяем массив
            A = ReadFile("data.txt");                       // читаем массив из файла

            PrintMtrx(A);                                   // выводим массив на экран

            SimpleCountingSort(ref A);                      // Сортировка подсчетом

            PrintMtrx(A);                                   // выводим массив на экран

            Exit();
        }

        /// <summary>
        /// Сортировка подсчетом
        /// </summary>
        /// <param name="A">массив</param>
        static void SimpleCountingSort(ref int[] A)
        {
            Console.WriteLine("Сортировка подсчетом");
            int k = A.Length;
            int[] C = new int[k];
           
            for (int i = 0; i < k; i++)
                C[i] = 0;                    //обнуляем массив

            for (int i = 0; i < k; i++)
                C[A[i]]++;                  //подсчитываем количество вхождений каждого числа в массиве A – организуем частотный массив C

            int b = 0;
            for (int i = 0; i < k; i++)

                for (int j = 0; j < C[i]; j++)

                    A[b++] = i;              //После этого заполняем массив A нужным количеством чисел, используя частотный массив C.
        }

        /// <summary>
        /// Выводим массив на экран
        /// </summary>
        /// <param name="AdMtrx">массив</param>
        static void PrintMtrx(int[] A)
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
