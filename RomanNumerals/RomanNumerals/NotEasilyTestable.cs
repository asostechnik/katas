using System;

namespace RomanNumerals
{
    public class NotEasilyTestable
    {
        public void DoStuff()
        {
            Action<string> printToConsole = Console.WriteLine; 
            Console.WriteLine("dah");
        }
    }




}