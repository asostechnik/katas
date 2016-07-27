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
            var account = new Account(transactionStore.Object);

            account.Deposit(1, "20-12-2016");

            transactionStore.Verify(x => x.Add(It.IsAny<Deposit>()));
        }
    }
}
