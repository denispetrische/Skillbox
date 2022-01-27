using System;

namespace Skillbox_Homework_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");

            int value = int.Parse(Console.ReadLine());
            bool primeNumberFlag = false;
            int counter = 1;

            while(!primeNumberFlag)
            {
                if((value % counter == 0) && (value != counter) && (counter != 1))
                {
                    break;
                }

                if(value == counter)
                {
                    primeNumberFlag = true;
                    break;
                }
                
                counter++;
            }

            if(primeNumberFlag == true)
            {
                Console.Write("Число является простым");
            }
            else
            {
                Console.Write("Число не является простым");
            }

            Console.ReadKey();
        }
    }
}
