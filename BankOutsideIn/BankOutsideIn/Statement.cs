using System;
using System.Text;

namespace BankOutsideIn
{
    public class Statement
    {
        private BankTransaction[] _transactions;

        public Statement(BankTransaction[] transactions)
        {
            _transactions = transactions;
        }

        public override string ToString()
        {
            var statementOutput = new StringBuilder();
            statementOutput.AppendLine("date || credit || debit || balance");

            foreach (var transaction in _transactions)
            {
                statementOutput.AppendLine(transaction.ToString());
            }

            return statementOutput.ToString();
        }
    }
}