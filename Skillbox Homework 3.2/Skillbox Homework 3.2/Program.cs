using System;

namespace Skillbox_Homework_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуй, игрок! Введи количество своих карт: ");
            int cardQuantity = Convert.ToInt32(Console.ReadLine()); 

            string cardValue;    
            int totalSum = 0;   
           
            for(int i = 0; i < cardQuantity; i++)
            {
                Console.WriteLine($"Введите номинал карты №: {i+1}"); ; ;

                cardValue = Console.ReadLine();
             
                switch (cardValue)
                {
                    case "2":
                        totalSum += 2;
                        break;

                    case "3":
                        totalSum += 3;
                        break;

                    case "4":
                        totalSum += 4;
                        break;

                    case "5":
                        totalSum += 5;
                        break;

                    case "6":
                        totalSum += 6;
                        break;

                    case "7":
                        totalSum += 7;
                        break;

                    case "8":
                        totalSum += 8;
                        break;

                    case "9":
                        totalSum += 9;
                        break;

                    case "10":
                        totalSum += 10;
                        break;

                    case "J":
                        totalSum += 10;
                        break;

                    case "Q":
                        totalSum += 10;
                        break;

                    case "K":
                        totalSum += 10;
                        break;

                    case "T":
                        totalSum += 10;
                        break;
                                          // подсказки на случай написания маленькими буквами
                    case "j":
                        Console.WriteLine("Пишите большими латинскими буквами!");
                        i--;              // вторая попытка ввода, на случай ошибки
                        break;            // без этого цикл бы продолжился и пропустил бы
                                          // не введённую карту
                    case "q":
                        Console.WriteLine("Пишите большими латинскими буквами!");
                        i--;              
                        break;

                    case "k":
                        Console.WriteLine("Пишите большими латинскими буквами!");
                        i--;               
                        break;

                    case "t":
                        Console.WriteLine("Пишите большими латинскими буквами!");
                        i--;              
                        break;
                                          
                    default:
                        Console.WriteLine("Такого номинала карты не существует!");
                        i--;
                        break;
                }

                

            }

            Console.WriteLine($"Поздравляем, ваша сумма карт равна {totalSum}");
            Console.ReadKey();
        }
    }
}
