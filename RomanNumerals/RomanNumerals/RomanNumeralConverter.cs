using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public class RomanNumeralConverter
    {
        private static readonly Dictionary<int, string> RomanNumerals = new Dictionary<int, string>()
        {
            {1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD"},
            {500, "D"},
            {900, "CM"},
            {1000, "M"}
        };

        public static string Convert(int arabicNumber)
        {
            if (RomanNumerals.ContainsKey(arabicNumber))
                return RomanNumerals[arabicNumber];

            foreach (var romanNumeral in RomanNumerals.Reverse())
            {
                if (arabicNumber > romanNumeral.Key)
                {
                    return romanNumeral.Value + Convert(arabicNumber - romanNumeral.Key);
                }
            }

            return null;
        }
    }
}
