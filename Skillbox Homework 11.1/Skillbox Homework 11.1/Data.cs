using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Collections.ObjectModel;

namespace Skillbox_Homework_11._1
{
    class Data : IChangeInfo
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

        public string Time { get; set; }
        public string WhatChanged { get; set; }

        public string ChangeType { get; set; }

        public string WhoChanged { get; set; }

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
            ClearChangeProps();
        }

        public Data(string secondName, string firstName, string patronymic, string phoneNumber, string passport, string Time, string WhatChanged, string ChangeType, string WhoChanged)
        {
            this.secondName = secondName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.passport = passport;
            this.Time = Time;
            this.WhatChanged = WhatChanged;
            this.ChangeType = ChangeType;
            this.WhoChanged = WhoChanged;
        }

        public Data()
        {

        }

        public static void GetPermissions(ref User user)
        {
            secondNamePermissionRead = user.IsSecondNamePermittedRead;
            secondNamePermissionWrite = user.IsSecondNamePermittedWrite;
            firstNamePermissionRead = user.IsFirstNamePermittedRead;
            firstNamePermissionWrite = user.IsFirstNamePermittedWrite;
            patronymicPermissionRead = user.IsPatronymicPermittedRead;
            patronymicPermissionWrite = user.IsPatronymicPermittedWrite;
            phoneNumberPermissionRead = user.IsPhoneNumberPermittedRead;
            phoneNumberPermissionWrite = user.IsPhoneNumberPermittedWrite;
            passportPermissionRead = user.IsPassportPermittedRead;
            passportPermissionWrite = user.IsPassportPermittedWrite;
        }

        public void Edit(string secondName, string firstName, string patronymic, string phoneNumber, string passport, ref User user)
        {
            Change(secondName, firstName, patronymic, phoneNumber, passport, ref user);
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

        public void Change(string secondName, string firstName, string patronymic, string phoneNumber, string passport, ref User user)
        {
            ClearChangeProps();

            Time = $"{DateTime.Now}";

            if (SecondName != secondName)
            {
                WhatChanged += "SecondName";
            }

            if (FirstName != firstName)
            {
                WhatChanged += " FirstName";
            }

            if (Patronymic != patronymic)
            {
                WhatChanged += " Patronymic";
            }

            if (PhoneNumber != phoneNumber)
            {
                WhatChanged += " PhoneNumber";
            }

            if (Passport != passport)
            {
                WhatChanged += "Passport";
            }

            ChangeType += "Edit";

            if (user.GetType() == typeof(Manager))
            {
                WhoChanged += "Manager";
            }
            else
            {
                WhoChanged += "Advisor";
            }
        }

        private void ClearChangeProps()
        {
            Time = "";
            WhatChanged = "";
            ChangeType = "";
            WhoChanged = "";
        }
    }
}
