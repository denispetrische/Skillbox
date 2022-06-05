using System;

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
