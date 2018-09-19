using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    class SavingsAccount:Account
    {
        #region Variables
        private decimal interestRate;
        #endregion


        #region Constructer
        public SavingsAccount(decimal balance, decimal interestRate)
            :base(balance)
        {
            InterestRate = interestRate;
        }
        #endregion


        #region Properties
        public decimal InterestRate
        {
            private get
            {
                return interestRate;
            }
            set
            {                
                interestRate = value / 100;
            }
        }
        #endregion

        #region Methods
        public decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }
        #endregion
    }
}
