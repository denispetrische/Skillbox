using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Skillbox_Homework_6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = "Сотрудники.txt"; // указываем путь для нашего файла 
            bool isWorking = true;

            int id = 0;
            if (File.Exists(directoryPath))
            {
                id = GetID(directoryPath);
            }

            while (isWorking)
            {
                Console.WriteLine("\nВведите 1 для вывода базы данных");
                Console.WriteLine("Введите 2 для записи нового сотрудника");
                Console.WriteLine("Введите 3 для закрытия программы\n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string[] temp = GetInfo(directoryPath, id);

                        if (temp != null)
                        {
                            string foo = "";
                            foreach (var line in temp)
                            {
                                foo = line.Replace("#", " ");
                                Console.WriteLine($"\n{foo}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nФайл не существует, создайте его нажав кнопку 2 и записав параментры сотрудника");
                        }
                        break;

                    case "2":
                        WriteInfo(directoryPath, ref id);
                        break;

                    case "3":
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Введена некорректная команда\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Считывает данные из документа
        /// </summary>
        /// <param name="directoryPath">Путь к документу</param>
        /// <returns>Возвращает данные типа StringBuilder</returns>
        private static string[] GetInfo(string directoryPath, int id)
        {
            string []temp = new string[id];

            if (File.Exists(directoryPath))
            {
                temp = File.ReadAllLines(directoryPath);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        /// <summary>
        /// Записывает нового сотрудника по установленной форме
        /// </summary>
        /// <param name="directoryPath">Путь к документу</param>
        /// <param name="idCounter"> ID сотрудника</param>
        private static void WriteInfo(string directoryPath, ref int idCounter)
        {
            using (StreamWriter Writer = new StreamWriter(directoryPath, true, Encoding.UTF8))
            {
                idCounter++;
                DateTime currentTime = DateTime.Now;
                StringBuilder buffer = new StringBuilder("");

                buffer.Append($"{idCounter}#{currentTime:g}#");

                Console.WriteLine("\nВведите ФИО сотрудника");
                buffer.Append($"{Console.ReadLine()}#");

                Console.WriteLine("Введите возраст сотрудника");
                buffer.Append($"{Console.ReadLine()}#");

                Console.WriteLine("Введите рост сотрудника");
                buffer.Append($"{Console.ReadLine()}#");

                Console.WriteLine("Введите дату рождения сотрудника");
                buffer.Append($"{Console.ReadLine()}#");

                Console.WriteLine("Введите место рождения сотрудника");
                buffer.Append($"{Console.ReadLine()}");

                Writer.WriteLine(buffer);

                Console.WriteLine("\nСотрудник успешно добавлен\n");
            }
        }   
        
        private static int GetID(string path)
        {
            int temp;
            var lastString = File.ReadLines(path).Last();

            if (!string.IsNullOrEmpty(lastString))
            {
                temp = Convert.ToInt32(lastString.Substring(0, lastString.IndexOf("#")));
            }
            else
            {
                temp = 0;
            }

            return temp;
        }
    }
}
