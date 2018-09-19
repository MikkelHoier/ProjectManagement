using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    public class Account
    {
        public string Name { get; set; }
        private decimal balance;

        public Account(string accountName, decimal initialBalance)
        {
            Name = accountName;
            balance = initialBalance;
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if(value > 0.0m)
                {
                    balance = value;
                }
            }
        }

        public void Deposit(decimal depositAmount)
        {
            if (depositAmount > 0.0m)
            {
                Balance = balance + depositAmount;
            }
        }

        public void Withdraw(decimal withdrawAmount)
        {
            if(withdrawAmount < balance)
            {
                Balance = balance - withdrawAmount;
            }
        }

        public static void DisplayAccount(Account accountToDisplay)
        {
            Console.WriteLine(
                $"{accountToDisplay.Name}'s balance: {accountToDisplay.Balance}");
        }
    }
}
