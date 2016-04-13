using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RomanNumerals.UnitTests
{
    [TestFixture]
    public class RomanNumeralConverterShould
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(9, "IX")]
        [TestCase(11, "XI")]
        [TestCase(14, "XIV")]
        [TestCase(39, "XXXIX")]
        [TestCase(40, "XL")]
        [TestCase(41, "XLI")]
        [TestCase(50, "L")]
        [TestCase(1999, "MCMXCIX")]
        public void Convert_Arabic_Number_To_Roman_Numeral(int arabicNumber, string expectedRomanNumeral)
        {
            var romanNumeral = RomanNumeralConverter.Convert(arabicNumber);

            Assert.That(romanNumeral, Is.EqualTo(expectedRomanNumeral));
        }
    }
}
