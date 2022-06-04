using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Collections.ObjectModel;

namespace Skillbox_Homework_11._1
{
    class Data
    {
        private string secondName;
        private string firstName;
        private string patronymic;
        private string phoneNumber;
        private string passport;

        private static bool secondNamePermissionRead;
        private static bool secondNamePermissionWrite;
        private static bool firstNamePermissionRead;
        private static bool firstNamePermissionWrite;
        private static bool patronymicPermissionRead;
        private static bool patronymicPermissionWrite;
        private static bool phoneNumberPermissionRead ;
        private static bool phoneNumberPermissionWrite;
        private static bool passportPermissionRead;
        private static bool passportPermissionWrite;

        private static bool overrideFlag;

        public string SecondName
        {
            get 
            {
                if (secondNamePermissionRead || overrideFlag)
                {
                    return secondName;
                }
                else
                {
                    return "***";
                } 
            }
            set 
            {
                if (secondNamePermissionWrite || overrideFlag)
                {
                    secondName = value;
                }
            }
        }

        public string FirstName
        {
            get 
            {
                if (firstNamePermissionRead || overrideFlag)
                {
                    return firstName;
                }
                else
                {
                    return "***";
                }
            }
            set
            {
                if (firstNamePermissionWrite || overrideFlag)
                {
                    firstName = value;
                }
            }
        }

        public string Patronymic
        {
            get 
            {
                if (patronymicPermissionRead || overrideFlag)
                {
                    return patronymic;
                }
                else
                {
                    return "***";
                }
            }
            set 
            {
                if (patronymicPermissionWrite || overrideFlag)
                {
                    patronymic = value;
                }
            }
        }

        public string PhoneNumber
        {
            get 
            {
                if (phoneNumberPermissionRead || overrideFlag)
                {
                    return phoneNumber;
                }
                else
                {
                    return "***";
                }
            }
            set 
            {
                if (phoneNumberPermissionWrite || overrideFlag)
                {
                    phoneNumber = value;
                }
            }
        }

        public string Passport
        {
            get 
            {
                if (passportPermissionRead || overrideFlag)
                {
                    return passport;
                }
                else
                {
                    return "***";
                }
            }
            set 
            {
                if (passportPermissionWrite || overrideFlag)
                {
                    passport = value;
                }
            }
        }

        public Data(string secondName, string firstName, string patronymic, string phoneNumber, string passport)
        {
            this.secondName = secondName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.passport = passport;           
        }

        public static void GetPermissions(User user)
        {
            secondNamePermissionRead = user.isSecondNamePermittedRead;
            secondNamePermissionWrite = user.isSecondNamePermittedWrite;
            firstNamePermissionRead = user.isFirstNamePermittedRead;
            firstNamePermissionWrite = user.isFirstNamePermittedWrite;
            patronymicPermissionRead = user.isPatronymicPermittedRead;
            patronymicPermissionWrite = user.isPatronymicPermittedWrite;
            phoneNumberPermissionRead = user.isPhoneNumberPermittedRead;
            phoneNumberPermissionWrite = user.isPhoneNumberPermittedWrite;
            passportPermissionRead = user.isPassportPermittedRead;
            passportPermissionWrite = user.isPassportPermittedWrite;
        }

        public void Edit(string secondName, string firstName, string patronymic, string phoneNumber, string passport)
        {
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Patronymic = patronymic;
            this.PhoneNumber = phoneNumber;
            this.Passport = passport;
        }

        public static void OverridePetrmissions(bool boolValue)
        {
            overrideFlag = boolValue;
        }
    }
}
