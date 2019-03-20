using System;
using System.IO;

/*
 * Царёв ВА
 * 
 * 1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран
 *
 */

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMtrx(Diagonal(ReadFile("data.txt")));

            Console.WriteLine("Нажмите эникей");
            Console.ReadKey();
        }

        /// <summary>
        /// Читаем матрицу из файла и возращает массив
        /// </summary>
        /// <param name="fname">путь к файлу</param>
        /// <returns>матрица смежности</returns>
        static int[,] ReadFile(string fname)
        {
            string[] strRows = File.ReadAllLines(fname);
            int[,] AdjacencyMatrix = new int[strRows[0].Replace(" ","").Length, strRows.Length];

            for (int i =0; i< strRows.Length;i++)
            {
                string [] str = strRows[i].Split(' ');
                int j = 0;
                foreach (string s in str)
                {
                    AdjacencyMatrix[i, j++] = int.Parse(s);                    
                }
                 
            }
            return AdjacencyMatrix;
        }

        /// <summary>
        /// Выводим матрицу на экран
        /// </summary>
        /// <param name="AdMtrx">массив</param>
        static void PrintMtrx(int[,] AdMtrx)
        {
            Console.WriteLine("Матрица смежности:\n"); 
            for (int i = 0; i < AdMtrx.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < AdMtrx.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("{0} ", AdMtrx[i,j]);
                }
                Console.Write("\n");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n");
        }

        /// <summary>
        /// Увеличение весов диагонали до суммы всех элементов +1
        /// </summary>
        /// <param name="admtrx">массив</param>
        /// <returns>массив</returns>
        static int[,] Diagonal(int[,] admtrx)
        {
            int sum = 0;
            for (int i = 0; i < admtrx.GetLength(0); i++)
            {
                for (int j = 0; j < admtrx.GetLength(1); j++)
                {
                    sum += admtrx[i, j];
                }
            }

            for (int i = 0; i < admtrx.GetLength(0); i++)
            {
                for (int j = 0; j < admtrx.GetLength(1); j++)
                {
                    if (i == j)
                        admtrx[i, j] = sum + 1;
                }
            }
            return admtrx;
        }
    }
}
