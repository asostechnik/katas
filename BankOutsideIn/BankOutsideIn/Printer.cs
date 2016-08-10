using System;

namespace BankOutsideIn
{
    public class Printer
    {
        public virtual void Print(Statement statement)
        {
            Console.Write(statement);
        }
    }
}