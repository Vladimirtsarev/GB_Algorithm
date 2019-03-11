using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  2. Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.
 * 
 * 
 */

namespace _2
{
    class Program
    {
        static int operCount = 0;

        static void Main(string[] args)
        {
            operCount = 0;
            int[] array1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] array2 = { 0, 2, 4, 6, 8, 1, 3, 5, 7 };
            int[,] matrix = new int[array1.Length, array2.Length];
            int maxS = lcs_length(ref array1, ref array2);
            
            Print(array1);
            Console.WriteLine();
            Print(array2);
            Console.WriteLine();
            Console.WriteLine("С помощью рекурсии:");
            Console.WriteLine("Максимальная длина последовательности = {0}", maxS);
            Console.WriteLine("за {0} операций\n", operCount);

            Console.WriteLine("С помощью матрицы:");
            operCount = 0;
            int ii = 0;
            int jj = 0;
            int iCheck1 = -1;
            int iCheck2 = -1;
            int flag = 0;

            while ((ii < matrix.GetLength(0)) && (jj < matrix.GetLength(1)))
            {
                operCount++;
                for (int i = ii; i < matrix.GetLength(0); i++)
                {
                    operCount++;
                                        
                    if (jj - 1 >= 0)
                    {
                        if (i - 1 >= 0)
                        {
                            if (matrix[i - 1, jj] > matrix[i, jj - 1])
                            {
                                matrix[i, jj] = matrix[i - 1, jj];
                            }
                            else
                            {
                                matrix[i, jj] = matrix[i, jj - 1];
                            }
                        }
                        else
                        {
                            if (matrix[0, jj] > matrix[i, jj - 1])
                            {
                                matrix[i, jj] = matrix[0, jj];
                            }
                            else
                            {
                                matrix[i, jj] = matrix[i, jj - 1];
                            }
                        }
                    }
                    else
                    {
                        if (i - 1 >= 0)
                        {
                            if (matrix[i - 1, jj] > matrix[i, 0])
                            {
                                matrix[i, jj] = matrix[i - 1, jj];
                            }
                            else
                            {
                                matrix[i, jj] = matrix[i, 0];
                            }
                        }
                        else
                        {
                            if (matrix[0, jj] > matrix[i, 0])
                            {
                                matrix[i, jj] = matrix[0, jj];
                            }
                            else
                            {
                                matrix[i, jj] = matrix[i, 0];
                            }
                        }
                    }


                    if ((flag == 0) && (iCheck2 != jj) && (array1[i] == array2[jj]))
                    {
                        flag = 1;
                        matrix[i, jj]++;
                        iCheck1 = i;
                        iCheck2 = jj;
                    }
                }
                for (int j = jj + 1; j < matrix.GetLength(1); j++)
                {
                    operCount++;
                    
                    if (ii - 1 >= 0)
                    {
                        if (j - 1 >= 0)
                        {
                            if (matrix[ii, j - 1] > matrix[ii - 1, j])
                            {
                                matrix[ii, j] = matrix[ii, j - 1];
                            }
                            else
                            {
                                matrix[ii, j] = matrix[ii - 1, j];
                            }
                        }
                        else
                        {
                            if (matrix[ii, 0] > matrix[ii - 1, j])
                            {
                                matrix[ii, j] = matrix[ii, 0];
                            }
                            else
                            {
                                matrix[ii, j] = matrix[ii - 1, j];
                            }
                        }

                    }
                    else
                    {
                        if (j - 1 >= 0)
                        {
                            if (matrix[ii, j - 1] > matrix[0, j])
                            {
                                matrix[ii, j] = matrix[ii, j - 1];
                            }
                            else
                            {
                                matrix[ii, j] = matrix[0, j];
                            }
                        }
                        else
                        {
                            if (matrix[ii, 0] > matrix[0, j])
                            {
                                matrix[ii, j] = matrix[ii, 0];
                            }
                            else
                            {
                                matrix[ii, j] = matrix[0, j];
                            }
                        }
                    }

                    if ((flag == 0) && (iCheck1 != ii) && (array1[ii] == array2[j]))
                    {
                        matrix[ii, j]++;
                        flag = 1;
                        iCheck1 = ii;
                        iCheck2 = j;
                    }
                }

                flag = 0;
                ii++;
                jj++;

            }
            Console.Write("".PadRight(array2.Length * 2 + 2, '-') + "|\n");
            Console.Write(" |");
            Print(array2);
            Console.Write("|");
            Console.Write("\n"+ "".PadRight(array2.Length * 2 + 2, '-')+"|");
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(array1[i]+"|");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] +" ");
                }
                Console.Write("|\n");
            }
            Console.Write("".PadRight(array2.Length * 2 + 2, '-') + "|\n");
            Console.WriteLine("Максимальная длина последовательности = {0}", matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);
            Console.WriteLine("за {0} операций", operCount);

            Console.WriteLine("\nНажмите эникей");
            Console.ReadKey();

        }

        /// <summary>
        /// Выыод массива
        /// </summary>
        /// <param name="array"></param>
        private static void Print(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// Рекурсивный метод
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        private static int lcs_length(ref int[] array1, ref int[] array2, int index1 = 0, int index2 = 0)
        {
            operCount++;
            if ((index1 >= array1.Length) || (index2 >= array2.Length))
            {
                return 0;
            }
            else if (array1[index1] == array2[index2])
            {
                return 1 + lcs_length(ref array1, ref array2, index1 + 1, index2 + 1);
            }
            else
            {
                int a = lcs_length(ref array1, ref array2, index1 + 1, index2);
                int b = lcs_length(ref array1, ref array2, index1, index2 + 1);
                if (a > b)
                {
                    return a ;
                }
                else
                {
                    return b;
                }
            }
        }

    }
}
