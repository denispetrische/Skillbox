using System;

namespace Skillbox_Homework_4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число до которого будем угадывать? с: ");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLength];

            Random randomValue = new Random();

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = randomValue.Next(10);
            }

            int hiddenNumber = array[randomValue.Next(arrayLength)];

            Console.WriteLine("Что-ж, начинаем играть ");

            while (true)
            {
                Console.WriteLine("Введите число: ");

                string enterdetector = Console.ReadLine();               

                if (enterdetector == "")
                {
                    Console.WriteLine($"Загаданным числом было {hiddenNumber}");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    int suggestedNumber = int.Parse(enterdetector);

                    if (suggestedNumber > hiddenNumber)
                    {
                        Console.WriteLine("Неа, загаданное число меньше");
                    }
                    else
                    {
                        if (suggestedNumber < hiddenNumber)
                        {
                            Console.WriteLine("Неа, загаданное число больше");
                        }
                        else
                        {
                            Console.WriteLine($"Поздравляем, вы угадали. Загаданным числом было {hiddenNumber}");
                            Console.ReadKey();
                            break;
                        }
                    }
                }

            }
        }
    }
}
