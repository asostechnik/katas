namespace BankOutsideIn
{
    public abstract class BankTransaction
    {
        protected BankTransaction(uint amount, string date)
        {
            Amount = amount;
            Date = date;
        }

        public uint Amount { get; private set; }

        public string Date { get; private set; }

        public abstract int SignedAmount { get; }
    }
}