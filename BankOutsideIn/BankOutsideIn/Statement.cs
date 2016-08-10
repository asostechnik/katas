using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BankOutsideIn
{
    public class Statement
    {
        private readonly IEnumerable<BankTransaction> _transactions;

        public Statement(IEnumerable<BankTransaction> transactions)
        {
            _transactions = transactions;
        }

        public override string ToString()
        {
            var statementOutput = new StringBuilder();
            statementOutput.AppendLine("date || credit || debit || balance");

            var balance = _transactions.Sum(t => t.SignedAmount);
            foreach (var transaction in _transactions.OrderByDescending(x => DateTime.Parse(x.Date, CultureInfo.CurrentCulture)))
            {
                statementOutput.AppendLine($"{transaction}{balance:F}");
                balance -= transaction.SignedAmount;
            }

            return statementOutput.ToString();
        }
    }
}