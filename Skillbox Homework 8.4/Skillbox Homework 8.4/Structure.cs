using System;
using System.Collections.Generic;
using System.Text;

namespace Skillbox_Homework_8._4
{
    public struct Data
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AppartementNumber { get; set; }
        public int MobilePhone { get; set; }
        public int HomePhone { get; set; }

        public Data(string name, string street, int houseNumber, int appartementNumber, int mobilePhone, int homePhone)
        {
            this.Name = name;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.AppartementNumber = appartementNumber;
            this.MobilePhone = mobilePhone;
            this.HomePhone = homePhone;
        }
    }
}
