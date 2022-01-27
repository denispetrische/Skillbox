using System;

namespace Skillbox_Homework_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");         
            int value = int.Parse(Console.ReadLine());  
            
            if(value % 2 == 0)   
            {
                Console.WriteLine("Число является чётным");
            }
            else
            {
                Console.WriteLine("Число является нечётным");
            }
            Console.ReadKey();   
        }
    }
}
