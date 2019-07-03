using System;
namespace Entities
{
    public class TermDeposit : Account
    {

        public int DaysUntilWithdraw;
        public TermDeposit(string name, double inital, int days) : base(name, inital)
        {
            type = "termDeposit";
            StartDate = DateTime.Now;
            DaysUntilWithdraw = days;
        }


        private int RemainDays(DateTime end)
        {
            TimeSpan difference = end - StartDate;
            return difference.Days - DaysUntilWithdraw;
        }
        private bool ReadyToWithdraw(DateTime end)
        {
            TimeSpan difference = end - StartDate;
            return (difference.Days >= DaysUntilWithdraw);
        }

        public TermDeposit(string name) : base(name)
        { }

        public void Deposit(double amount, int days)
        {
            base.Deposit(amount);
            DaysUntilWithdraw = days;
        }
        public double Withdraw(double amount, DateTime end)
        {
            TimeSpan difference = end - StartDate;

            int remainDays = difference.Days - DaysUntilWithdraw;

            if (remainDays >= 0)
            {
                return Withdraw(amount);
            }
            else
            {
                Console.WriteLine($"you deposit hasn't mature please wait until {Math.Abs(remainDays)} days or more");
                return -1;
            }

        }
        public override void Transfer(Account account1, Account account2, double amount)
        {
            DateTime end = DateTime.Now;
            TimeSpan difference = end - StartDate;
            int remainDays = difference.Days - DaysUntilWithdraw;

            if (difference.Days >= DaysUntilWithdraw)
            {
                var withdraw = account1.Withdraw(amount);
                account2.Deposit(withdraw);
            }
            else
            {
                Console.WriteLine($"you deposit hasn't mature please wait until {remainDays} days or more");
            }

        }


    }
}
