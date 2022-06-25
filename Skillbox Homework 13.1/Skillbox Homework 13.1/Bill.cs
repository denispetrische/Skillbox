using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox_Homework_13._1
{
    public abstract class Bill
    {
        private protected float ammount;
        private protected string name;

        public abstract void Close();
        public abstract void Transfer();
        public abstract void AddMoney();
    }
}
