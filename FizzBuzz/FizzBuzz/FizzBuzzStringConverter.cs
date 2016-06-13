namespace FizzBuzz
{
    public class FizzBuzzStringConverter
    {
        public static string Convert(int i)
        {
            const string fizz = "Fizz";
            const string buzz = "Buzz";

            if (IsFizz(i) && IsBuzz(i)) return fizz+buzz;
            if (IsFizz(i)) return fizz;
            if (IsBuzz(i)) return buzz;

            return i.ToString();
        }

        private static bool IsBuzz(int i)
        {
            return i % 5 == 0;
        }

        private static bool IsFizz(int i)
        {
            return i % 3 == 0;
        }
    }
}