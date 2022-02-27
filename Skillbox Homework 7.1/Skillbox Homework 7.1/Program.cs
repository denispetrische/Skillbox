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

            Buttons[] buttonsArray = new Buttons[6];
            Buttons[] buttonsArraySort = new Buttons[5];

            DataBase workers = new DataBase(directoryPath);            
            workers.Load();

            ConsolePreset(); // настраивает размер консоли 
            CreateMenu(buttonsArray, buttonsArraySort);

            while (isActive)
            {
                UpdateMenu(buttonsArray, buttonsArraySort, whichChoosenX, whichChoosenY);

                pressedKey = Console.ReadKey().Key;

                switch (pressedKey)
                {
                    case ConsoleKey.RightArrow:
                        whichChoosenY = 0;
                        whichChoosenX++;
                        if (whichChoosenX >= buttonsArray.Length)
                        {
                            whichChoosenX = buttonsArray.Length - 1;
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

                            if (whichChoosenY >= 3)
                            {
                                whichChoosenY = 3;
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
                            workers.ShowInfo();
                            Console.WriteLine("\n Для продолжения нажмите любую кнопку");
                            Console.ReadKey();
                            break;

                        case 1:
                            workers.Add();
                            break;

                        case 2:
                            workers.Delete();
                            break;

                        case 3:
                            workers.Edit();
                            break;

                        case 4:
                            workers.Sort(whichChoosenY);
                            break;

                        case 5:
                            isActive = false;

                            if (File.Exists(directoryPath))
                            {
                                File.Delete(directoryPath);
                            }

                            workers.Write(directoryPath);
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

        static void CreateMenu(Buttons[] buttonsArray, Buttons[] buttonsArraySort) 
        {
            buttonsArray[0] = new Buttons("Показать", 1, 1);
            buttonsArray[1] = new Buttons("Добавить", 10, 1);
            buttonsArray[2] = new Buttons("Удалить", 19, 1);
            buttonsArray[3] = new Buttons("Редактировать", 27, 1);
            buttonsArray[4] = new Buttons("Сортировать", 41, 1);
            buttonsArray[5] = new Buttons("Выход", 53, 1);

            buttonsArraySort[1] = new Buttons("Выбрать период времени", 43, 3);
            buttonsArraySort[2] = new Buttons("По дате добавления", 43, 5);
            buttonsArraySort[3] = new Buttons("По дате рождения", 43, 7);           
        }

        static void UpdateMenu(Buttons[] buttonsArray, Buttons[] buttonsArraySort, int whichChoosenX, int whichChoosenY)
        {
            Console.Clear();

            for (int i = 0; i < buttonsArray.Length; i++)
            {
                if (i == whichChoosenX)
                {
                    if (whichChoosenX == 4)
                    {
                        if (whichChoosenY > 0)
                        {
                            Console.SetCursorPosition(buttonsArray[4].PositionX, buttonsArray[4].PositionY);
                            Console.Write(buttonsArray[4].Text);

                            for (int j = 1; j < buttonsArraySort.Length; j++)
                            {
                                if (j == whichChoosenY)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.SetCursorPosition(buttonsArraySort[j].PositionX, buttonsArraySort[j].PositionY);
                                    Console.Write(buttonsArraySort[j].Text);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.SetCursorPosition(buttonsArraySort[j].PositionX, buttonsArraySort[j].PositionY);
                                    Console.Write(buttonsArraySort[j].Text);
                                }

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(buttonsArray[4].PositionX, buttonsArray[4].PositionY);
                            Console.Write(buttonsArray[4].Text);
                            Console.ForegroundColor = ConsoleColor.White;

                            for (int j = 1; j < buttonsArraySort.Length; j++)
                            {
                                Console.SetCursorPosition(buttonsArraySort[j].PositionX, buttonsArraySort[j].PositionY);
                                Console.Write(buttonsArraySort[j].Text);
                            }
                        }           
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(buttonsArray[i].PositionX, buttonsArray[i].PositionY);
                        Console.Write(buttonsArray[i].Text);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.SetCursorPosition(buttonsArray[i].PositionX, buttonsArray[i].PositionY);
                    Console.Write(buttonsArray[i].Text);
                }
            }
        }
    }
}
