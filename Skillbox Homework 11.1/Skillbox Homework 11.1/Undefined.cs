using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox_Homework_11._1
{
    public class Undefined : User
    {
        public Undefined()
        {
            isSecondNamePermittedRead = false;
            isFirstNamePermittedRead = false;
            isPatronymicPermittedRead = false;
            isPhoneNumberPermittedRead = false;
            isPassportPermittedRead = false;

            isSecondNamePermittedWrite = false;
            isFirstNamePermittedWrite = false;
            isPatronymicPermittedWrite = false;
            isPhoneNumberPermittedWrite = false;
            isPassportPermittedWrite = false;
        }
    }
}
