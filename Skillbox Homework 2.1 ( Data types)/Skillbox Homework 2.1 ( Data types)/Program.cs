using System;

namespace Skillbox_Homework_2._1___Data_types_
{
    class Program
    {
        static void Main(string[] args)
        {   
        
              string fullName = "Denis Petrische";      // переменная для имени и фамилии
              int age = 22;                             // переменная для возраста
              string email = "0298287677@mail.ru";      // переменная для электронной почты
       
              float programmingScore = 12.6f;           // выбираем тип float для баллов
              float physicsScore = 4.4f;                // по всем
              float mathScore = 13.3f;                  // предметам


              // используем паттерн для удобства вывода

              string pattern = "FullName: {0} \nAge: {1} \nEmail: {2} \nProgrammingScore: {3} \nPhysicsScore: {4} \nMathScore: {5}";

            Console.Write(pattern,               // вывод переменных в консоль
                          fullName,              
                          age,
                          email,
                          programmingScore,
                          physicsScore,
                          mathScore);

            Console.ReadKey();                   // ожидание нажатия клавиши
        }
    }
}
