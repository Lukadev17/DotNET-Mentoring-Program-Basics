namespace StringCalculatorApp
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            List<string> delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                char customDelimiter = numbers[2];
                delimiters.Add(customDelimiter.ToString());
                numbers = numbers.Substring(4); // skip "//<delimiter>\n"
            }

            string[] parts = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

            List<int> parsedNumbers = new List<int>();

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    if (number < 0)
                    {
                        throw new ArgumentException("negatives not allowed: " + number);
                    }

                    if (number <= 1000)
                    {
                        parsedNumbers.Add(number);
                    }
                }
            }

            return parsedNumbers.Sum();
        }
    }
}
