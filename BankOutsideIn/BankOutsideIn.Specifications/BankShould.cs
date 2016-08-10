using System;
using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace BankOutsideIn.Specifications
{
    [TestFixture]
    //[Ignore("During development only")]
    public class BankShould
    {
        [Test]
        public void PrintStatement()
        {
            var expectedPrintOutput = "date || credit || debit || balance" + Environment.NewLine +
                                      "14-01-2012 || || 5.00 || 25.00" + Environment.NewLine +
                                      "13-01-2012 || 20.00 || || 30.00" + Environment.NewLine +
                                      "10-01-2012 || 10.00 || || 10.00" + Environment.NewLine;

            var consoleOutStringBuilder = new StringBuilder();
            var consoleOutWriter = new StringWriter(consoleOutStringBuilder);
            Console.SetOut(consoleOutWriter);

            var account = new Account(new TransactionStore(), new Printer());

            account.Deposit(10, "10-01-2012");
            account.Deposit(20, "13-01-2012");
            account.Withdraw(5, "14-01-2012");
            account.Print();


            consoleOutStringBuilder.ToString().Should().Be(expectedPrintOutput);
        }
    }
}
