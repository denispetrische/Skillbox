using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Skillbox_Homework_8._4
{
    class Program
    {
        static void Main()
        {
            string path = "hello.xml";
            Console.WriteLine("\nВведите имя");
            string name = Console.ReadLine();

            Console.WriteLine("\nВведите название улицы");
            string street = Console.ReadLine();

            Console.WriteLine("\nВведите номер дома");
            int houseNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите номер квартиры");
            int appartementNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите номер мобильного телефона");
            int mobilePhone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите номер домашнего телефона");
            int homePhone = Convert.ToInt32(Console.ReadLine());

            Data newDirectory = new Data(name, street, houseNumber, appartementNumber, mobilePhone, homePhone);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data));

            Stream recordStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(recordStream, newDirectory);

            recordStream.Close();
        }
    }
}
