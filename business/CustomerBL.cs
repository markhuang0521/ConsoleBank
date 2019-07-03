using System;
using Entities;
using dataBase;
using System.Collections.Generic;

namespace business
{
    public static class CustomerBL
    {
        //create new cust
        public static void CreateCust(Customer cust)
        {
            // Call the DAL to create a new record.
            try
            {
                CustomerDAL.CreateCust(cust);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //find old accounts and customer
        public static Customer GetCust(int custId)
        {
            return CustomerDAL.FindCust(custId);
        }

        public static Account GetAccount(int custId, int accId)
        {
            return CustomerDAL.FindAccount(custId, accId);
        }

        public static List<Customer> GetAllCust()
        {
            return CustomerDAL.GetAllCust();

        }
        public static List<Account> GetAllAccount(int custId)
        {
            return CustomerDAL.GetAllAccount(custId);

        }
        public static Customer RemoveCust(int custId)
        {
            return CustomerDAL.RemoveCust(custId);
        }
        public static Account RemoveAccount(int custId, int accId)
        {
            return CustomerDAL.RemoveAccount(custId, accId);
        }
        //create different accounts
        public static void AddChecking(Customer cust, CheckingAccount account)
        {
            CustomerDAL.AddChecking(cust, account);

        }
        public static void AddBusiness(Customer cust, BusinessAccount account)
        {
            CustomerDAL.AddBusiness(cust, account);

        }
        public static void AddTermDeposit(Customer cust, TermDeposit account)
        {
            CustomerDAL.AddTermDeposit(cust, account);

        }
        public static void AddLoan(Customer cust, Loan account)
        {
            CustomerDAL.AddLoan(cust, account);

        }


    }
}
