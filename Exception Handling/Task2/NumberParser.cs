using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            
            if (stringValue == null)
                throw new ArgumentNullException("Input is null");

            stringValue = stringValue.Trim();
            
            if (stringValue == "")
                throw new FormatException("Input is empty");

            int sign = 1;  
            int result = 0;
            int index = 0;

            
            if (stringValue[0] == '-')
            {
                sign = -1;
                index++;
            }
            else if (stringValue[0] == '+')
            {
                index++;
            }

            
            if (index == stringValue.Length)
                throw new FormatException("No digits provided after sign.");

            while (index < stringValue.Length)
            {
                char c = stringValue[index];

               
                if (c < '0' || c > '9')
                    throw new FormatException($"Invalid character: {c}");

                int digit = c - '0';


                if (result > (int.MaxValue - digit) / 10)
                {
                    if (sign == 1)
                        throw new OverflowException("Number too big for int.");
                    else if (result > ((-1L * (long)int.MinValue) - digit) / 10) 
                        throw new OverflowException("Number too small for int.");
                }

                result = result * 10 + digit;
                index++;
            }

            return result * sign;
        }
    }
}