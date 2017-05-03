using System;
using System.Collections.Generic;
using BankKata;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class StatementFormatTest
    {
        [Test]
        public void Format_Should_Return_Header()
        {
            var statementFormat = new StatementFormat();
            var result = statementFormat.Format(new List<Transaction>());
            Assert.AreEqual("date || credit || debit || balance\n", result);
        }

        [Test]
        public void Format_Should_Return_A_Credit()
        {
            var statementFormat = new StatementFormat();
            var transactions = new List<Transaction> {new Transaction(new DateTime(2012, 01, 10), 1000)};
            var result = statementFormat.Format(transactions);
            Assert.AreEqual("date || credit || debit || balance\n" +
                            "10/01/2012 || 1000 || || 1000\n", result);
        }

        [Test]
        public void Format_Should_Return_A_Debit()
        {
            var statementFormat = new StatementFormat();
            var transactions = new List<Transaction>
            {
                new Transaction(new DateTime(2012, 01, 10), 1000),
                new Transaction(new DateTime(2012, 01, 12), -200)
            };
            var result = statementFormat.Format(transactions);
            Assert.AreEqual("date || credit || debit || balance\n" +
                            "12/01/2012 || || 200 || 800\n" +
                            "10/01/2012 || 1000 || || 1000\n", result);
        }
    }
}