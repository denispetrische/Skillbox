using System;

namespace Skillbox_Homework_11._1
{
    class Manager : User
    {
        public Manager()
        {
            isSecondNamePermittedRead = true;
            isFirstNamePermittedRead = true;
            isPatronymicPermittedRead = true;
            isPhoneNumberPermittedRead = true;
            isPassportPermittedRead = true;

            isSecondNamePermittedWrite = true;
            isFirstNamePermittedWrite = true;
            isPatronymicPermittedWrite = true;
            isPhoneNumberPermittedWrite = true;
            isPassportPermittedWrite = true;
        }
    }
}
