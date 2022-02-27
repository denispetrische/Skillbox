using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Timers;

namespace Skillbox_Homework_7._1
{
    struct DataBase
    {
        public int index { get; set;}

        Person[] Base;

        public Person this[int i] 
        {
            get { return Base[i]; }
            set { Base[i] = value; }
        }

        private string path;

        private string[] titles;

        public DataBase(string path)
        {
            this.path = path;
            index = 0;
            Base = new Person[8];
            titles = new string[7] { "ID:", "Дата добавления:", "ФИО:", "Возраст:", "Рост:", "Дата рождения:", "Место рождения:" };
        }

        /// <summary>
        /// Получает информацию если файл существует (кроме первой строчки содержащей заголовки), если файл не существует - создаёт его вместе с заголовками
        /// </summary>
        public void Load()
        {
            if (File.Exists(path))
            {
                string[] allStrings;
                string[] substrings = new string[7];
                int counter = 1;

                allStrings = File.ReadAllLines(path);

                foreach (var line in allStrings)
                {
                    substrings = line.Split('#');
                    Person loadedWorker = new Person(counter, substrings[1], substrings[2], substrings[3], substrings[4], substrings[5], substrings[6]);
                    Base[counter++] = loadedWorker;
                }

                index = counter - 1;         
            }
        }

        public void Add()
        {
            this.index++;
            this.ExpandBase(index >= this.Base.Length);

            Console.Clear();
            Console.WriteLine("Введите ФИО работника:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите возраст работника:");
            string age = Console.ReadLine();

            Console.WriteLine("Введите рост работника:");
            string height = Console.ReadLine();

            Console.WriteLine("Введите дату рождения работника:");
            string birthday = Console.ReadLine();

            Console.WriteLine("Введите место рождения работника:");
            string birthdayPlace = Console.ReadLine();

            Person Worker = new Person(index, name, age, height, birthday, birthdayPlace);

            Base[index] = Worker;

            Console.WriteLine("\n Сотрудник успешно добавлен. Нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Введите ID работника, которого желаете удалить");
            int id = Convert.ToInt32(Console.ReadLine());
            bool isExist = false;
            int nextNumber = 0;
            int previousNumber = 0;

            foreach (var number in Base)
            {
                if (number.id == id)
                {
                    isExist = true;
                }
            }

            if (!isExist)
            {
                Console.WriteLine("Не существует работника с таким ID. \nНажмите любую кнопку для продолжения");
                Console.ReadKey();
            }
            else
            {
                int baseLength = 0;

                foreach (var item in Base)
                {
                    if (item.id != 0)
                    {
                        baseLength++;
                    }
                }

                Base[id].id = 0; // присваеваем не свой индекс удаляемой строке в базе чтобы перезаписать её в будущем               
                nextNumber = id + 1;
                previousNumber = id;

                for (int i = previousNumber; i < baseLength - 1; i++)
                {
                    Base[previousNumber] = Base[nextNumber];
                    Base[previousNumber].id = previousNumber;
                    nextNumber++;
                    previousNumber++;
                }

                Base[baseLength].id = 0;
                index--;

                Console.WriteLine("Удалено, нажмите любую клавишу для продолжения");
                Console.ReadKey();           
            }
        }

        public void Edit() // добавить сортировку по id в конце редактирования 
        {
            Console.Clear();
            Console.WriteLine("Введите ID сотрудника, данные которого желаете редактировать");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                Console.Clear();
                Console.WriteLine("Введите ФИО работника:");
                Base[id].name = Console.ReadLine();

                Console.WriteLine("Введите возраст работника:");
                Base[id].age = Console.ReadLine();

                Console.WriteLine("Введите рост работника:");
                Base[id].height = Console.ReadLine();

                Console.WriteLine("Введите дату рождения работника:");
                Base[id].birthday = Console.ReadLine();

                Console.WriteLine("Введите место рождения работника:");
                Base[id].birthPlace = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n Введите ID существующего сотрудника, нажмите любую кнопку для продолжения");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Записывает данные в txt файл
        /// </summary>
        /// <param name="path"></param>
        public void Write(string path)
        {
            string buffer = "";

            foreach (var person in Base)
            {
                if (person.id != 0)
                {
                    buffer = ($"{person.id}" +
                                $"#{person.uploadTime:g}" +
                                $"#{person.name}" +
                                $"#{person.age}" +
                                $"#{person.height}" +
                                $"#{person.birthday}" +
                                $"#{person.birthPlace}");

                    using (StreamWriter Writer = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        Writer.WriteLine(buffer);
                    }
                }               
            }
        }

        public void ShowInfo()
        {
                Console.Clear();
                Console.WriteLine($"\n{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                foreach (var person in Base)
                {
                   if (person.id != 0)
                   {
                    Console.WriteLine($"\n{person.id,4}" +
                                      $" " +
                                      $"{person.uploadTime.ToString(),17}" +
                                      $"{person.name,35}" +
                                      $"{person.age,9}" +
                                      $"{person.height,6}" +
                                      $"{person.birthday,15}" +
                                      $"{person.birthPlace,21}");
                   }                 
                }
        }

        public void Sort(int whichSort)
        {
            switch (whichSort)
            {
                case 1:
                    SortPeriod();
                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                    break;

                case 2:
                    SortDate();
                    break;

                case 3:
                    SortBirthday();
                    break;

                default:
                    break;
            }
        }

        private void ExpandBase(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.Base, this.Base.Length * 2);
            }
        }

        private void SortPeriod()
        {
            Console.Clear();

            Console.WriteLine("Введите дату начального периода в формате ##.##.####");
            string[] firstTerm = Console.ReadLine().Split('.');
            DateTime firstDateTime = new DateTime(Convert.ToInt32(firstTerm[2]), Convert.ToInt32(firstTerm[1]), Convert.ToInt32(firstTerm[0]));

            Console.WriteLine("Введите дату начального периода в формате ##.##.####");
            string[] secondTerm = Console.ReadLine().Split('.');
            DateTime secondDateTime = new DateTime(Convert.ToInt32(secondTerm[2]), Convert.ToInt32(secondTerm[1]), Convert.ToInt32(secondTerm[0]));

            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

            string[] bufferString = new string[7];

            foreach (var line in Base.Skip(0))
            {
                if (DateTime.Compare(line.uploadTime, firstDateTime) > 0 && DateTime.Compare(line.uploadTime, secondDateTime) < 0)
                {
                    if (line.id != 0)
                    {
                        Console.WriteLine($"\n{line.id,4}" +
                                          $" " +
                                          $"{line.uploadTime.ToString(),17}" +
                                          $"{line.name,35}" +
                                          $"{line.age,9}" +
                                          $"{line.height,6}" +
                                          $"{line.birthday,15}" +
                                          $"{line.birthPlace,21}");
                    }
                }
            }
        }

        private void SortDate()
        {
            Console.Clear();
            Console.WriteLine("Введите 1 для сортировки по возрастанию даты либо 2 для сортировки по убыванию");
            string choice = Console.ReadLine();

            if (choice == "1" || choice == "2")
            {
                if (choice == "1") // сортировка по возрастанию
                {
                    SortAscending();                   
                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                }

                else // сортировка по убыванию
                {
                    SortDescending();                   
                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Введите корректный символ, нажмите любую кнопку для продолжения");
                Console.ReadKey();
            }
        }

        private void SortAscending()
        {
            DateTime[] allDates = new DateTime[Base.Length];
            Person[] finalArray = new Person[Base.Length];
            int counter = 0;

            foreach (var line in Base.Skip(0))
            {
                allDates[counter++] = line.uploadTime;
            }

            var sortedDates = allDates.OrderBy(DateTime => DateTime);

            counter = 0;

            foreach (DateTime item in sortedDates)
            {
                for (int i = 1; i < Base.Length; i++)
                {
                    DateTime nextData = Base[i].uploadTime;

                    if (DateTime.Compare(item, nextData) == 0)
                    {
                        finalArray[counter++] = Base[i];
                        break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].id != 0)
                {
                    Console.WriteLine($"\n{finalArray[i].id,4}" +
                              $" " +
                              $"{finalArray[i].uploadTime,17}" +
                              $"{finalArray[i].name,35}" +
                              $"{finalArray[i].age,9}" +
                              $"{finalArray[i].height,6}" +
                              $"{finalArray[i].birthday,15}" +
                              $"{finalArray[i].birthPlace,21}");
                }
            }
        }

        private void SortDescending()
        {
            DateTime[] allDates = new DateTime[Base.Length];
            Person[] finalArray = new Person[Base.Length];
            int counter = 0;

            foreach (var line in Base.Skip(0))
            {
                allDates[counter++] = line.uploadTime;
            }

            var sortedDates = allDates.OrderByDescending(DateTime => DateTime);

            counter = 0;

            foreach (DateTime item in sortedDates)
            {
                for (int i = 0; i < Base.Length; i++)
                {
                    DateTime nextData = Base[i].uploadTime;

                    if (DateTime.Compare(item, nextData) == 0)
                    {
                        finalArray[counter++] = Base[i];
                        break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].id != 0)
                {
                    Console.WriteLine($"\n{finalArray[i].id,4}" +
                              $" " +
                              $"{finalArray[i].uploadTime,17}" +
                              $"{finalArray[i].name,35}" +
                              $"{finalArray[i].age,9}" +
                              $"{finalArray[i].height,6}" +
                              $"{finalArray[i].birthday,15}" +
                              $"{finalArray[i].birthPlace,21}");
                }
            }
        }

        private void SortBirthday()
        {
            Console.Clear();
            Console.WriteLine("Введите 1 для сортировки по возрастанию даты либо 2 для сортировки по убыванию");
            string choice = Console.ReadLine();

            if (choice == "1" || choice == "2")
            {
                if (choice == "1") // сортировка по возрастанию
                {
                    SortAscendingBirthday();
                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                }

                else // сортировка по убыванию
                {
                    SortDescendingBirthday();
                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Введите корректный символ, нажмите любую кнопку для продолжения");
                Console.ReadKey();
            }
        }

        private void SortAscendingBirthday()
        {
            DateTime[] allDates = new DateTime[Base.Length];
            Person[] finalArray = new Person[Base.Length];
            string[] divider = new string[3];
            int counter = 0;

            foreach (var line in Base.Skip(0))
            {
                allDates[counter++] = Convert.ToDateTime(line.birthday);
            }

            var sortedDates = allDates.OrderBy(DateTime => DateTime);

            counter = 0;

            foreach (DateTime item in sortedDates)
            {
                for (int i = 1; i < Base.Length; i++)
                {
                    DateTime nextData = Convert.ToDateTime(Base[i].birthday);

                    if (DateTime.Compare(item, nextData) == 0)
                    {
                        finalArray[counter++] = Base[i];
                        break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].id != 0)
                {
                    Console.WriteLine($"\n{finalArray[i].id,4}" +
                              $" " +
                              $"{finalArray[i].uploadTime,17}" +
                              $"{finalArray[i].name,35}" +
                              $"{finalArray[i].age,9}" +
                              $"{finalArray[i].height,6}" +
                              $"{finalArray[i].birthday,15}" +
                              $"{finalArray[i].birthPlace,21}");
                }
            }
        }

        private void SortDescendingBirthday()
        {
            DateTime[] allDates = new DateTime[Base.Length];
            Person[] finalArray = new Person[Base.Length];
            int counter = 0;

            foreach (var line in Base.Skip(0))
            {
                allDates[counter++] = Convert.ToDateTime(line.birthday);
            }

            var sortedDates = allDates.OrderByDescending(DateTime => DateTime);

            counter = 0;

            foreach (DateTime item in sortedDates)
            {
                for (int i = 0; i < Base.Length; i++)
                {
                    DateTime nextData = Convert.ToDateTime(Base[i].birthday);

                    if (DateTime.Compare(item, nextData) == 0)
                    {
                        finalArray[counter++] = Base[i];
                        break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

            for (int i = 0; i < finalArray.Length; i++)
            {
                if (finalArray[i].id != 0)
                {
                    Console.WriteLine($"\n{finalArray[i].id,4}" +
                              $" " +
                              $"{finalArray[i].uploadTime,17}" +
                              $"{finalArray[i].name,35}" +
                              $"{finalArray[i].age,9}" +
                              $"{finalArray[i].height,6}" +
                              $"{finalArray[i].birthday,15}" +
                              $"{finalArray[i].birthPlace,21}");
                }
            }
        }
    }
}
