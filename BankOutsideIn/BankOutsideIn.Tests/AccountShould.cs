using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using Moq;

namespace BankOutsideIn.Tests
{
    [TestFixture]
    public class AccountShould
    {
        [Test]
        public void Deposit()
        {
            var transactionStore = new Mock<TransactionStore>();
            var account = new Account(transactionStore.Object, It.IsAny<Printer>());

            const int depositAmount = 1;
            const string depositDate = "20-12-2016";
            account.Deposit(depositAmount, depositDate);

            transactionStore.Verify(x => x.Add(It.Is<Deposit>(d => d.Amount == depositAmount && d.Date == depositDate)));
        }

        [Test]
        public void Withdraw()
        {
            var transactionStore = new Mock<TransactionStore>();
            var account = new Account(transactionStore.Object, It.IsAny<Printer>());

            const int depositAmount = 1;
            const string depositDate = "20-12-2016";
            account.Withdraw(depositAmount, depositDate);

            transactionStore.Verify(x => x.Add(It.Is<Withdrawal>(w => w.Amount == depositAmount && w.Date == depositDate)));
        }

        [Test]
        public void Print()
        {
            var transactionStore = new Mock<TransactionStore>();
            var printer = new Mock<Printer>();
            var account = new Account(transactionStore.Object, printer.Object);

            account.Print();

            transactionStore.Verify(x => x.GetAll());
            printer.Verify(x => x.Print(It.IsAny<Statement>()));
        }
    }
}
