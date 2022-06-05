using System;

namespace Skillbox_Homework_11._1
{
    public abstract class User
    {
        public bool isSecondNamePermittedRead;
        public bool isFirstNamePermittedRead;
        public bool isPatronymicPermittedRead;
        public bool isPhoneNumberPermittedRead;
        public bool isPassportPermittedRead;

        public bool isSecondNamePermittedWrite;
        public bool isFirstNamePermittedWrite;
        public bool isPatronymicPermittedWrite;
        public bool isPhoneNumberPermittedWrite;
        public bool isPassportPermittedWrite;
    }
}
