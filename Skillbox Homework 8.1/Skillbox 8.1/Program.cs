using System;
using System.Collections.Generic;

namespace Skillbox_8._1
{
    class Program
    {
        static void Main()
        {
            var numbers = new List<int>();

            Fill(numbers);
            ShowList(numbers);
            Delete(numbers);
            ShowList(numbers);

            Console.ReadKey();
        }

        static void Fill(List<int> numbers)
        {
            Random randomNumber = new Random();
            int value;

            for (int i = 0; i < 100; i++)
            {
                value = randomNumber.Next(100);
                numbers.Add(value);
            }
        }

        static void ShowList(List<int> numbers)
        {
            int counter = 0;

            foreach (var item in numbers)
            {
                Console.WriteLine($"Элемент №{counter} = {item}");
                counter++;
            }
        }

        static void Delete(List<int> numbers)
        {
            numbers.RemoveAll(number => number > 25 && number < 50);
        }
    }
}
