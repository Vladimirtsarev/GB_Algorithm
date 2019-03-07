using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Царёв В.А.
 * 
 * 1. Попробовать оптимизировать пузырьковую сортировку. 
 * Сравнить количество операций сравнения оптимизированной
 * и не оптимизированной программы. Написать функции сортировки,
 * которые возвращают количество операций.
 */

namespace _Bubble
{
    class Program
    {
        static int MaxN = 100;
        static int swapCount = 0;
        static int[] a = new int[MaxN]; // Создаём массив максимального размера
        static int[] b = new int[MaxN]; // Создаём массив максимального размера

        static void Main(string[] args)
        {
            //int[] a = new int[MaxN]; // Создаём массив максимального размера
            
            //WriteF(GenMas(MaxN,10000)); //Создаем файл с несортированным массивом

            a = ReadF();
            //Console.WriteLine("Массив до сортировки");
            //print(a.Length, a);
            SortBubble(ref a);
            //Console.WriteLine("Массив после сортировки");
            //print(a.Length, a);

            //a = ReadF();
            //SortBubbleOptim1(ref a);

            b = ReadF();
            SortBubbleOptim3(ref b);
            
            Console.ReadKey();
            
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="a">Массив для сортировки</param>
        static void SortBubble(ref int[] a)
        {
            Console.WriteLine(("").PadRight(30, '-'));
            Console.WriteLine("Сортировка пузырьком:");
            DateTime start, finish;
            start = DateTime.Now;
            swapCount = 0;
            int i;
            int j = 0;
            for (i = 0; i < a.Length; i++)
                for (j = 0; j < a.Length - 1; j++)
                    if (a[j] > a[j + 1])
                    {
                        //swap(a[j], a[j + 1]);
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                        swapCount++;
                    }
            Console.WriteLine("Свапов: " + swapCount);
            finish = DateTime.Now;
            Console.WriteLine("Время: {0}мс\n", (finish - start).TotalMilliseconds);
            swapCount = 0;
            Console.WriteLine(("").PadRight(30, '-'));
        }

        /// <summary>
        /// Сортировка пузырьком оптимизированная
        /// </summary>
        /// <param name="a">Массив для сортировки</param>
        static void SortBubbleOptim1(ref int[] a)
        {
            Console.WriteLine(("").PadRight(30, '-'));
            Console.WriteLine("Сортировка пузырьком:");
            DateTime start, finish;
            start = DateTime.Now;
            swapCount = 0;
            int i;
            int j = 0;
            for (i = 0; i < a.Length; i++)
                for (j = 0; j < a.Length - 1; j++)
                    if (a[j] > a[j + 1])
                    {
                        //swap(a[j], a[j + 1]);
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                        swapCount++;
                    }
            Console.WriteLine("Свапов: " + swapCount);
            finish = DateTime.Now;
            Console.WriteLine("Время: {0}мс\n", (finish - start).TotalMilliseconds);
            swapCount = 0;
            Console.WriteLine(("").PadRight(30, '-'));
        }

        /// <summary>
        /// Сортировка пузырьком оптимизированная
        /// </summary>
        /// <param name="a">Массив для сортировки</param>
        static void SortBubbleOptim2(ref int[] a)
        {
            Console.WriteLine(("").PadRight(30, '-'));
            Console.WriteLine("Сортировка пузырьком опт:");
            DateTime start, finish;
            start = DateTime.Now;
            //countOp = 0;
            swapCount = 0;
            int flagSwap = 0;
            int indexJamp = 0;
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
               //countOp++;
                for (int j = 1; j < a.Length - count; j++)
                {
                   // countOp++;
                    if (a[j - 1] > a[j])
                    {                        
                        int t = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = t;

                        swapCount++;

                        if (flagSwap == 0)
                        {
                            indexJamp = j + 1;
                        }
                        flagSwap = 1;
                    }
                }
                count++;
                i = indexJamp - 1;
                if (flagSwap == 0)
                {
                    break;
                }
                else flagSwap = 0;
            }
            Console.WriteLine("Свапов: " + swapCount);
            finish = DateTime.Now;
            Console.WriteLine("Время: {0}мс\n", (finish - start).TotalMilliseconds);
            swapCount = 0;
            Console.WriteLine(("").PadRight(30, '-'));
        }

        static void SortBubbleOptim3(ref int[] a)
        {
            int currentPosition;
            int maxPosition;
            int temp;
            swapCount = 0;
            int compareCount = 0;
            Console.WriteLine(("").PadRight(30, '-'));
            Console.WriteLine("Сортировка пузырьком опт:");
            DateTime start, finish;
            start = DateTime.Now;
            bool changed; // проверка на перестановки

            for (maxPosition = a.Length - 1; maxPosition >= 0; maxPosition--)
            {
                changed = false;
                for (currentPosition = 0; currentPosition < maxPosition; currentPosition++)
                {
                    compareCount++;
                    if (a[currentPosition] > a[currentPosition + 1])
                    {
                        temp = a[currentPosition];
                        a[currentPosition] = a[currentPosition + 1];
                        a[currentPosition + 1] = temp;
                        swapCount++;
                        changed = true; // флаг перестановки
                    }
                }
                if (!changed)
                { // если не было перестановок - выходим сразу
                                   
                    Console.WriteLine("Свапов: " + swapCount);
                    finish = DateTime.Now;
                    Console.WriteLine("Время: {0}мс\n", (finish - start).TotalMilliseconds);
                    swapCount = 0;
                    Console.WriteLine(("").PadRight(30, '-'));
                    return;
                }
            }
            
            return;
        }

        static int[] ReadF()
        {
            string[] arStr = File.ReadAllLines("1.txt");
            int[] a = new int[arStr.Length];
            int i = 0;
            foreach (string str in arStr)
            {
                a[i] = Convert.ToInt32(str);
                i++;
            }
            return a;
            
        }

        // Распечатываем массив
        static void print(int N, int[] a)
        {
            int i;
            for (i = 0; i < N; i++)
                Console.Write("{0} ", a[i]);
            Console.Write("\n");
        }

        static void WriteF(string str)
        {
            string[] arStr = File.ReadAllLines("1.txt");
            File.WriteAllText("1.txt",str);
            
        }

        static string GenMas(int N, int Length)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random(N);
            for (int i = 0; i < Length; i++)
            {
                sb.Append(rand.Next(N * 10 + 1)+"\n");
            }
            return sb.ToString();
        }
    }


}



