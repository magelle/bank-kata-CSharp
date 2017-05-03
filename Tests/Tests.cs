using System;
using BankKata;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void IntegrationTest()
        {
            var transcationrepository = new TransactionRepository();
            var statementFormat = new StatementFormat();
            var clock = Substitute.For<Clock>();
            clock.today().Returns(new DateTime(2012, 01, 10), new DateTime(2012, 01, 13), new DateTime(2012, 01, 14));
            var account = new Account(transcationrepository, statementFormat, clock);

            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);

            var expectedResult = account.Statement();
            Assert.AreEqual(expectedResult, "date || credit || debit || balance\n" +
                                            "14/01/2012 || || 500 || 2500\n" +
                                            "13/01/2012 || 2000 || || 3000\n" +
                                            "10/01/2012 || 1000 || || 1000\n");
        }
    }
}