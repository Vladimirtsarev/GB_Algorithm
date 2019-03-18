using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 2.	Переписать программу, реализующее двоичное дерево поиска:
 * a.	Добавить в него обход дерева различными способами.
 * b.	Реализовать поиск в нём.
 * c.	*Добавить в программу обработку командной строки с помощью которой 
 * можно указывать, из какого файла считывать данные, каким образом обходить дерево.
 * 
 */

namespace _2
{
    /// <summary>
    /// Класс Узел
    /// </summary>
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int data, Node par)
        {
            this.data = data;
            this.parent = par;
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node Tree = new Node(0,null);
            string[] strMas=File.ReadAllLines("data.txt")[0].Split(' ');
            int[] intMas = new int[strMas.Length-1];
            int i = -1;
            int count=0;
            foreach (string s in strMas)
            {
                if (i < 0) { count = int.Parse(s); i++; }    // Считываем количество записей
                else intMas[i++] = int.Parse(s);             // Считываем массив
            }
            
            foreach (int item in intMas)
            {
                insert(Tree, item);                          //Вставляем узел
                Console.Write(item + " ");                   //Выводим его
            }
            Console.Write("\n");

            printTree(Tree);                                 //Вывод дерева 1
            //printTree2(Tree);                                //Вывод дерева 2

            Console.Write("\nPreOrderTravers:");
            preOrderTravers(Tree);

            //PassMethod(Tree);                                //Метод обхода
            AllPassMethod(Tree);                             //Все методы обхода сразу


            Search(Tree);                                    //Поиск

            Console.WriteLine("\n\nНажмите эникей");
            Console.ReadKey();
        }

        /// <summary>
        /// Выбор метода обхода
        /// </summary>
        static void PassMethod(Node Tree)
        {
            Console.WriteLine("\nВыберите метод обхода:");
            Console.WriteLine("1. Обход 'корень - левый - правый' RoLR:");
            Console.WriteLine("2. Обход 'левый - корень - правый' LRoR:");
            Console.WriteLine("3. Обход 'левый - правый - корень' LRRo:");
            Console.Write("Введите число: ");
            int input=int.Parse(Console.ReadLine());
            switch (input)
            {                
                case 1:
                    RootLeftRight(Tree);                    
                    break;
                case 2:
                    LeftRootRight(Tree);
                    break;
                case 3:
                    LeftRightRoot(Tree);
                    break;
                default:
                    Console.Write("Неверный ввод");
                    break;
            }
        }

        /// <summary>
        /// Все методы обхода сразу
        /// </summary>
        static void AllPassMethod(Node Tree)
        {
            Console.WriteLine("\nВсе методы обхода:");
            Console.Write("Обход 'корень - левый - правый' RoLR: ");
            RootLeftRight(Tree);
            Console.Write("\n");
            Console.Write("Обход 'левый - корень - правый' LRoR: ");
            LeftRootRight(Tree);
            Console.Write("\n");
            Console.Write("Обход 'левый - правый - корень' LRRo: ");
            LeftRightRoot(Tree);
            Console.Write("\n");
        }

        /// <summary>
        /// Обход 'корень - левый - правый'
        /// </summary>
        /// <param name="root"></param>
        static void RootLeftRight(Node root)
        {
            if (root != null)
            {
                Console.Write(root.data);
                RootLeftRight(root.left);
                RootLeftRight(root.right);
            }
        }

        /// <summary>
        /// Обход 'левый - корень - правый'
        /// </summary>
        /// <param name="root"></param>
        static void LeftRootRight(Node root)
        {
            if (root != null)
            {
                LeftRootRight(root.left);
                Console.Write(root.data);
                LeftRootRight(root.right);
            }
        }

        /// <summary>
        /// Обход 'левый - правый - корень' LRRo
        /// </summary>
        /// <param name="root"></param>
        static void LeftRightRoot(Node root)
        {
            if (root != null)
            {
                LeftRightRoot(root.left);
                LeftRightRoot(root.right);
                Console.Write(root.data);
            }
        }

        /// <summary>
        /// Поиск по дереву
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static Node GetNode(Node root, int value)
        {
            while (root!=null)
            {
                if (root.data > value)
                {
                    root = root.left;
                    continue;
                }
                else if (root.data < value)
                {
                    root = root.right;
                    continue;
                }
                else
                {
                    return root;
                }
            }
            return null;
        }

        /// <summary>
        /// Выбор что искать
        /// </summary>
        /// <param name="Tree"></param>
        static void Search(Node Tree)
        {
            Console.WriteLine("\nВведите число для поиска: ");
            int input=int.Parse(Console.ReadLine());
            Node temp_root = GetNode(Tree, input);
            if (temp_root == null) Console.WriteLine("Не найдено");
            else
            {
                Console.Write("Найдено:");
                Console.Write(temp_root.data + "(");
                if (temp_root.left == null) Console.Write("NULL");
                else Console.Write(temp_root.left.data);
                Console.Write(", ");
                if (temp_root.right == null) Console.Write("NULL");
                else Console.Write(temp_root.right.data);
                Console.Write(")");
            }
        }

        /// <summary>
        /// Распечатка двоичного дерева в виде скобочной записи
        /// </summary>
        /// <param name="root"></param>
        static void printTree(Node root)
        {
            if (root!=null)
            {
                Console.Write(root.data);
                if (root.left != null || root.right != null)
                {
                    Console.Write("(");

                    if (root.left != null)
                        printTree(root.left);
                    else
                        Console.Write("NULL");
                    Console.Write(",");

                    if (root.right != null)
                        printTree(root.right);
                    else
                        Console.Write("NULL");
                    Console.Write(")");
                }
            }
        }

        /// <summary>
        /// Другая распечатка двоичного дерева
        /// </summary>
        /// <param name="root"></param>
        static void printTree2(Node root)
        {
            if (root != null)
            {
                Console.Write(root.data);
                if (root.left != null || root.right != null)
                {
                    Console.Write("\n(");

                    if (root.left != null)
                    {
                        Console.Write("");
                        printTree2(root.left);
                    }
                    else
                        Console.Write("NULL");
                    Console.Write(",");

                    if (root.right != null)
                    {
                        
                        printTree2(root.right);
                        Console.Write(")");
                    }
                    else
                        Console.Write("NULL");
                    Console.Write(")");
                }
            }
        }
        
        /// <summary>
        /// Создание нового узла
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        static Node getFreeNode(int value, Node parent)
        {
            Node tmp = new Node(value,parent);
            tmp.left = tmp.right = null;
           // tmp.data = value;
            tmp.parent = parent;
            return tmp;
        }
                     
        /// <summary>
        /// Вставка узла
        /// </summary>
        /// <param name="head"></param>
        /// <param name="value"></param>
        static void insert(Node head, int value)
        {
            Node tmp = null;
            if (head == null)  
            {
                head = getFreeNode(value, null);
                return;
            }

            tmp = head;
            while (tmp!=null)
            {
                if (value > tmp.data)
                {
                    if (tmp.right!=null)
                    {
                        tmp = tmp.right;
                        continue;
                    }
                    else
                    {
                        tmp.right = getFreeNode(value, tmp);
                        return;
                    }
                }
                else if (value < tmp.data)
                {
                    if (tmp.left!=null)
                    {
                        tmp = tmp.left;
                        continue;
                    }
                    else
                    {
                        tmp.left = getFreeNode(value, tmp);
                        return;
                    }
                }
                else
                {
                    continue;                     // Дерево построено неправильно
                }
            }
        }

        /// <summary>
        /// Обход дерева
        /// </summary>
        /// <param name="root"></param>
        static void preOrderTravers(Node root)
        {
            if (root != null)
            {
                Console.Write(root.data);
                preOrderTravers(root.left);
                preOrderTravers(root.right);
            }
        }
    }
}