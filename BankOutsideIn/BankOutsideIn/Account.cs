using System;

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
            var transations = _transactionStore.GetAll();
/*
            var statement = new Statement(transations);
            Console.Write(statement);
*/
        }
    }
}