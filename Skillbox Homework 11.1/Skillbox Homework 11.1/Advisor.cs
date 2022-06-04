using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox_Homework_11._1
{
    class Advisor : User
    {
        public Advisor()
        {
            isSecondNamePermittedRead = true;
            isFirstNamePermittedRead = true;
            isPatronymicPermittedRead = true; 
            isPhoneNumberPermittedRead = true;
            isPassportPermittedRead = false;

            isSecondNamePermittedWrite = false;
            isFirstNamePermittedWrite = false;
            isPatronymicPermittedWrite = false;
            isPhoneNumberPermittedWrite = true;
            isPassportPermittedWrite = false;
        }
    }
}
