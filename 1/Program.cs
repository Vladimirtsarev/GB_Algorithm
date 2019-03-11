using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Царев В.А.
 * 
 * 1. *Количество маршрутов с препятствиями. 
 * Реализовать чтение массива с препятствием и нахождение количество маршрутов.
 * Например, карта:
 * 
 * 1 1 1
 * 0 1 0
 * 0 1 0
 * 
 */

namespace _1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            
            int[,] Map =  { { 1, 1, 1, 1 },
                            { 0, 1, 1, 1 },
                            { 0, 1, 0, 1 } }; //Карта

            int N = Map.GetLength(0);
            int M = Map.GetLength(1);
            int[,] A = new int[N, M];
            Console.WriteLine("Карта:");
            Print2(N, M, Map);
            
            int i, j;
            for (j = 0; j < M; j++)
                if (Map[0, j] == 1)  // если нет препятствия
                {
                    A[0, j] = 1;    // Первая строка заполнена единицами 
                } 
            for (i = 1; i < N; i++)
            {
                if (Map[i, 0] == 1) // если нет препятствия
                {
                    A[i, 0] = 1;  // Первый столбик заполнен единицами 
                }
                for (j = 1; j < M; j++)
                {
                    if (Map[i, j] >= 1)  // если нет препятствия
                    {
                        A[i, j] = A[i, j - 1] + A[i - 1, j];
                    }

                    if (Map[i, j] == 0) // если есть препятствие
                    {
                        A[i, j] = 0;
                    }
                }

            }

            Console.WriteLine("Количество маршрутов:");
            Print2(N, M, A);
            Console.WriteLine("\nНажмите эникей");
            Console.ReadKey();

        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="n">Число столбцов</param>
        /// <param name="m">Число строк</param>
        /// <param name="a">Массив</param>
        static void Print2(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j] + " ");
                Console.Write("\n");
            }
            //Console.ReadKey();
        }

    }
}
