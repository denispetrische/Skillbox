using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox_Homework_11._1
{
    interface IChangeInfo
    {
        public abstract void Change(string secondName, string firstName, string patronymic, string phoneNumber, string passport, ref User user);
    }
}
