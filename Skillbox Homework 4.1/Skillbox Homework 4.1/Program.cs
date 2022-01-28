using System;

namespace Skillbox_Homework_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк матрицы: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы: ");
            int columns = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[rows, columns];

            int totalSum = 0;

            Random randomNumber = new Random();

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(); // перенос на новую строку, для корректного вывода матрицы

                for (int j = 0; j < columns; j++)
                {                   
                    matrix[i, j] = randomNumber.Next(10);

                    Console.Write($"{matrix[i, j]} ");
                                        
                    totalSum += matrix[i, j];
                }
            }

            Console.WriteLine(); // перенос на новую строку для красоты с:
            Console.Write($"Сумма всех элементов матрицы: {totalSum}");
            Console.ReadKey();
        }
    }
}
