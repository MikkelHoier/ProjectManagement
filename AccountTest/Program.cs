using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            SavingsAccount savingsAccount = new SavingsAccount(1000, 5);
            CheckingAccount checkingAccount = new CheckingAccount(1000, 17);

            savingsAccount.Credit(savingsAccount.CalculateInterest());

            Console.WriteLine(savingsAccount.Balance);
            Console.ReadLine();
        }
    }
}
