using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    class CheckingAccount:Account
    {
        #region Variable
        private decimal fee;
        #endregion


        #region constructor
        public CheckingAccount(decimal balance, decimal fee)
            : base(balance)
        {
            Balance = balance;
        }
        #endregion


        #region Properties
        private decimal Fee
        {
            get
            {
                return fee;
            }
            set
            {
                fee = value;
            }
        }
        #endregion

        #region Methods
        public override void Debit(decimal debit)
        {
            if (debit > Balance)
            {
                Console.WriteLine("Debit money exceeded acconut balance");
                return;
            }
            Balance = Balance - debit - fee;
        }
        #endregion
    }
}
