using System.Threading;

namespace BankOutsideIn
{
    public class Withdrawal : BankTransaction
    {
        public Withdrawal(uint amount, string date) : 
            base(amount, date)
        {
        }

        public override string ToString()
        {
            return $"{Date} || || {Amount}.00 || ";
        }

        public override int SignedAmount => -(int)Amount;
    }
}