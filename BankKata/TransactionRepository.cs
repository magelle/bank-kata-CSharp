using System.Collections.Generic;

namespace BankKata
{
    public class TransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public virtual void Store(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public virtual List<Transaction> All()
        {
            return _transactions;
        }
    }

}