namespace BankKata
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly StatementFormat _statementFormat;
        private readonly Clock _clock;

        public Account(TransactionRepository transactionRepository, StatementFormat statementFormat, Clock clock)
        {
            _clock = clock;
            _statementFormat = statementFormat;
            _transactionRepository = transactionRepository;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.Store(new Transaction(_clock.today(), amount));
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.Store(new Transaction(_clock.today(), -amount));
        }

        public string Statement()
        {
            return _statementFormat.Format(_transactionRepository.All());
        }
    }
}