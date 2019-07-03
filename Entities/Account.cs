using System;
using System.Collections.Generic;

namespace Entities
{
    public class Account : IAccount
    {
        private static int idCount = 1;
        public string type;
        public int AccountID;
        public string Name;
        public double InterestRate;
        public double OverDraft;
        public double Balance;
        public DateTime StartDate;
        public DateTime EndDate;
        public List<Transaction> transactions;

        public Account(string name, double inital)
        {
            Balance = inital;
            AccountID = idCount;
            Name = name;
            InterestRate = .03;
            transactions = new List<Transaction>();
            StartDate = DateTime.Now;

            idCount++;
        }
        public Account(string name)
        {
            Balance = 0;
            AccountID = idCount;
            Name = name;
            InterestRate = .03;
            idCount++;
        }


        public virtual void Deposit(double amount)

        {
            if (amount > 0)
            {
                Balance += amount;
                transactions.Add(new Transaction("Deposit", amount));
                Console.WriteLine($"current balance is {Balance:c} ");
            }
            else
            {
                Console.WriteLine("invalid deposit try again");
            }
        }


        public virtual double Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                transactions.Add(new Transaction("Withdraw", amount));

                Console.WriteLine($"withdraw sucessful of amount ${amount:c}, " +
                                  $"\n your remaining balance is{Balance:c}");

                return amount;
            }
            else
            {
                Console.WriteLine("invalid withdraw try again");
                return -1;
            }
        }

        public virtual void Transfer(Account account1, Account account2, double amount)
        {
            double transfer = account1.Withdraw(amount);
            if (transfer > 0 && account1.AccountID != account2.AccountID)
            {
                account2.Deposit(transfer);
                transactions.Add(new Transaction("Transfer", amount));
                Console.WriteLine($"transfer ${amount} successful");
            }
            else
            {
                Console.WriteLine("transfer fail please try again");
            }
        }

        public void PrintTrans()
        {
            Console.WriteLine("bwlow is the transaction for this account");
            foreach (var item in transactions)
            {
                Console.WriteLine($"No#{item.TransId}, type: {item.Type} amount: {item.Amount}");
            }
        }

        public static explicit operator Account(List<CheckingAccount> v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Account(List<BusinessAccount> v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator List<object>(Account v)
        {
            throw new NotImplementedException();
        }
    }
}
