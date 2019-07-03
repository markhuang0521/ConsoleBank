using System;
namespace Entities

{
    public class Loan : Account
    {
        public double LoanAmount;

        public Loan(string name, double inital, double interestRate) : base(name, inital)
        {
            type = "loan";
            LoanAmount = 0;
        }

        public void GetLoan(double amount, double interestRate)
        {
            LoanAmount = amount;
            Balance = LoanAmount;
            InterestRate = interestRate;
            Console.WriteLine($"the loan of {LoanAmount} has been created ");
        }
        public void loanPayment(double amount)
        {
            if (amount < LoanAmount && amount > -1)
            {
                LoanAmount -= amount;
                Console.WriteLine($"payment of amount{amount} successful,the remaining loan is ${LoanAmount:c} ");

            }
            else
            {
                Console.WriteLine("invalid amount try again ");
            }

        }
    }
}
