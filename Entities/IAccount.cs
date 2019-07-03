using System;
namespace Entities
{
    public interface IAccount
    {
        //void Create();
        //void Close();
        void Deposit(double amount);
        double Withdraw(double amount);
        void Transfer(Account account1, Account account2, double amount);


    }
}
