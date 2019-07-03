using System;
namespace Entities
{
    public class BusinessAccount : Account
    {


        public BusinessAccount(string name, double inital, double interestRate) : base(name, inital)
        {
            type = "business";
            InterestRate = interestRate;

        }
        public BusinessAccount(string name, double interestRate) : base(name)
        {
            type = "business";
            InterestRate = interestRate;

        }

        public override double Withdraw(double amount)
        {
            Balance -= amount;
            OverDraft = (Balance - amount) * 1.1;

            return amount;
        }

        public void Transfer(BusinessAccount account1, Account account2, double amount)
        {
            double transfer = account1.Withdraw(amount);

            OverDraft = (Balance - amount) * 1.3;
            account2.Deposit(transfer);
            transactions.Add(new Transaction("Transfer", amount));
            Console.WriteLine($"transfer ${amount} successful");


        }


    }
}
