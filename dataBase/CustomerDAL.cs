using System;
using System.Collections.Generic;
using Entities;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace dataBase
{
    public static class CustomerDAL
    {
        public static List<Customer> customers = new List<Customer>();
        //private static string connStr = ConfigurationManager.ConnectionStrings["Ecommerce"].ConnectionString;

        //databse connectstring 
        //private static string connStr = "Server=tcp:ming0521.database.windows.net,1433;Initial Catalog=Ecommerce;Persist Security Info=False;User ID=markhuang;Password=ming0521H;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //private static SqlConnection connect = new SqlConnection(connStr);



        public static void CreateCust(Customer cust)
        {
            try
            {
                customers.Add(cust);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //WITH DATABASE
        //public static void CreateCust(Customer cust)
        //{

        //    StringBuilder qry = new StringBuilder();
        //    qry.Append("INSERT INTO Customers");
        //    qry.Append("(name,email)");
        //    qry.Append(" VALUES(");
        //    qry.Append($"'{cust.Name}','{cust.email}'");
        //    qry.Append(" )");

        //    Console.WriteLine(qry);
        //    using (SqlConnection connect = new SqlConnection(connStr))
        //    {

        //        using (SqlCommand cmd = new SqlCommand(qry.ToString(), connect))
        //        {
        //            connect.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }



        //}
        //public static Customer FindCust(int custId)
        //{

        //    StringBuilder qry = new StringBuilder();
        //    qry.Append("SELECT * FROM Customers");
        //    qry.Append($" WHERE custId = {custId}");

        //    Customer cust = new Customer();

        //    Console.WriteLine(qry);
        //    using (SqlConnection connect = new SqlConnection(connStr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(qry.ToString(), connect))
        //        {
        //            connect.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {

        //                cust.CustId = (int)reader["custId"];
        //                cust.Name = reader["name"].ToString();

        //                cust.email = reader["email"].ToString();

        //            }

        //        }
        //    }
        //    return cust;

        //}

        public static Customer RemoveCust(int custId)
        {
            try
            {
                var cust = FindCust(custId);
                customers.Remove(cust);
                return cust;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //without DB
        public static Customer FindCust(int custId)
        {
            try
            {
                //var cust = customers.Where(x => x.CustId == custId);
                //return (Customer)cust;

                foreach (var cust in customers)
                {
                    if (cust.CustId.Equals(custId))
                    {
                        return cust;
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                // Log the details of the exception.
                throw;
                //return null;
            }
        }

        public static List<Account> GetAllAccount(int custId)
        {
            try
            {
                var list = new List<Account>();
                var cust = FindCust(custId);
                List<Account> check = cust.CheckAccounts.ConvertAll(x => (Account)x);
                List<Account> business = cust.BusAccounts.ConvertAll(x => (Account)x);
                List<Account> termDeposit = cust.TermDeposits.ConvertAll(x => (Account)x);
                List<Account> loan = cust.Loans.ConvertAll(x => (Account)x);
                list.AddRange(check);
                list.AddRange(business);
                list.AddRange(termDeposit);
                list.AddRange(loan);
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        public static Account FindAccount(int custId, int accountId)
        {
            try
            {
                List<Account> lists = GetAllAccount(custId);

                // Connect to DB, search for record with matching id.
                foreach (var acc in lists)
                {
                    if (acc.AccountID.Equals(accountId))
                    {
                        return acc;

                    }



                }
                //throw new Exception("Cannot connect to the Database.");
                return null;

            }
            catch (Exception ex)
            {
                // Log the details of the exception.
                throw;
                //return null;
            }
        }

        public static CheckingAccount GetCheckingAccount(int custId, int accId)
        {
            try
            {
                var cust = FindCust(custId);
                foreach (var acc in cust.CheckAccounts)
                {
                    if (acc.AccountID.Equals(accId))
                    {
                        return acc;
                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static BusinessAccount GetBusinessAccount(int custId, int accId)
        {
            try
            {
                var cust = FindCust(custId);
                foreach (var acc in cust.BusAccounts)
                {
                    if (acc.AccountID.Equals(accId))
                    {
                        return acc;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static TermDeposit GetTermDeposit(int custId, int accId)
        {
            try
            {
                var cust = FindCust(custId);
                foreach (var acc in cust.TermDeposits)
                {
                    if (acc.AccountID.Equals(accId))
                    {
                        return acc;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Loan GetLoan(int custId, int accId)
        {
            try
            {
                var cust = FindCust(custId);
                foreach (var acc in cust.Loans)
                {
                    if (acc.AccountID.Equals(accId))
                    {
                        return acc;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public static Account RemoveAccount(int custId, int accountId)
        {
            try
            {
                var lists = GetAllAccount(custId);
                var acc = FindAccount(accountId, custId);

                lists.Remove(acc);
                return acc;

            }
            catch (Exception ex)
            {
                // Log the details of the exception.
                throw;
                //return null;
            }
        }



        public static List<Customer> GetAllCust()
        {

            return customers;

        }


        //old method for adding accounts
        public static void AddChecking(Customer customer, CheckingAccount account)
        {
            Customer cust = FindCust(customer.CustId);

            if (cust != null)
            {
                cust.CheckAccounts.Add(account);
            }
        }
        public static void AddBusiness(Customer customer, BusinessAccount account)
        {
            Customer cust = FindCust(customer.CustId);

            if (cust != null)
            {
                cust.BusAccounts.Add(account);
            }
        }
        public static void AddTermDeposit(Customer customer, TermDeposit account)
        {
            Customer cust = FindCust(customer.CustId);

            if (cust != null)
            {
                cust.TermDeposits.Add(account);
            }
        }
        public static void AddLoan(Customer customer, Loan account)
        {
            Customer cust = FindCust(customer.CustId);

            if (cust != null)
            {
                cust.Loans.Add(account);
            }
        }


        //public static void AddAccount(int custId, Account account, string type)
        //{
        //    try
        //    {

        //        var cust = FindCust(custId);

        //        switch (type.ToLower())
        //        {
        //            case "checking":

        //                if (cust != null)
        //                {
        //                    cust.CheckAccounts.Add((CheckingAccount)account);
        //                }
        //                break;
        //            case "business":

        //                if (cust != null)
        //                {
        //                    cust.BusAccounts.Add((BusinessAccount)account);
        //                }
        //                break;
        //            case "termdeposit":

        //                if (cust != null)
        //                {
        //                    cust.TermDeposits.Add((TermDeposit)account);
        //                }
        //                break;
        //            case "loan":

        //                if (cust != null)
        //                {
        //                    cust.Loans.Add((Loan)account);
        //                }
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


    }
}
