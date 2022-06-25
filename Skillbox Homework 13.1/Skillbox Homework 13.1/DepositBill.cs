using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox_Homework_13._1
{
    class DepositBill : Bill, IBill<Bill>
    {
        public DepositBill()
        {

        }

        public Bill Open()
        {
            return new DepositBill();
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
