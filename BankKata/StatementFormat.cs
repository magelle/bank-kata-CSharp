using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class StatementFormat
    {
        public virtual string Format(List<Transaction> transactionlist)
        {
            transactionlist.Sort((transaction1, transaction2) => transaction2.Date.CompareTo(transaction1.Date));

            var total = transactionlist.Select(transaction=>transaction.Amount).Sum();
            var statement = "date || credit || debit || balance\n";
            transactionlist.ForEach(transaction =>
            {
                statement += FormatTransaction(transaction, total);
                total -= transaction.Amount;
            });
            return statement;
        }

        private static string FormatTransaction(Transaction transaction, int total)
        {
            var date = transaction.Date.ToString("dd/MM/yyyy");
            return transaction.Amount > 0
                ? FormatDebit(transaction, total, date)
                : FromatCredit(transaction, total, date);
        }

        private static string FromatCredit(Transaction transaction, int total, string date)
        {
            return date + " || || " + -transaction.Amount + " || " + total + "\n";
        }

        private static string FormatDebit(Transaction transaction, int total, string date)
        {
            return date + " || " + transaction.Amount + " || || " + total + "\n";
        }
    }
}