using System;
using System.Collections.Generic;
using BankKata;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AccountTest
    {
        private Account _account;
        private TransactionRepository _transactionRepository;
        private StatementFormat _statementFormat;
        private Clock _clock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _transactionRepository = Substitute.For<TransactionRepository>();
            _statementFormat = Substitute.For<StatementFormat>();
            _clock = Substitute.For<Clock>();
            _account = new Account(_transactionRepository, _statementFormat, _clock);
        }

        [Test]
        public void Deposit_Should_Store_A_Deposit()
        {
            // Arrange
            var today = new DateTime();
            _clock.today().Returns(today);
            // Act
            _account.Deposit(1000);
            // Assert
            _transactionRepository.Received().Store(new Transaction(today, 1000));
        }

        [Test]
        public void Withdraw_Should_Store_A_Withdrawal()
        {
            // Arrange
            var today = new DateTime();
            _clock.today().Returns(today);
            // Act
            _account.Withdraw(1000);
            // Assert
            _transactionRepository.Received().Store(new Transaction(today, -1000));
        }

        [Test]
        public void Statement_Should_Return_()
        {
            // Arrange
            var today = new DateTime();
            _clock.today().Returns(today);
            var transactionlist = new List<Transaction>();
            transactionlist.Add(new Transaction(today, 500));
            transactionlist.Add(new Transaction(today, -200));

            _transactionRepository.All().Returns(transactionlist);
            var expectedResult = "result";
            _statementFormat.Format(transactionlist).Returns(expectedResult);
            // Act
            var result = _account.Statement();
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}