using System.Threading;

namespace BankOutsideIn
{
    public class Withdrawal : BankTransaction
    {
        public Withdrawal(uint amount, string date) : 
            base(amount, date)
        {
        }
    }
}