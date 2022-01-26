using System;

namespace Skillbox_Homework_2._2__Score_Counting_
{
    class Program
    {
        static void Main(string[] args)
        {
            // переменная для суммы баллов по всем предметам 
            int TotalScore = 0;

            // просим ввести количество предметов
            Console.Write("Введите количество предметов?");

            // считываем данные и преобразуем их в int 
            int SubjectsQuantity = Convert.ToInt32(Console.ReadLine()); 
            
            // цикл для ввода баллов по каждому из предметов
            for(int i = 0; i < SubjectsQuantity; i++)
            {
                Console.Write($"Введите баллы по предмету № {i+1} ")  ;
                TotalScore += Convert.ToInt32(Console.ReadLine());
            }

            //очистим консоль для корректного вывода результатов
            Console.Clear();

            // переменная для среднего арифметического
            float ArithmeticalMean = 0;

            //считаем среднее арифметическое
            ArithmeticalMean = (float)TotalScore / (float)SubjectsQuantity;

            // Реализуем условие вывода по нажатию на любую кнопку
            Console.Write("Для вывода результатов нажмите любую клавишу");
            Console.ReadKey();

            //очистим консоль для корректного вывода результатов
            Console.Clear();

            Console.Write($"Среднее арифметическое: {ArithmeticalMean} \nСумма всех баллов: {TotalScore}");
            Console.ReadKey();
        }
    }
}
