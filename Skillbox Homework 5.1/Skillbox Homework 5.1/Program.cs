using System;

namespace Skillbox_Homework_5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите несколько слов разделённых пробелами?");
            string text = Console.ReadLine();

            string[] separatorValue = new string[1];
            separatorValue[0] = " ";

            string[] formattedText = DivideString(text, separatorValue);
            PrintSubstring(formattedText);

            Console.ReadKey();          
        }

        /// <summary>
        /// Возвращает массив, элементы которого являются подстроками исходной строки 
        /// с удалёнными пустыми местами оставшимися от пробелов 
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        static string[] DivideString(string inputString, string[] divider)
        {
            return inputString.Split(divider, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Выводит каждую подстроку из массива
        /// </summary>
        /// <param name="text"></param>
        static void PrintSubstring(string[] text)
        {
            foreach (var e in text)
            {
                Console.WriteLine($"{e}"); 
            }
        }
    }
}
