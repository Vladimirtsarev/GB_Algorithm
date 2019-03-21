using System;
using System.Collections.Generic;
using System.IO;

/*
 * Царёв ВА
 *  
 * 3. Написать функцию обхода графа в ширину.
 *  
 */

namespace _3
{
    class Program
    {

        /// <summary>
        /// Класс Вершина
        /// </summary>
        public class Vertex
        {
            public string name;             // имя вершины
            public bool visited;         // была ли посещена

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="n"></param>
            public Vertex(string n)
            {
                name = n;
                visited = false;
            }
        }

        /// <summary>
        /// Класс Граф
        /// </summary>
        public class Graph
        {
            private int maxVertexCount = 20;
            public int vertexCount = 0;
            private Vertex[] vertexList;                // Список вершин
            public List<int>[] edges;                   // массив со списками соседних вершин для каждого узла
            private int[,] adMtrx;                      // Матрица смежности
            private int vertexCurNumber;                // номер текущей вершины
            private MyStack myStack;
            private MyDeque myDeque;

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="VertexCount">количество узлов</param>
            public Graph()
            {
                vertexList = new Vertex[maxVertexCount];
                adMtrx = new int[maxVertexCount, maxVertexCount];
                vertexCurNumber = 0;
                for (int j = 0; j < maxVertexCount; j++)
                {
                    for (int k = 0; k < maxVertexCount; k++) // Обнуление матрицы смежности
                    {
                        adMtrx[j, k] = 0;
                    }
                }
                myStack = new MyStack();

            }

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="VertexCount">количество узлов</param>
            public Graph(int VertexCount)
            {
                vertexCount = VertexCount;
                maxVertexCount = VertexCount;
                vertexList = new Vertex[maxVertexCount];
                adMtrx = new int[maxVertexCount, maxVertexCount];
                vertexCurNumber = 0;
                for (int j = 0; j < maxVertexCount; j++)
                {
                    for (int k = 0; k < maxVertexCount; k++) // Обнуление матрицы смежности
                    {
                        adMtrx[j, k] = 0;
                    }
                }
                myStack = new MyStack();

            }

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="adjMtrx">матрица смежности</param>
            public Graph(int[,] adjMtrx)
            {

                maxVertexCount = adjMtrx.GetLength(0);
                vertexCount = maxVertexCount;
                edges = new List<int>[vertexCount];
                vertexList = new Vertex[maxVertexCount];

                for (int i = 0; i < vertexCount; i++)
                {
                    edges[i] = new List<int>();
                }

                adMtrx = adjMtrx;
                vertexCurNumber = 0;

                myStack = new MyStack();
                myDeque = new MyDeque();
                //int i = 0;
                for (int i = 0; i < maxVertexCount; i++)
                {
                    for (int j = 0; j < vertexCount; j++)
                    {
                        if (adMtrx[i, j] > 0)    // если в матрице смежности значение есть
                        {
                            edges[i].Add(j);     // то добавляем связь
                        }
                    }

                    AddVertex(Convert.ToChar(i + 65).ToString());        // Добавляем названия вершин
                }



            }

            /// <summary>
            /// Добавляем вершину
            /// </summary>
            /// <param name="lab">Имя вершины</param>
            public void AddVertex(string lab)
            {
                vertexList[vertexCurNumber++] = new Vertex(lab);
            }

            /// <summary>
            /// Добавляем ребро
            /// </summary>
            /// <param name="start">начальная вершина</param>
            /// <param name="end">конечная вершина</param>
            public void AddEdge(int start, int end, int weight)
            {
                adMtrx[start, end] = weight;
                adMtrx[end, start] = weight;
            }

            public void DisplayVertex(int v)
            {
                Console.Write("{0} ", vertexList[v].name);
            }

            /// <summary>
            /// Обход в ширину
            /// </summary>
            public void BFS(int vertN)
            {  
                vertexList[vertN].visited = true;
                myDeque.PushFront(vertN);
                DisplayVertex(vertN);
                while (!myDeque.Empty)
                {
                    int v = GetUnvisitedVertex(myDeque.Front);   // получить непосещенную вершину, смежную с вершиной дека
                    if (v == -1)                                 // если таких нет
                    {
                        myDeque.PopFront();                      // убираем из очереди
                    }
                    else                                         // если такая есть
                    {
                        vertexList[v].visited = true;            // помечаем
                        DisplayVertex(v);                        // выводим на экран
                        myDeque.PushBack(v);                     // добавляем ее в низ дека
                    }
                    //for (int i = 0; i < vertexCount; i++)
                    //{
                        
                    //}
                }
                for (int j = 0; j < vertexCurNumber; j++)   // сброс меток посещения
                {
                    vertexList[j].visited = false;
                }
            }            

            /// <summary>
            /// Получаем непосещенную вершину, смежную с вершиной дека V
            /// </summary>
            /// <param name="v">номер вершины</param>
            /// <returns>номер вершины</returns>
            public int GetUnvisitedVertex(int v)
            {
                for (int j = 0; j < vertexCurNumber; j++)
                {
                    if ((adMtrx[v, j] >= 1) && (vertexList[j].visited == false))
                    {
                        return j;
                    }
                }
                return -1;
            }

            public void DisplayAdjMatrix()
            {
                if (adMtrx != null)
                {
                    Console.WriteLine("Матрица смежности:\n");
                    Console.Write("\t  ");
                    for (int i = 0; i < vertexCount; i++)
                    {
                        Console.Write("{0} ", Convert.ToChar(i + 65).ToString()); // Добавляем названия вершин
                    }
                    Console.Write("\n");
                    for (int i = 0; i < maxVertexCount; i++)
                    {
                        Console.Write("\t");
                        Console.Write("{0} ", Convert.ToChar(i + 65).ToString()); // Добавляем названия вершин
                        for (int j = 0; j < maxVertexCount; j++)
                        {
                            
                            if (i == j)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            Console.Write("{0} ", adMtrx[i, j]);
                        }
                        Console.Write("\n");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n");
                }
            }
        }

        /// <summary>
        /// Класс Стек
        /// </summary>
        public class MyStack
        {
            private int[] st;
            private int top;

            /// <summary>
            /// Конструктор
            /// </summary>
            public MyStack()
            {
                st = new int[20];
                top = -1;
            }

            /// <summary>
            /// Добавляем в стек
            /// </summary>
            /// <param name="j"></param>
            public void push(int j)
            {
                st[++top] = j;
            }

            /// <summary>
            /// Удаляем из стека
            /// </summary>
            /// <returns></returns>
            public int pop()
            {
                return st[top--];
            }

            /// <summary>
            /// Вернуть верхий элемент стека
            /// </summary>
            /// <returns></returns>
            public int peek()
            {
                return st[top];
            }

            /// <summary>
            /// Свойство Пустой ли стек
            /// </summary>
            public bool Empty
            {
                get
                {
                    return (top == -1);
                }
            }
        }

        /// <summary>
        /// Класс Дек
        /// </summary>
        public class MyDeque
        {
            int[] array;
            /// <summary>
            /// Конструктор
            /// </summary>
            public MyDeque()
            {
                array = new int[0];
            }
            public int Count
            {
                get
                {
                    return array.Length;
                }
            }
            public bool Empty
            {
                get
                {
                    return array.Length == 0;
                }
            }

            /// <summary>
            /// Добавляем в конец
            /// </summary>
            /// <param name="item"></param>
            public void PushBack(int item)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = item;
            }

            /// <summary>
            /// Добавляем в начало
            /// </summary>
            /// <param name="item"></param>
            public void PushFront(int item)
            {
                Array.Resize(ref array, array.Length + 1);
                for (int i = array.Length - 1; i > 0; i--)
                    array[i] = array[i - 1];
                array[0] = item;
            }

            /// <summary>
            /// Забираем с конца
            /// </summary>
            /// <returns></returns>
            public int PopBack()
            {
                int item = array[array.Length - 1];
                Array.Resize(ref array, array.Length - 1);
                return item;
            }

            /// <summary>
            /// Забираем с начала
            /// </summary>
            /// <returns></returns>
            public int PopFront()
            {
                int item = array[0];
                for (int i = 0; i < array.Length - 1; i++)
                    array[i] = array[i + 1];
                Array.Resize(ref array, array.Length - 1);
                return item;
            }

            /// <summary>
            /// Возвращаем первый элемент
            /// </summary>
            public int Front
            {
                get
                {
                    return array[0];
                }
            }

            /// <summary>
            /// Возвращаем последний элемент
            /// </summary>
            public int Back
            {
                get
                {
                    return array[array.Length - 1];
                }
            }
        }

        static void Main(string[] args)
        {
            Graph grph = new Graph(ReadFile("data.txt"));        // Создаем граф из матрицы в файле

            grph.DisplayAdjMatrix();                             // выводим матрицу смежности

            grph.BFS(VertexSelect(grph.vertexCount));            // Обход в ширину

            Exit();
        }

        /// <summary>
        /// Читаем матрицу из файла и возращаем массив
        /// </summary>
        /// <param name="fname">путь к файлу</param>
        /// <returns>матрица смежности</returns>
        static int[,] ReadFile(string fname)
        {
            if (!File.Exists(fname))
            {
                Console.WriteLine("Ошибка! Файла {0} не существует", fname);
                Exit();
                Environment.Exit(0);
            }
            string[] strRows = File.ReadAllLines(fname);
            int[,] AdjacencyMatrix = new int[strRows[0].Replace(" ", "").Length, strRows.Length];

            for (int i = 0; i < strRows.Length; i++)
            {
                string[] str = strRows[i].Split(' ');
                int j = 0;
                foreach (string s in str)
                {
                    AdjacencyMatrix[i, j++] = int.Parse(s);
                }

            }
            return AdjacencyMatrix;
        }

        /// <summary>
        /// Ввод начальной вершины
        /// </summary>
        /// <returns></returns>
        static int VertexSelect(int vertexCount)
        {
            int i = 0;
            for (i = 0; i < vertexCount; i++)
            {

                Console.WriteLine("{0}. {1}", i + 1, Convert.ToChar(i + 65).ToString()); // Добавляем названия вершин
            }

            Console.WriteLine("{0}. Другая", ++i);
            Console.WriteLine("0. Выход");
            Console.Write("Введите начальную вершину: ");

            int v = 0;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nВыбрана вершина А");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("\nВыбрана вершина B");
                    v = 1;
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("\nВыбрана вершина C");
                    v = 2;
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("\nВыбрана вершина D");
                    v = 3;
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("\nВыбрана вершина E");
                    v = 4;
                    break;
                case ConsoleKey.D6:
                    Console.Write("\nВведите порядковый номер начальной вершины от 0: ");
                    v = int.Parse(Console.ReadLine());
                    break;
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nНеверный ввод. Выбрана вершина А");
                    break;

            }



            Console.Write("\nЗаходы: ");
            return v;
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
