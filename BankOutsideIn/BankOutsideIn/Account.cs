using System;

namespace BankOutsideIn
{
    public class Account
    {
        private readonly TransactionStore _transactionStore;
        private readonly Printer _printer;

        public Account(TransactionStore transactionStore, Printer printer)
        {
            _transactionStore = transactionStore;
            _printer = printer;
        }

        public void Deposit(uint amount, string date)
        {
            var deposit = new Deposit(amount, date);
            _transactionStore.Add(deposit);
        }

        public void Withdraw(uint amount, string date)
        {
            var withdrawal = new Withdrawal(amount, date);
            _transactionStore.Add(withdrawal);
        }

        public void Print()
        {
            var transactions = _transactionStore.GetAll();
            var statement = new Statement(transactions);
            _printer.Print(statement);
        }
    }
}