using System;
namespace Bank
{
    public class CheckingAccount : IAccount
    {
        public static double InterestRate;
        public double OverDraft;
        public double Balance;
        public int AccountID;
        public string Name;
        public CheckingAccount()
        {
        }

        //public void Close()
        //{

        //}

        //public void Create()
        //{
        //    throw new NotImplementedException();
        //}

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else { Console.WriteLine("invalid amount try agagin!"); }
        }

        public void Transfer(IAccount acc1, IAccount acc2)
        {

        }

        public decimal Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
