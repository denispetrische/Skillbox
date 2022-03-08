using System;
using System.Collections.Generic;

namespace Skillbox_Homework_8._3
{
    class Program
    {
        static void Main()
        {
            var array = new HashSet<int>();
            bool endFlag = false;

            while (!endFlag)
            {
                Add(array);

                Console.WriteLine("\nВведите Esc для выхода, введите любую клавишу для продолжения");

                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Escape)
                {
                    endFlag = true;
                }
            }
        }

        static void Add(HashSet<int> array)
        {
            Console.WriteLine("\nВведите число");

            var number = Convert.ToInt32(Console.ReadLine());

            if (array.Contains(number))
            {
                Console.WriteLine("\nКоллекция уже содержит такое число");
            }
            else
            {
                array.Add(number);
                Console.WriteLine("\nУспешно выполнено!");
            }
        }
    }
}
