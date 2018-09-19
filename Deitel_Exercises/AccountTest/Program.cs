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
            Account account1 = new Account("Jane Green", 50.00m);
            Account account2 = new Account("John Blue", -7.53m);

            // display initial balance of each object
            Account.DisplayAccount(account1);
            Account.DisplayAccount(account2);

            //prompt for then read input
            Console.Write("\nEnter deposit amount for account1: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine(
                $"adding {depositAmount:c} to account1 balance\n");
            account1.Deposit(depositAmount); // add to account1's balance

            // display balances
            Account.DisplayAccount(account1);
            Account.DisplayAccount(account2);

            // prompt for then read input
            Console.Write("\nEnter deposit amount for account2: ");
            depositAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine(
                $"adding {depositAmount:c} to account2 balance\n");
            account2.Deposit(depositAmount); // add to account2's balance

            // display balances
            Account.DisplayAccount(account1);
            Account.DisplayAccount(account2);
        }
    }
}
