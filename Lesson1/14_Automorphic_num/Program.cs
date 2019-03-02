using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automorphic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Автоморфные числа";
            int x = 0;
            Console.Clear();
            Console.Write("Введите число:");
            x= int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Автоморфные числа до {0}:", x);
            int rx=razr(x);
            for (int i = 0; i <= x; i++)
            {
                int ri = razr(i);
                int ri2 = razr(i*i);


                if (i*i==i)
                Console.WriteLine(i);
            }
            Console.WriteLine("\nЭникей для выхода");
            Console.ReadKey();


        }

        /// <summary>
        /// Определяет разрядность числа
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static int razr(int x)
        {
            int i=0;
            if (x < 0) x = -x;
            while (x > 0)
            {
                x = x / 10;
                i ++;
            }
            return i;
        }
    }
}
