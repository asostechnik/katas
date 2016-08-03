using System;
using FluentAssertions;
using NUnit.Framework;

namespace BankOutsideIn.Tests
{
    [TestFixture]
    public class StatementShould
    {
        [Test]
        public void Format_Header()
        {
            var header = "date || credit || debit || balance" + Environment.NewLine;

            var statement = new Statement(new BankTransaction[0]);

            statement.ToString().Should().Be(header);
        }

        [Test]
        public void Format_Header_With_Rows()
        {
            var content = "date || credit || debit || balance" + Environment.NewLine +
                          "10-01-2012 || 10.00 || || 10.00" + Environment.NewLine;

            var statement = new Statement(new BankTransaction[] { new Deposit(10, "10-01-2012") });

            statement.ToString().Should().Be(content);
        }
    }
}
