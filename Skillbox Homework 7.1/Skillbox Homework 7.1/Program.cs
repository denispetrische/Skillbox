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
                            File.Delete(directoryPath);
                            Workers.Write(directoryPath);
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
}
