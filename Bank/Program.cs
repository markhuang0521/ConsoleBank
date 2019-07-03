
using System;
using System.Collections.Generic;
using System.Linq;
using business;
using Entities;

namespace client
{
    class Program
    {

        static void Main(string[] args)
        {
            //new bank;
            //create cust 1
            Customer cust = new Customer("mark");
            CustomerBL.CreateCust(cust);
            Console.WriteLine(cust.CustId);

            //checking account 1
            CheckingAccount acc1 = new CheckingAccount("chase", 200);
            acc1.Deposit(100);
            acc1.Deposit(100);
            acc1.Withdraw(10000);
            acc1.Withdraw(100);

            CustomerBL.AddChecking(cust, acc1);
            BusinessAccount capital = new BusinessAccount("capital", 1000);
            capital.Withdraw(2000);
            CustomerBL.AddBusiness(cust, capital);

            //customer2 
            Customer cust2 = new Customer("huang");
            CustomerBL.CreateCust(cust2);
            //Termdeposit 2
            DateTime end = new DateTime(2019, 7, 30);
            var acc2 = new TermDeposit("capital", 200, 300);

            acc2.Withdraw(100, end);
            CustomerBL.AddTermDeposit(cust2, acc2);

            StartBank();


        }

        public static void StartBank()
        {
            int choice;
            PrintMenu();

            do
            {
                Console.WriteLine("===========================================");

                Console.WriteLine("enter your operation");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        PrintMenu();
                        break;
                    case 1:
                        CreateCust();
                        break;
                    case 2:
                        CreatAccount();
                        break;
                    case 3:
                        StartTransaction();

                        break;
                    case 4:
                        RemoveAccount();
                        break;
                    case 5:
                        RemoveCust();
                        break;
                    case 6:
                        PrintTransaction();

                        break;
                    case 7:
                        PrintAllAccount();

                        break;
                    case 8:
                        PrintAllCust();
                        break;
                    case 9:
                        Console.WriteLine("Bank application stopped");
                        break;
                    default:
                        choice = 9;
                        Console.WriteLine("Bank application stopped");

                        break;
                }

            } while (choice != 9);
        }



        //start a tranaction with a existing account 

        static void StartTransaction()
        {
            Console.WriteLine("enter your customer id ");
            int custid = Convert.ToInt32(Console.ReadLine());
            var cust = CustomerBL.GetCust(custid);

            Console.WriteLine("enter your account type ");
            string acctype = Console.ReadLine();

            Console.WriteLine("enter your account id ");
            int accId = Convert.ToInt32(Console.ReadLine());
            var acc = CustomerBL.GetAccount(cust.CustId, accId);

            switch (acctype.ToLower())
            {
                case "checking":
                    var checkAcc = (CheckingAccount)acc;
                    Console.WriteLine("which type of transaction ");
                    Console.WriteLine(" withdraw, deposit, transfer");
                    string actionType = Console.ReadLine();
                    CheckingAction(checkAcc, actionType);
                    break;
                case "business":
                    var businessAcc = (BusinessAccount)acc;
                    Console.WriteLine("which type of transaction ");
                    Console.WriteLine(" withdraw, deposit, transfer");
                    string actionType2 = Console.ReadLine();
                    BusinessAction(businessAcc, actionType2);
                    break;
                case "termdeposit":
                    acc = (TermDeposit)acc;
                    var termAcc = (TermDeposit)acc;
                    Console.WriteLine("which type of transaction ");
                    Console.WriteLine(" withdraw, transfer");
                    string actionType3 = Console.ReadLine();
                    TermAction(termAcc, actionType3);
                    break;
                case "loan":
                    var loanAcc = (Loan)acc;
                    Console.WriteLine("which type of transaction ");
                    Console.WriteLine(" withdraw, deposit, transfer");
                    string actionType4 = Console.ReadLine();
                    LoanAction(loanAcc, actionType4);
                    break;
                default:
                    Console.WriteLine("invalid type");
                    break;

            }

        }
        //account actions
        static void CheckingAction(CheckingAccount acc, string actionType)
        {
            switch (actionType.ToLower())
            {
                case "deposit":
                    Console.WriteLine("enter amount");
                    double deposit = Convert.ToInt32(Console.ReadLine());
                    acc.Deposit(deposit);
                    break;

                case "withdraw":
                    Console.WriteLine("enter amount");
                    double withdraw = Convert.ToInt32(Console.ReadLine());
                    acc.Withdraw(withdraw);
                    break;

                case "transfer":
                    Console.WriteLine("enter 2nd customer id ");
                    int custid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter 2nd account id");
                    int accId = Convert.ToInt32(Console.ReadLine());
                    var acc2 = CustomerBL.GetAccount(custid, accId);
                    Console.WriteLine("enter amount");

                    double transfer = Convert.ToInt32(Console.ReadLine());
                    acc.Transfer(acc, acc2, transfer);
                    break;
                default:
                    break;
            }
        }
        static void BusinessAction(BusinessAccount acc, string actionType)
        {
            switch (actionType.ToLower())
            {
                case "deposit":
                    Console.WriteLine("enter amount");
                    double deposit = Convert.ToInt32(Console.ReadLine());
                    acc.Deposit(deposit);
                    break;

                case "withdraw":
                    Console.WriteLine("enter amount");
                    double withdraw = Convert.ToInt32(Console.ReadLine());
                    acc.Withdraw(withdraw);
                    break;

                case "transfer":
                    Console.WriteLine("enter 2nd customer id ");
                    int custid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter 2nd account id");
                    int accId = Convert.ToInt32(Console.ReadLine());
                    var acc2 = CustomerBL.GetAccount(custid, accId);
                    double transfer = Convert.ToInt32(Console.ReadLine());
                    acc.Transfer(acc, acc2, transfer);
                    break;
                default:
                    break;
            }
        }
        static void TermAction(TermDeposit acc, string actionType)
        {
            switch (actionType.ToLower())
            {


                case "withdraw":
                    Console.WriteLine("enter amount");
                    double withdraw = Convert.ToInt32(Console.ReadLine());
                    acc.Withdraw(withdraw);
                    break;

                case "transfer":
                    Console.WriteLine("enter 2nd customer id ");
                    int custid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter 2nd account id");
                    int accId = Convert.ToInt32(Console.ReadLine());
                    var acc2 = CustomerBL.GetAccount(custid, accId);
                    double transfer = Convert.ToInt32(Console.ReadLine());
                    acc.Transfer(acc, acc2, transfer);
                    break;
                default:
                    break;
            }
        }
        static void LoanAction(Loan acc, string actionType)
        {
            switch (actionType.ToLower())
            {
                case "deposit":
                    Console.WriteLine("enter amount");
                    double deposit = Convert.ToInt32(Console.ReadLine());
                    acc.Deposit(deposit);
                    break;

                case "withdraw":
                    Console.WriteLine("enter amount");
                    double withdraw = Convert.ToInt32(Console.ReadLine());
                    acc.Withdraw(withdraw);
                    break;

                case "transfer":
                    Console.WriteLine("enter 2nd customer id ");
                    int custid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter 2nd account id");
                    int accId = Convert.ToInt32(Console.ReadLine());
                    var acc2 = CustomerBL.GetAccount(custid, accId);
                    double transfer = Convert.ToInt32(Console.ReadLine());
                    acc.Transfer(acc, acc2, transfer);
                    break;
                default:
                    break;
            }
        }

        //creating  customer and different accounts
        static void CreateCust()
        {
            try
            {
                Console.WriteLine("enter your name");
                var name = Console.ReadLine();
                Customer cust = new Customer(name);
                CustomerBL.CreateCust(cust);
                Console.WriteLine($"customer {cust.Name} is created");


            }
            catch (Exception ex)
            {
                Console.WriteLine("registeration fail, please try again");
            }
        }
        public static void CreatAccount()
        {
            Console.WriteLine("which account do you want to create");
            var type = Console.ReadLine();
            switch (type.ToLower())
            {
                case "checking":
                    CreateChecking();
                    break;
                case "business":
                    CreateBusiness();
                    break;
                case "termdeposit":
                    CreateTermDeposit();
                    break;
                case "loan":
                    CreateLoan();
                    break;
                default:
                    Console.WriteLine("invalid type");
                    break;
            }

        }
        public static void CreateChecking()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int id = Convert.ToInt32(Console.ReadLine());

                var cust = CustomerBL.GetCust(id);

                Console.WriteLine("enter your new account name");
                var name = Console.ReadLine();

                Console.WriteLine("enter your inital amount");
                double amount = Convert.ToDouble(Console.ReadLine());

                CheckingAccount acc = new CheckingAccount(name, amount);

                CustomerBL.AddChecking(cust, acc);
                Console.WriteLine($"checking account of  {acc.Name} is created");

            }
            catch (Exception ex)
            {
                Console.WriteLine("registeration fail, please try again");
            }
        }
        public static void CreateBusiness()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int id = Convert.ToInt32(Console.ReadLine());

                var cust = CustomerBL.GetCust(id);

                Console.WriteLine("enter your new business account name");
                var name = Console.ReadLine();

                Console.WriteLine("enter checking your account amount");
                double amount = Convert.ToDouble(Console.ReadLine());

                BusinessAccount acc = new BusinessAccount(name, amount);

                CustomerBL.AddBusiness(cust, acc);
                Console.WriteLine($"Business Account of  {acc.Name} is created");

            }
            catch (Exception ex)
            {
                Console.WriteLine("registeration fail, please try again");
            }
        }
        public static void CreateTermDeposit()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int id = Convert.ToInt32(Console.ReadLine());

                var cust = CustomerBL.GetCust(id);

                Console.WriteLine("enter your new TermDeposit account name");
                var name = Console.ReadLine();

                Console.WriteLine("enter your deposit amount");
                double amount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("enter your deposit time (in days)");
                int days = Convert.ToInt32(Console.ReadLine());

                var acc = new TermDeposit(name, amount, days);

                CustomerBL.AddTermDeposit(cust, acc);
                Console.WriteLine($"TermDeposit account of  {acc.Name} is created");

            }
            catch (Exception ex)
            {
                Console.WriteLine("registeration fail, please try again");
            }
        }
        public static void CreateLoan()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int id = Convert.ToInt32(Console.ReadLine());

                var cust = CustomerBL.GetCust(id);

                Console.WriteLine("enter your loan account name");
                var name = Console.ReadLine();

                Console.WriteLine("enter your loan amount");
                double amount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("enter your interest rate");
                double rate = Convert.ToDouble(Console.ReadLine());

                Loan acc = new Loan(name, amount, rate);

                CustomerBL.AddLoan(cust, acc);
                Console.WriteLine($"loan account of  {acc.Name} is created");

            }
            catch (Exception ex)
            {
                Console.WriteLine("registeration fail, please try again");
            }
        }

        //remove customer or account
        static void RemoveCust()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int id = Convert.ToInt32(Console.ReadLine());
                CustomerBL.RemoveCust(id);
                Console.WriteLine("remove successful");


            }
            catch (Exception ex)
            {
                Console.WriteLine("remove unsuccessful");
            }

        }
        static void RemoveAccount()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int custId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter your account ID");
                int accId = Convert.ToInt32(Console.ReadLine());

                var acc = CustomerBL.RemoveAccount(custId, accId);

                Console.WriteLine($"account #{acc.AccountID} is deleted ");



            }
            catch (Exception ex)
            {
                Console.WriteLine("remove account unsuccessful");
            }

        }

        //printing customer and accoutns
        static void PrintTransaction()
        {
            try
            {
                Console.WriteLine("enter your customer ID");
                int custId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter your account ID");
                int accId = Convert.ToInt32(Console.ReadLine());
                var acc = CustomerBL.GetAccount(custId, accId);
                acc.PrintTrans();
            }
            catch (Exception ex)
            {
                Console.WriteLine("print transaction  unsuccessful");
            }
        }
        static void PrintAllAccount()
        {
            Console.WriteLine("enter your customer id");
            int custId = Convert.ToInt32(Console.ReadLine());
            var accounts = CustomerBL.GetAllAccount(custId);

            foreach (var acc in accounts)
            {
                Console.WriteLine($"account name {acc.Name}, type {acc.type}, account #{acc.AccountID}, ${acc.Balance}");
            }


        }
        static void PrintAllCust()
        {
            var customers = CustomerBL.GetAllCust();

            foreach (var cust in customers)
            {
                Console.WriteLine($"customer # {cust.CustId} is name {cust.Name} ");
            }

        }
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to Bank");
            Console.WriteLine("enter your choice of operation");
            Console.WriteLine("1: register as a new customer");
            Console.WriteLine("2: open a new account as existing customer");
            Console.WriteLine("3: start a new transaction on a account ");
            Console.WriteLine("4: close existing account");
            Console.WriteLine("5: remove as a existing customer");
            Console.WriteLine("6: printing all transcations of a customer");
            Console.WriteLine("7: printing all accounts of a account");
            Console.WriteLine("8: printing all customer within the bank");
            Console.WriteLine("9: exist the application");
        }




    }
}

