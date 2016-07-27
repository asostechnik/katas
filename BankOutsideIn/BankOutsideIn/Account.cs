namespace BankOutsideIn
{
    public class Account
    {
        private readonly TransactionStore _transactionStore;

        public Account(TransactionStore transactionStore)
        {
            _transactionStore = transactionStore;
        }

        public void Deposit(uint amount, string date)
        {
            var deposit = new Deposit();
            _transactionStore.Add(deposit);
        }

        public void Withdraw(uint amount, string date)
        {
            throw new System.NotImplementedException();
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}