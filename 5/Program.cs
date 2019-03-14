using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 5. **Реализовать алгоритм перевода из инфиксной записи арифметического
 * выражения в постфиксную.
 */

namespace _5
{
    class Program
    {
        static int Size = 20;                   // размер последовательности

        static char[] OperMas = new char[Size]; // массив операндов
        static int N = -1;               // количество элементов
                

        static void Main(string[] args)
        {
            char[] Infix = new char[Size];
            char[] Postfix = new char[Size];
            char Char;
            int i = 0, k = 0;
            Console.Write("Введите последовательность ");
            string str = Console.ReadLine();

            foreach (char c in str)
            {
                
                Infix[i] = c;
                i++;
            }
            i = 0;
            Push('┴');

            while ((Char = Infix[i++]) != '\0')
            {
                if (Char == '(')
                    Push(Char);                      // если ( - добавляем в стек операндов
                else if (char.IsDigit(Char))
                    Postfix[k++] = Char;             // если цифра - добавляем в постфикс
                else if (Char == ')')
                {
                    while (OperMas[N] != '(') // пока не (
                        Postfix[k++] = Pop();        // добавляем в постфикс из стека операндов
                    Pop();                           // забираем из стека операндов 
                }
                else
                {
                    while (OperOrder(OperMas[N]) >= OperOrder(Char)) // пока порядок выше
                        Postfix[k++] = Pop();        // добавляем в постфикс из стека операндов
                    Push(Char);                      // добавляем в стек операндов
                }
            }
            while (OperMas[N] != '┴')
                Postfix[k++] = Pop();

            Postfix[k] = '\0';

            Console.Write("\nИнфиксная запись последовательности: '");
            foreach (char c in Infix)
            {
                if (c!= '\0')
                    Console.Write(c);
            }
            Console.Write("'\nПостфиксная запись последовательности: '");
            foreach (char c in Postfix)
            {
                if (c != '\0')
                    Console.Write(c);
            }
            Console.Write("'\n");
            Console.WriteLine("Нажмите эникей");
            Console.ReadKey();
        }

        /// <summary>
        /// добавляет символ в стек
        /// </summary>
        /// <param name="ch">символ</param>
        static void Push(char ch)
        {
            OperMas[++N] = ch;
        }

        /// <summary>
        /// Забирает символ из стека
        /// </summary>
        /// <returns></returns>
        static char Pop()
        {
            return (OperMas[N--]);
        }

        /// <summary>
        /// Порядок операций
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        static int OperOrder(char ch)
        {
            switch (ch)
            {
               // case '#': return 0;
                case '┴': return 0;
                case '(': return 1;
                case '+': return 2;
                case '-': return 2;
                case '*': return 3;
                case '/': return 3;
                default: return -1;
            }
        }
    }
}
