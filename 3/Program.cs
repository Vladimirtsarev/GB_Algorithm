using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Царёв ВА
 *  
 * 3. *Реализовать сортировку слиянием.
 * 
 */

namespace _3
{
    class Program
    {
        public static int count = 0;
        static double number=0;

        static void Main(string[] args)
        {
            int[] A = new int[ReadFile("data.txt").Length]; // определяем массив
            A = ReadFile("data.txt");                       // читаем массив из файла

            PrintArray(A);                                   // выводим массив на экран

            MergeSort(ref A);                               // быстрая сортировка

            PrintArray(A);                                   // выводим массив на экран

            Console.WriteLine("{0} вызовов MergeSortR", count);

            Exit();
        }

        static void MergeSort(ref int[] A)
        {
            Console.WriteLine("Сортировка слиянием");
            MergeSortR(A, 0, A.Length - 1);
        }

        /// <summary>
        /// Сортировки слиянием рекурсия
        /// </summary>
        /// <param name="m"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        static void MergeSortR(int[] m, int l, int r)
        {
            count++;
            PrintArray(m);
            Console.WriteLine("({0}-{1})",l,r);
            int t;
            if (l < r) 
                if ((r - l) == 1)// Обрабатываемый фрагмент массива состоит более чем из одного элемента
                {
                    if (m[r] < m[l]) // Обрабатываемый фрагмент массива состоит из двух элементов
                    {
                        t = m[l];
                        m[l] = m[r];
                        m[r] = t;
                    }
                }
                else
                {
                    // Разбиваем заданный фрагмент на два массива
                    // Рекурсивно вызываем функции MergeSort
                    Console.Write("Левый ");
                    MergeSortR(m, l, l + (r - l) / 2);
                    Console.Write("Правый ");
                    MergeSortR(m , l + (r - l) / 2 + 1, r);
                    Merge(m, l, r);  // Сливаем массивы
                }
            
        }

        /// <summary>
        /// Слияние массивов
        /// </summary>
        /// <param name="m"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>        
        static void Merge(int[] m, int left, int right)
        {
            //int medium = (r - l) / 2;
            //int j = l;
            //int k = medium + 1;
            //int count = r - l + 1;

            //if (count <= 1) return;

            //int[] Tmpm = new int[count];

            //for (int i = 0; i < count; ++i)
            //{
            //    if (j <= medium && k <= r)
            //    {
            //        if (m[j] < m[k])
            //            Tmpm[i] = m[j++];
            //        else
            //            Tmpm[i] = m[k++];
            //    }
            //    else
            //    {
            //        if (j <= medium)
            //            Tmpm[i] = m[j++];
            //        else
            //            Tmpm[i] = m[k++];
            //    }
            //}

            //j = 0;
            //for (int i = l; i <= r; ++i)
            //{
            //    m[i] = Tmpm[j++];
            //}
            ////delete[] Tmpm;


            //буфер для отсортированного массива
            int[] buff = new int[left + right];
            //счетчики длины трех массивов
            int i = 0;  //соединенный массив
            int l = 0;  //левый массив
            int r = 0;  //правый массив
                        //сортировка сравнением элементов
            for (i=0; i < buff.Length; i++)
            {
                //если правая часть уже использована, дальнейшее движение происходит только в левой
                //проверка на выход правого массива за пределы
                if (r >= right)
                {
                    buff[i] = m[l];
                    l++;
                }
                //проверка на выход за пределы левого массива
                //и сравнение текущих значений обоих массивов
                else if (l < left && m[l] < m[r])
                {
                    buff[i] = m[l];
                    l++;
                }
                //если текущее значение правой части больше
                else
                {
                    buff[i] = m[r];
                    r++;
                    //подсчет количества инверсий
                    if (l < left)
                        number += left - l;
                }
                //возврат отсортированного массива
                

            }
            //return buff;
            m = buff;
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
