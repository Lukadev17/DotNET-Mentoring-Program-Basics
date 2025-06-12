namespace StringSum
{
    public class StringSum
    {
        public static string Sum(string num1, string num2)
        {
            int number1 = ParseNaturalNumber(num1);
            int number2 = ParseNaturalNumber(num2);

            int result = number1 + number2;
            return result.ToString();
        }

        private static int ParseNaturalNumber(string input)
        {
            if (int.TryParse(input, out int number) && number >= 0)
            {
                return number;
            }

            return 0;
        }
    }
}
