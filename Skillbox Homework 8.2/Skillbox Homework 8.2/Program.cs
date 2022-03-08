using System;
using System.Collections.Generic;

namespace Skillbox_Homework_8._2
{
    class Program
    {
        static void Main()
        {
            var phoneBook = new Dictionary<int, string>();
            bool stopFlag = false;

            while (!stopFlag)
            {
                Add(phoneBook);
                stopFlag = End();
            }

            stopFlag = false;

            while (!stopFlag)
            {
                Find(phoneBook);
                stopFlag = End();             
            }
        }

        static void Add(Dictionary<int,string> phoneBook)
        {
            Console.WriteLine("\nВведите номер телефона");
            var number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите ФИО владельца телефона");
            var name = Console.ReadLine();

            phoneBook.Add(number, name);

            Console.WriteLine("\nДобавлено");
        }

        static void Find(Dictionary<int, string> phoneBook)
        {
            Console.WriteLine("\nВведите номер телефона для нахождения владельца");
            var number = Convert.ToInt32(Console.ReadLine());
            string name;

            if (phoneBook.ContainsKey(number))
            {
                phoneBook.TryGetValue(number, out name);

                Console.WriteLine($"\n Владелец номера {number} - {name}");
            }
            else
            {
                Console.WriteLine("\nТакого номера нет в списке");
            }
        }

        static bool End()
        {
            Console.WriteLine("\nНажмите Esc если желаете закончить, нажмите любую другую клавишу для продолжения");

            var pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
