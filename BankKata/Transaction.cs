using System;

namespace BankKata
{
    public struct Transaction
    {
        public readonly DateTime Date;
        public readonly int Amount;

        public Transaction(DateTime date, int amount)
        {
            Date = date;
            Amount = amount;
        }

        public static bool operator ==(Transaction t1, Transaction t2)
        {
            return t1.Amount == t2.Amount;
        }

        public static bool operator !=(Transaction t1, Transaction t2)
        {
            return !(t1 == t2);
        }

        public bool Equals(Transaction other)
        {
            return Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Transaction && Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            return Amount;
        }
    }
}