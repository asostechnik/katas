using System.Collections;
using System.Collections.Generic;

namespace BankOutsideIn
{
    public class TransactionStore
    {
        private readonly List<BankTransaction> _bankTransactions = new List<BankTransaction>();
         
        public virtual void Add(BankTransaction transaction)
        {
            _bankTransactions.Add(transaction);
        }

        public virtual IEnumerable<BankTransaction> GetAll()
        {
            return _bankTransactions;
        }
    }
}