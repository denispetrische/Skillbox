using System;

namespace Skillbox_Homework_11._1
{
    public abstract class User
    {
        public bool IsSecondNamePermittedRead => isSecondNamePermittedRead;
        public bool IsFirstNamePermittedRead => isFirstNamePermittedRead;
        public bool IsPatronymicPermittedRead => isPatronymicPermittedRead;
        public bool IsPhoneNumberPermittedRead => isPhoneNumberPermittedRead;
        public bool IsPassportPermittedRead => isPassportPermittedRead;
        public bool IsSecondNamePermittedWrite => isSecondNamePermittedWrite;
        public bool IsFirstNamePermittedWrite => isFirstNamePermittedWrite;
        public bool IsPatronymicPermittedWrite => isPatronymicPermittedWrite;
        public bool IsPhoneNumberPermittedWrite => isPhoneNumberPermittedWrite;
        public bool IsPassportPermittedWrite => isPassportPermittedWrite;

        private protected bool isSecondNamePermittedRead;
        private protected bool isFirstNamePermittedRead;
        private protected bool isPatronymicPermittedRead;
        private protected bool isPhoneNumberPermittedRead;
        private protected bool isPassportPermittedRead;

        private protected bool isSecondNamePermittedWrite;
        private protected bool isFirstNamePermittedWrite;
        private protected bool isPatronymicPermittedWrite;
        private protected bool isPhoneNumberPermittedWrite;
        private protected bool isPassportPermittedWrite;
    }
}
