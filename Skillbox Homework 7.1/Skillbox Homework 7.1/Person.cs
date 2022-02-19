using System;
using System.Collections.Generic;
using System.Text;

namespace Skillbox_Homework_7._1
{
    struct Person
    {
        public int id { get; set; }

        public DateTime uploadTime { get; set; }

        public string name { get; set; }

        public string age { get; set; }

        public string height { get; set; }

        public string birthday { get; set; }

        public string birthPlace { get; set; }

        public Person(int id, string name, string age, string height, string birthday, string birthdayPlace)
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
}
