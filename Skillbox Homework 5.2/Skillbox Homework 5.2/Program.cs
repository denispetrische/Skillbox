using System;

namespace Skillbox_Homework_5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение разделённое пробелами");
            string phrase = Console.ReadLine();

            Console.WriteLine($"{ReversWords(phrase)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Вызывает метод разделения строки и переставляет подстроки c конца в начало.
        /// </summary>
        /// <param name="inputPhrase"></param>
        /// <returns></returns>
        private static string ReversWords(string inputPhrase)
        {
            var formattedPhrase = DivideWords(inputPhrase);

            string reversedPhrase = "";

            for (int i = 0; i < formattedPhrase.Length; i++)
            {
                reversedPhrase += formattedPhrase[formattedPhrase.Length - (1 + i)] + " ";
            }

            return reversedPhrase;
        }

        /// <summary>
        /// Разделяет входную строку по символам пробела " " и возвращает в виде массива подстрок.
        /// </summary>
        /// <param name="inputPhrase"></param>
        /// <returns></returns>
        private static string[] DivideWords(string inputPhrase)
        {
            string[] divider = new string[1];
            divider[0] = " ";

            return inputPhrase.Split(divider, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
