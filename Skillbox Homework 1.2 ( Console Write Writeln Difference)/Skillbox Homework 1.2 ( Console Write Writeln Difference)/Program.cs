using System; // подключение библиотеки System

namespace Skillbox_Homework_1._2___Console_Write_Writeln_Difference_ // пространство имён 
{
    class Program // класс
    {
        /// <summary>
        /// Основной метод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Hello"); // вывод в консоль без переноса строки 
            Console.Write(" World"); 
            Console.Write("!!!");

            do // цикл do while 
            {

            } 
            while (Console.ReadKey().Key != ConsoleKey.Enter); // не закончится пока не будет нажата 
                                                               // клавиша Enter 
        }
    }
}
