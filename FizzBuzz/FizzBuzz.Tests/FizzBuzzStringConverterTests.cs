using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzStringConverterTests
    {
        [TestFixture]
        public class FizzBuzzShould
        {
            [TestCase(1)]
            [TestCase(2)]
            [TestCase(4)]
            [TestCase(7)]
            [TestCase(8)]
            [TestCase(11)]
            [TestCase(13)]
            [TestCase(14)]
            [TestCase(16)]
            [TestCase(17)]
            [TestCase(19)]
            [TestCase(22)]
            [TestCase(23)]
            [TestCase(26)]
            [TestCase(28)]
            [TestCase(29)]
            [TestCase(31)]
            [TestCase(32)]
            [TestCase(34)]
            [TestCase(37)]
            [TestCase(38)]
            [TestCase(41)]
            [TestCase(43)]
            [TestCase(44)]
            [TestCase(46)]
            [TestCase(47)]
            [TestCase(49)]
            [TestCase(52)]
            [TestCase(53)]
            [TestCase(56)]
            [TestCase(58)]
            [TestCase(59)]
            [TestCase(61)]
            [TestCase(62)]
            [TestCase(64)]
            [TestCase(67)]
            [TestCase(68)]
            [TestCase(71)]
            [TestCase(73)]
            [TestCase(74)]
            [TestCase(76)]
            [TestCase(77)]
            [TestCase(79)]
            [TestCase(82)]
            [TestCase(83)]
            [TestCase(86)]
            [TestCase(88)]
            [TestCase(89)]
            [TestCase(91)]
            [TestCase(92)]
            [TestCase(94)]
            [TestCase(97)]
            [TestCase(98)]
            public void Not_convert_any_number_which_is_not_a_multiple_of_three_or_five(int number)
            {
                var result = FizzBuzzStringConverter.Convert(number);

                result.Should().Be(number.ToString());
            }

            [TestCase(5)]
            [TestCase(10)]
            [TestCase(20)]
            [TestCase(25)]
            [TestCase(35)]
            [TestCase(40)]
            [TestCase(50)]
            [TestCase(55)]
            [TestCase(70)]
            [TestCase(80)]
            [TestCase(85)]
            [TestCase(95)]
            public void Evaluate_multiples_of_five_but_not_three_as_Buzz(int number)
            {
                var result = FizzBuzzStringConverter.Convert(number);

                result.Should().Be("Buzz");
            }

            [TestCase(3)]
            [TestCase(6)]
            [TestCase(9)]
            [TestCase(12)]
            [TestCase(18)]
            [TestCase(21)]
            [TestCase(24)]
            [TestCase(27)]
            [TestCase(33)]
            [TestCase(36)]
            [TestCase(39)]
            [TestCase(42)]
            [TestCase(48)]
            [TestCase(51)]
            [TestCase(54)]
            [TestCase(57)]
            [TestCase(63)]
            [TestCase(66)]
            [TestCase(69)]
            [TestCase(72)]
            [TestCase(78)]
            [TestCase(81)]
            [TestCase(84)]
            [TestCase(87)]
            [TestCase(93)]
            [TestCase(96)]
            [TestCase(99)]
            public void Evaluate_multiples_of_three__but_not_five_as_Fizz(int number)
            {
                var result = FizzBuzzStringConverter.Convert(number);

                result.Should().Be("Fizz");
            }

            [TestCase(15)]
            [TestCase(30)]
            [TestCase(45)]
            [TestCase(60)]
            [TestCase(75)]
            [TestCase(90)]
            public void Convert_multiples_of_three_and_five_to_FizzBuzz(int number)
            {
                var result = FizzBuzzStringConverter.Convert(number);

                result.Should().Be("FizzBuzz");
            }
        }
    }
}
