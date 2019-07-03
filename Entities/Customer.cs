using System;
using System.Collections.Generic;

namespace Entities
{
    public class Customer
    {
        private static int idCount = 1;
        public string Name;
        public string email;
        public int CustId;
        public List<CheckingAccount> CheckAccounts;
        public List<BusinessAccount> BusAccounts;
        public List<TermDeposit> TermDeposits;
        public List<Loan> Loans;

        public Customer() { }

        public Customer(string name)
        {
            Name = name;
            CheckAccounts = new List<CheckingAccount>();

            BusAccounts = new List<BusinessAccount>();
            TermDeposits = new List<TermDeposit>();
            Loans = new List<Loan>();

            CustId = idCount;
            idCount++;
        }
        //public Customer()
        //{
        //CheckAccounts = new List<CheckingAccount>();
        //BusAccounts = new List<BusinessAccount>();
        //TermDeposits = new List<TermDeposit>();
        //Loans = new List<Loan>();

        //CustId = idCount;
        //idCount++;
        //}






    }
}
