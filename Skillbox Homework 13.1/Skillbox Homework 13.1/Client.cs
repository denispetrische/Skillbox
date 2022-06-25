using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Skillbox_Homework_13._1
{
    class Client
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public static ObservableCollection<Client> clients = new ObservableCollection<Client> { };

        public List<Bill> bills;

        public Client(string secondName, string firstName, string patronymic)
        {
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Patronymic = patronymic;
            this.bills = new List<Bill> { };
        }
    }
}
