using System;

namespace Skillbox_Homework_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину последовательности? ");
            int length = int.Parse(Console.ReadLine());

            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                Console.Write($"Введите {i+1} элемент последовательности: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            int minvalue = array[0];

            for (int i = 0; i < length; i++)
            {
                if (minvalue > array[i])
                {
                    minvalue = array[i];
                }
            }

            Console.WriteLine($"Минимальное число в последовательности {minvalue}");
            Console.ReadKey();
           
            // Так же можно найти наименьшее число с помощью свойства Sort

            //Array.Sort(array);
            //Console.WriteLine($"Минимальное число {array[0]}");
            //Console.ReadKey();
        }
    }
}
