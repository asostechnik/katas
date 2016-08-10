namespace BankOutsideIn
{
    public class Deposit : BankTransaction
    {
        public Deposit(uint amount, string date) : 
            base(amount, date)
        {
        }

        public override string ToString()
        {
            return $"{Date} || {Amount}.00 || || ";
        }

        public override int SignedAmount => (int)Amount;
    }
}