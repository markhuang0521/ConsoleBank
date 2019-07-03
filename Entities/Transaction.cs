using System;
namespace Entities
{
    public class Transaction
    {
        public int TransId;
        public string Type;
        private static int idCount = 1;
        public double Amount;
        public Transaction(string type, double amount)
        {
            TransId = idCount;
            Type = type;
            Amount = amount;
            idCount++;

        }
    }
}
