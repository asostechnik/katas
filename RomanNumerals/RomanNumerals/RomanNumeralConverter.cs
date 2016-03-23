using System;
using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanNumeralConverter
    {
        private static readonly Dictionary<int, string> RomanNumerals = new Dictionary<int, string>()
        {
            { 1, "I" }, {4, "IV"}, { 5, "V" }, {9, "IX"}, { 10, "X" }, { 40, "XL" }
        };

        public static string Convert(int arabicNumber)
        {
            if (RomanNumerals.ContainsKey(arabicNumber))
                return RomanNumerals[arabicNumber];

            if (arabicNumber > 50)
            {
                return "L" + Convert(arabicNumber - 50);
            }

            if (arabicNumber > 10)
            {
                return "X" + Convert(arabicNumber - 10);
            }

            if (arabicNumber > 5)
            {
                return "V" + Convert(arabicNumber - 5);
            }

            return new string('I', arabicNumber);
        }
    }
}
