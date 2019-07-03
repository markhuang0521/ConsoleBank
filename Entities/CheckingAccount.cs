using System;
namespace Entities
{
    public class CheckingAccount : Account
    {

        //constructors
        public CheckingAccount(string name, double inital) : base(name, inital)
        { type = "checking"; }

        public CheckingAccount(string name) : base(name)
        { }

        public void Transfer(CheckingAccount account1, Account account2, double amount)
        {
            double transfer = account1.Withdraw(amount);
            if (transfer > 0)
            {
                account2.Deposit(transfer);
                transactions.Add(new Transaction("Transfer", amount));
                Console.WriteLine($"transfer ${amount} successful");
            }

        }



    }
}
