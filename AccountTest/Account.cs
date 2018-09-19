using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    class Account
    {
        #region Variable
        private decimal balance;
        #endregion


        #region constructor
        public Account (decimal balance)
        {
            Balance = balance;
        }
        #endregion


        #region properties
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if(value < 0.0m)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Balance)} must be above 0");
                }
                balance = value;
            }
        }
        #endregion

        #region methods
        public virtual void Credit(decimal credit)
        {
            Balance = balance + credit;
        }

        public virtual void Debit(decimal debit)
        {
            if (debit > Balance)
            {
                Console.WriteLine("Debit money exceeded acconut balance");
                return;
            }
            Balance = Balance - debit;            
        }
        #endregion
    }
}
