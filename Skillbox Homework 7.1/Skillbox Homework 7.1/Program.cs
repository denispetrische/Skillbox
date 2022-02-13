using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Timers;

namespace Skillbox_Homework_7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = "Сотрудники.txt";
            bool isActive = true; // если false - закрытие программы 
            bool isEnterPressed = false;
            int whichChoosenX = 0; // координата X для меню
            int whichChoosenY = 0; // координата Y для меню
            ConsoleKey pressedKey;

            Buttons[] ButtonsArray = new Buttons[6];
            Buttons[] ButtonsArraySort = new Buttons[5];

            DataBase Workers = new DataBase(directoryPath);            
            Workers.Load();

            ConsolePreset(); // настраивает размер консоли 
            CreateMenu(ButtonsArray, ButtonsArraySort);

            while (isActive)
            {
                UpdateMenu(ButtonsArray, ButtonsArraySort, whichChoosenX, whichChoosenY);

                pressedKey = Console.ReadKey().Key;

                switch (pressedKey)
                {
                    case ConsoleKey.RightArrow:
                        whichChoosenY = 0;
                        whichChoosenX++;
                        if (whichChoosenX >= ButtonsArray.Length)
                        {
                            whichChoosenX = ButtonsArray.Length - 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        whichChoosenY = 0;
                        whichChoosenX--;
                        if (whichChoosenX < 0)
                        {
                            whichChoosenX = 0;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (whichChoosenX == 4)
                        {
                            whichChoosenY++;

                            if (whichChoosenY >= 4)
                            {
                                whichChoosenY = 4;
                            }
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (whichChoosenX == 4)
                        {
                            whichChoosenY--;

                            if (whichChoosenY < 0)
                            {
                                whichChoosenY = 0;
                            }
                        }
                        break;

                    case ConsoleKey.Enter:
                        isEnterPressed = true;
                        break;

                    default:
                        break;
                }

                if (isEnterPressed)
                {
                    switch (whichChoosenX)
                    {
                        case 0:
                            Workers.ShowInfo();
                            Console.WriteLine("\n Для продолжения нажмите любую кнопку");
                            Console.ReadKey();
                            break;

                        case 1:
                            Workers.Add();
                            break;

                        case 2:
                            Workers.Delete();
                            break;

                        case 3:
                            Workers.Edit();
                            break;

                        case 4:
                            Workers.Sort(whichChoosenY);
                            break;

                        case 5:
                            isActive = false;
                            break;
                    }

                    isEnterPressed = false;
                }
            }
        }

        static void ConsolePreset()
        {
            Console.SetBufferSize(160, 50);
            Console.SetWindowSize(160, 50);
            Console.CursorVisible = false;
        }

        static void CreateMenu(Buttons[] ButtonsArray, Buttons[] ButtonsArraySort) 
        {
            ButtonsArray[0] = new Buttons("Показать", 1, 1);
            ButtonsArray[1] = new Buttons("Добавить", 10, 1);
            ButtonsArray[2] = new Buttons("Удалить", 19, 1);
            ButtonsArray[3] = new Buttons("Редактировать", 27, 1);
            ButtonsArray[4] = new Buttons("Сортировать", 41, 1);
            ButtonsArray[5] = new Buttons("Выход", 53, 1);

            ButtonsArraySort[1] = new Buttons("Выбрать период времени", 43, 3);
            ButtonsArraySort[2] = new Buttons("По дате добавления", 43, 5);
            ButtonsArraySort[3] = new Buttons("По ID", 43, 7);
            ButtonsArraySort[4] = new Buttons("По дате рождения", 43, 9);           
        }

        static void UpdateMenu(Buttons[] ButtonsArray, Buttons[] ButtonsArraySort, int whichChoosenX, int whichChoosenY)
        {
            Console.Clear();

            for (int i = 0; i < ButtonsArray.Length; i++)
            {
                if (i == whichChoosenX)
                {
                    if (whichChoosenX == 4)
                    {
                        if (whichChoosenY > 0)
                        {
                            Console.SetCursorPosition(ButtonsArray[4].PositionX, ButtonsArray[4].PositionY);
                            Console.Write(ButtonsArray[4].Text);

                            for (int j = 1; j < ButtonsArraySort.Length; j++)
                            {
                                if (j == whichChoosenY)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.SetCursorPosition(ButtonsArraySort[j].PositionX, ButtonsArraySort[j].PositionY);
                                    Console.Write(ButtonsArraySort[j].Text);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.SetCursorPosition(ButtonsArraySort[j].PositionX, ButtonsArraySort[j].PositionY);
                                    Console.Write(ButtonsArraySort[j].Text);
                                }

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(ButtonsArray[4].PositionX, ButtonsArray[4].PositionY);
                            Console.Write(ButtonsArray[4].Text);
                            Console.ForegroundColor = ConsoleColor.White;

                            for (int j = 1; j < ButtonsArraySort.Length; j++)
                            {
                                Console.SetCursorPosition(ButtonsArraySort[j].PositionX, ButtonsArraySort[j].PositionY);
                                Console.Write(ButtonsArraySort[j].Text);
                            }
                        }           
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(ButtonsArray[i].PositionX, ButtonsArray[i].PositionY);
                        Console.Write(ButtonsArray[i].Text);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.SetCursorPosition(ButtonsArray[i].PositionX, ButtonsArray[i].PositionY);
                    Console.Write(ButtonsArray[i].Text);
                }
            }
        }
    }

    struct Person
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime uploadTime;

        public DateTime UploadTime
        {
            get { return uploadTime; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string age;

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        private string height;

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        private string birthday;

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private string birthPlace;

        public string BirthPlace
        {
            get { return birthPlace; }
            set { birthPlace = value; }
        }

        public Person (int id, string name, string age, string height, string birthday, string birthdayPlace)
        {
            this.id = id;
            this.uploadTime = DateTime.Now;
            this.name = name;
            this.age = age;
            this.height = height;
            this.birthday = birthday;
            this.birthPlace = birthdayPlace;
        }

        public Person(int id, string time, string name, string age, string height, string birthday, string birthdayPlace)
        {
            this.id = id;
            this.uploadTime = Convert.ToDateTime(time);
            this.name = name;
            this.age = age;
            this.height = height;
            this.birthday = birthday;
            this.birthPlace = birthdayPlace;
        }
    }

    struct DataBase
    {
        int index;
        
        public int Index
        {
            get { return index; }
        }

        Person[] Base;

        public Person this[int i]
        {
            get {return Base[i]; }
            set {Base[i] = value; }
        }

        private string path;

        private string[] titles;

        public DataBase(string path)
        {
            this.path = path;
            index = 0;
            Base = new Person[8];
            titles = new string[7] { "ID:", "Дата добавления:", "ФИО:", "Возраст:", "Рост:", "Дата рождения:", "Место рождения:"};
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

                allStrings = File.ReadAllLines(path);
                allStrings = allStrings.Skip(1).ToArray();

                if (allStrings.Length > 1)
                {
                    foreach (var line in allStrings)
                    {
                        substrings = line.Split('#');
                        Person LoadedWorker = new Person(Convert.ToInt32(substrings[0]), substrings[1], substrings[2], substrings[3], substrings[4], substrings[5], substrings[6]);
                        Add(LoadedWorker, Convert.ToInt32(substrings[0]));
                    }

                    index = FreeID();
                }
            }
            else
            {
                using (StreamWriter Writer = new StreamWriter(path, true, Encoding.UTF8))
                {
                    Writer.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");
                    index = 0;
                }             
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
            Write(path);

            index = FreeID();

            Console.WriteLine("\n Сотрудник успешно добавлен. Нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }

        /// <summary>
        /// Перегрузка для добавления элементов в массив при считывании из файла ( чтобы положение в массиве было равно id) 
        /// </summary>
        /// <param name="Worker"></param>
        /// <param name="id"></param>
        public void Add(Person Worker, int id)
        {
            this.ExpandBase(id >= this.Base.Length);
            this.Base[id] = Worker;
        } 

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Введите ID работника, которого желаете удалить");
            int id = Convert.ToInt32(Console.ReadLine());

            bool isExist = false;

            foreach (var number in Base)
            {
                if (number.ID == id)
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
                Base[id].ID = 0; // присваеваем не свой индекс удаляемой строке в базе чтобы перезаписать её в будущем

                string[] allStrings;
                string[] substrings = new string[7];

                int deletedStringNumber = 0;

                allStrings = File.ReadAllLines(path);
                allStrings = allStrings.Skip(1).ToArray();

                if (allStrings.Length > 1)
                {
                    for (int i = 0; i < allStrings.Length; i++)
                    {
                        substrings = allStrings[i].Split('#');

                        if (Convert.ToInt32(substrings[0]) == id)
                        {
                            deletedStringNumber = i;
                        }
                    }

                    string[] newString = new string[allStrings.Length - 1];
                    int counter = 0;

                    for (int i = 0; i < allStrings.Length; i++)
                    {
                        if (i == deletedStringNumber)
                        {
                            continue;
                        }
                        else
                        {
                            newString[counter] = allStrings[i];
                            counter++;
                        }
                    }

                    File.Delete(path);

                    using (StreamWriter Writer = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        Writer.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                        for (int i = 0; i < newString.Length; i++)
                        {
                            Writer.WriteLine(newString[i]);
                        }
                    }

                    Load();

                    Console.WriteLine("Удалено, нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("В списке нет ни одного работника, нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
            }
        }

        public void Delete(int id)
        {
            Base[id].ID = 0; // присваеваем не свой индекс удаляемой строке в базе чтобы перезаписать её в будущем

            string[] allStrings;
            string[] substrings = new string[7];

            int deletedStringNumber = 0;

            allStrings = File.ReadAllLines(path);
            allStrings = allStrings.Skip(1).ToArray();

            if (allStrings.Length > 1)
            {
                for (int i = 0; i < allStrings.Length; i++)
                {
                    substrings = allStrings[i].Split('#');

                    if (Convert.ToInt32(substrings[0]) == id)
                    {
                        deletedStringNumber = i;
                    }
                }

                string[] newString = new string[allStrings.Length - 1];
                int counter = 0;

                for (int i = 0; i < allStrings.Length; i++)
                {
                    if (i == deletedStringNumber)
                    {
                        continue;
                    }
                    else
                    {
                        newString[counter] = allStrings[i];
                        counter++;
                    }
                }

                File.Delete(path);

                using (StreamWriter Writer = new StreamWriter(path, true, Encoding.UTF8))
                {
                    Writer.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                    for (int i = 0; i < newString.Length; i++)
                    {
                        Writer.WriteLine(newString[i]);
                    }
                }

                Load();
            }
        }

        public void Edit() // добавить сортировку по id в конце редактирования 
        {
            Console.Clear();
            Console.WriteLine("Введите ID сотрудника, данные которого желаете редактировать");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                Delete(id);
                Add();
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
            StringBuilder buffer = new StringBuilder("");

            buffer.Append($"{Base[index].ID}" +
                $"#{Base[index].UploadTime:g}" +
                $"#{Base[index].Name}" +
                $"#{Base[index].Age}" +
                $"#{Base[index].Height}" +
                $"#{Base[index].Birthday}" +
                $"#{Base[index].BirthPlace}");

            using (StreamWriter Writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                Writer.WriteLine(buffer);
            }
        }

        public void ShowInfo()
        {
            if (File.Exists(path))
            {
                string[] temp = new string[index];
                temp = File.ReadAllLines(path);

                string[] foo;

                Console.Clear();
                Console.WriteLine(temp[0]);

                temp = temp.Skip(1).ToArray();

                foreach (var line in temp)
                {
                    foo = line.Split('#');

                    Console.WriteLine($"\n{foo[0],4}{foo[1],17}{foo[2],35}{foo[3],9}{foo[4],6}{foo[5],15}{foo[6],21}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Файла не существует, для создания перезагрузите программу");
            }
        }

        public void Sort(int whichSort)
        {
            string[] allStrings;
            string[] substrings = new string[7];
            int[] sortedIndex = new int[Base.Length - 1];
            int counter = 0;

            switch (whichSort)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("Введите дату начального периода в формате ##.##.####");
                    string[] firstTerm = Console.ReadLine().Split('.');
                    DateTime firstDateTime = new DateTime(Convert.ToInt32(firstTerm[2]), Convert.ToInt32(firstTerm[1]), Convert.ToInt32(firstTerm[0]));

                    Console.WriteLine("Введите дату начального периода в формате ##.##.####");
                    string[] secondTerm = Console.ReadLine().Split('.');
                    DateTime secondDateTime = new DateTime(Convert.ToInt32(secondTerm[2]), Convert.ToInt32(secondTerm[1]), Convert.ToInt32(secondTerm[0]));

                    allStrings = File.ReadAllLines(path);
                    allStrings = allStrings.Skip(1).ToArray();

                    string[] splittedLine;
                    
                    Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                    string[] bufferString = new string[7];

                    foreach (var line in allStrings)
                    {
                        splittedLine = line.Split('#');
                        substrings = splittedLine[1].Split('.',' ');
                        DateTime nextData = new DateTime(Convert.ToInt32(substrings[2]), Convert.ToInt32(substrings[1]), Convert.ToInt32(substrings[0]));

                        if (DateTime.Compare(nextData,firstDateTime) > 0 && DateTime.Compare(nextData, secondDateTime) < 0)
                        {
                            Console.WriteLine($"\n{splittedLine[0],4}" +
                                              $"{splittedLine[1],17}" +
                                              $"{splittedLine[2],35}" +
                                              $"{splittedLine[3],9}" +
                                              $"{splittedLine[4],6}" +
                                              $"{splittedLine[5],15}" +
                                              $"{splittedLine[6],21}");
                        }
                    }            

                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите 1 для сортировки по возрастанию даты либо 2 для сортировки по убыванию");
                    string choice = Console.ReadLine();

                    if (choice == "1" || choice == "2")
                    {
                        allStrings = File.ReadAllLines(path);
                        allStrings = allStrings.Skip(1).ToArray();

                        string[] sortingBuffer = new string[allStrings.Length];

                        DateTime[] allDates = new DateTime[allStrings.Length];
                        string[] finalStringArray = new string[allStrings.Length];

                        if (choice == "1") // сортировка по возрастанию
                        {
                            counter = 0;

                            foreach (var line in allStrings)
                            {
                                substrings = line.Split('#');
                                allDates[counter++] = Convert.ToDateTime(substrings[1]);
                            }

                            var sortedDates = allDates.OrderBy(DateTime => DateTime);

                            counter = 0;

                            foreach (DateTime item in sortedDates)
                            {
                                for (int i = 0; i < allStrings.Length; i++)
                                {
                                    substrings = allStrings[i].Split('#');
                                    DateTime nextData = Convert.ToDateTime(substrings[1]);

                                    if (DateTime.Compare(item, nextData) == 0)
                                    {
                                        finalStringArray[counter++] = allStrings[i];
                                        break;
                                    }
                                }
                            }

                            Console.Clear();
                            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                            for (int i = 0; i < finalStringArray.Length; i++)
                            {
                                substrings = finalStringArray[i].Split('#');

                                Console.WriteLine($"\n{substrings[0],4}" +
                                              $"{substrings[1],17}" +
                                              $"{substrings[2],35}" +
                                              $"{substrings[3],9}" +
                                              $"{substrings[4],6}" +
                                              $"{substrings[5],15}" +
                                              $"{substrings[6],21}");
                            }

                            Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                            Console.ReadKey();
                        }

                        else // сортировка по убыванию
                        {
                            counter = 0;

                            foreach (var line in allStrings)
                            {
                                substrings = line.Split('#');
                                allDates[counter++] = Convert.ToDateTime(substrings[1]);
                            }

                            var sortedDates = allDates.OrderByDescending(DateTime => DateTime);

                            counter = 0;

                            foreach (DateTime item in sortedDates)
                            {
                                for (int i = 0; i < allStrings.Length; i++)
                                {
                                    substrings = allStrings[i].Split('#');
                                    DateTime nextData = Convert.ToDateTime(substrings[1]);

                                    if (DateTime.Compare(item, nextData) == 0)
                                    {
                                        finalStringArray[counter++] = allStrings[i];
                                        break;
                                    }
                                }
                            }

                            Console.Clear();
                            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                            for (int i = 0; i < finalStringArray.Length; i++)
                            {
                                substrings = finalStringArray[i].Split('#');

                                Console.WriteLine($"\n{substrings[0],4}" +
                                              $"{substrings[1],17}" +
                                              $"{substrings[2],35}" +
                                              $"{substrings[3],9}" +
                                              $"{substrings[4],6}" +
                                              $"{substrings[5],15}" +
                                              $"{substrings[6],21}");
                            }

                            Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                            Console.ReadKey();
                        }                      
                    }
                    else
                    {
                        Console.WriteLine("Введите корректный символ, нажмите любую кнопку для продолжения");
                        Console.ReadKey();
                    }
                    break;

                case 3:                    
                    allStrings = File.ReadAllLines(path);
                    allStrings = allStrings.Skip(1).ToArray();

                    foreach (var item in allStrings)
                    {
                        substrings = item.Split('#');
                        sortedIndex[counter++] = Convert.ToInt32(substrings[0]);
                    }

                    Array.Sort(sortedIndex);

                    counter = 0;

                    for (int i = 0; i < sortedIndex.Length; i++)
                    {
                        if (sortedIndex[i] != 0)
                        {
                            sortedIndex[counter++] = sortedIndex[i];
                        }
                    }

                    int[] excludedZeroIndexArray = new int[counter];
                    Array.Copy(sortedIndex, 0, excludedZeroIndexArray, 0, counter);

                    File.Delete(path);

                    using (StreamWriter Writer = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        Writer.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                        string[] buffer = new string[excludedZeroIndexArray.Length];

                        for (int i = 0; i < excludedZeroIndexArray.Length; i++)
                        {
                            substrings = allStrings[i].Split('#');
                            buffer[Convert.ToInt32(substrings[0]) - 1] = allStrings[i];
                        }

                        foreach (var line in buffer)
                        {
                            Writer.WriteLine(line);
                        }
                    }

                    Load();

                    Console.Clear();
                    Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Введите 1 для сортировки по возрастанию даты либо 2 для сортировки по убыванию");
                    string input = Console.ReadLine();

                    if (input == "1" || input == "2")
                    {
                        allStrings = File.ReadAllLines(path);
                        allStrings = allStrings.Skip(1).ToArray();

                        string[] sortingBuffer = new string[allStrings.Length];
                        DateTime[] allDates = new DateTime[allStrings.Length];
                        string[] finalStringArray = new string[allStrings.Length];

                        if (input == "1") // сортировка по возрастанию
                        {
                            counter = 0;

                            foreach (var line in allStrings)
                            {
                                substrings = line.Split('#');
                                allDates[counter++] = Convert.ToDateTime(substrings[5]);
                            }

                            var sortedDates = allDates.OrderBy(DateTime => DateTime);

                            counter = 0;

                            foreach (DateTime item in sortedDates)
                            {
                                for (int i = 0; i < allStrings.Length; i++)
                                {
                                    substrings = allStrings[i].Split('#');
                                    DateTime nextData = Convert.ToDateTime(substrings[5]);

                                    if (DateTime.Compare(item, nextData) == 0)
                                    {
                                        finalStringArray[counter++] = allStrings[i];
                                        break;
                                    }
                                }
                            }

                            Console.Clear();
                            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                            for (int i = 0; i < finalStringArray.Length; i++)
                            {
                                substrings = finalStringArray[i].Split('#');

                                Console.WriteLine($"\n{substrings[0],4}" +
                                              $"{substrings[1],17}" +
                                              $"{substrings[2],35}" +
                                              $"{substrings[3],9}" +
                                              $"{substrings[4],6}" +
                                              $"{substrings[5],15}" +
                                              $"{substrings[6],21}");
                            }

                            Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                            Console.ReadKey();
                        }

                        else // сортировка по убыванию
                        {
                            counter = 0;

                            foreach (var line in allStrings)
                            {
                                substrings = line.Split('#');
                                allDates[counter++] = Convert.ToDateTime(substrings[5]);
                            }

                            var sortedDates = allDates.OrderByDescending(DateTime => DateTime);

                            counter = 0;

                            foreach (DateTime item in sortedDates)
                            {
                                for (int i = 0; i < allStrings.Length; i++)
                                {
                                    substrings = allStrings[i].Split('#');
                                    DateTime nextData = Convert.ToDateTime(substrings[5]);

                                    if (DateTime.Compare(item, nextData) == 0)
                                    {
                                        finalStringArray[counter++] = allStrings[i];
                                        break;
                                    }
                                }
                            }

                            Console.Clear();
                            Console.WriteLine($"{titles[0],4}{titles[1],17}{titles[2],35}{titles[3],9}{titles[4],6}{titles[5],15}{titles[6],21}");

                            for (int i = 0; i < finalStringArray.Length; i++)
                            {
                                substrings = finalStringArray[i].Split('#');

                                Console.WriteLine($"\n{substrings[0],4}" +
                                              $"{substrings[1],17}" +
                                              $"{substrings[2],35}" +
                                              $"{substrings[3],9}" +
                                              $"{substrings[4],6}" +
                                              $"{substrings[5],15}" +
                                              $"{substrings[6],21}");
                            }

                            Console.WriteLine("\nВыполнено, нажмите любую кнопку для продолжения");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введите корректный символ, нажмите любую кнопку для продолжения");
                        Console.ReadKey();
                    }
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

        public int FreeID()
        {
            bool isFree = false;
            int idValue = 0;

            for (int i = 1; i <= Base.Length - 1; i++)
            {
                if (i != Base[i].ID)
                {
                    isFree = true;
                    idValue = i;
                    break;
                }
            }

            if (isFree)
            {
                return idValue - 1;
            }
            else
            {
                return Base.Length - 1;
            }
        }
    }

    struct Buttons
    {
        public string Text { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Buttons(string text, int positionX, int positionY)
        {
            Text = text;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
