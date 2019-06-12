using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace task9__24_
{
    class Program
    {
        //функция проверки ввода целого числа
        public static int CheckInputInt(string message, int minValue, int maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            int input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToInt16(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input < minValue) || (input > maxValue)); //пока значение больше макс/меньше мин
            return input;
        }

        static Random rnd = new Random();

        //запись случайных чисел в файл
        static void WriteRandomFile(string fileName, int n, int minValue,int maxValue)
        {
            StreamWriter sw = new StreamWriter(fileName);

            for (int i = 0; i < n - 1; i++)
            {
                sw.Write(rnd.Next(minValue, maxValue) + " ");///границы?
            }
            sw.Write(rnd.Next(-100, 100));//посл без пробела
            sw.Close();
        }

        //считывание с файла
        static int[] ReadFileWithIntNumbers(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            string input = sr.ReadToEnd();
            string[] str = input.Split();

            int[] mas;
            mas = new int[str.Length];
            for (int i = 0; i < mas.Length; i++)
                mas[i] = Convert.ToInt32(str[i]);

            return mas;
        }

        //добавление элементов в список
        static void AddRange(DoubleLinkedList<int>list,int[] mas,ref int i)
        {
            while (list.Count < mas.Length)
            {
                AddOneElement(list, mas[i], ref i);
            }
        }

        //выбор способа добавления в зависимости от значения элемента
        static void AddOneElement(DoubleLinkedList<int> list,int elem,ref int i)
        {
            if (elem > 0)
                list.AddInTheBeginning(i + 1);
            if (elem < 0)
                list.AddInTheEnd(i + 1);
            if (elem == 0)
                list.AddInTheMiddle(i + 1);
            i++;
        }

        //удаление элмента из списка
        static void Remove(DoubleLinkedList<int> list,int data)
        {
            if (list.Contains(data))
            {
                list.Remove(data);
                Console.WriteLine("Элемент удален");
            }
            else
                Console.WriteLine("Данного элемента нет в списке");
        }

        //поиск элемента в списке
        static DoubleNode<int> Find(DoubleLinkedList<int> list, int data)
        {
            DoubleNode<int> found = list.Find(data);
            if (found != null)
            {
                Console.WriteLine("Элемент найден");
                return found;
            }
            else
            {
                Console.WriteLine("Элемент не найден");
                return found;
            }
        }


        static void Main(string[] args)
        {
            //программа рекуривно создает двунаправленный список, в информационные поля которого последовательно заносятся номера с 1  до N.
            //Элементы, содержащие отрицательные значения, заносятся в конец списка,
            //положительные - в начало, нулевые - между положительными и отрицательными.
            //Так же реализованы рекурсивные методы поиска и удаления элементов списка


            //создание двунаправленного списка
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            
            //ввода количества элементов и проверка ввода
            int n = CheckInputInt("Введите количество элементов для добавления в двунаправленный список(не больше 100)", 1, 100);

            string fileName = "input.txt";//название файла

            WriteRandomFile(fileName, n, -100, 100);//заполнить файл случайными числами

            int[] mas= ReadFileWithIntNumbers(fileName);//считать данные из файла

            int i = 0;
            AddRange(list, mas, ref i);//добавить заданное количество элементов в список


            Console.WriteLine("Элементы, записанные в файл:");
            foreach (int a in mas)
                Console.Write(a+"\t");//печать элеметов из файла
            Console.WriteLine();

            Console.WriteLine("Печать двунаправленного списка:");
            foreach (int a in list)
                Console.Write(a + "\t");//печать элементов списка
            Console.WriteLine();

            //ввод элемента для уаления и проверка ввода
            int ind = CheckInputInt($"Введите элемент для удаления (от 1 до 100)", 1, 100);
            Remove(list, ind);//удаление элемента из списка
            Console.WriteLine("Печать двунаправленного после удаления элемента:");
            foreach (int a in list)
                Console.Write(a + "\t");//печать списка после удаления элемента
            Console.WriteLine();
            

        }
    }
}
