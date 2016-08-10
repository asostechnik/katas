using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BankOutsideIn.Tests
{
    [TestFixture]
    public class TransactionStoreShould
    {
        [Test]
        public void Add_Deposit()
        {
            var transactionStore = new TransactionStore();
            const string date = "20-12-2016";
            const int amount = 1;
            var bankTransaction = new Deposit(amount, date);

            transactionStore.Add(bankTransaction);

            transactionStore.GetAll().OfType<Deposit>().Should()
                .ContainSingle(x => x.Amount == amount && x.Date == date);
        }

        [Test]
        public void Add_Withdrawal()
        {
            var transactionStore = new TransactionStore();
            const string date = "20-12-2016";
            const int amount = 1;
            var bankTransaction = new Withdrawal(amount, date);

            transactionStore.Add(bankTransaction);

            transactionStore.GetAll().OfType<Withdrawal>().Should()
                .ContainSingle(x => x.Amount == amount && x.Date == date);
        }
    }
}
