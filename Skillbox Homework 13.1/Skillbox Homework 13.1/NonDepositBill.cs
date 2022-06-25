using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox_Homework_13._1
{
    class NonDepositBill : Bill, IBill<Bill>
    {
        public NonDepositBill()
        {

        }

        public Bill Open()
        {
            return new NonDepositBill();
        }

        public override void Close()
        {

        }

        public override void Transfer()
        {

        }

        public override void AddMoney()
        {

        }
    }
}
