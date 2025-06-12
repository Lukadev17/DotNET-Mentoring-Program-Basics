namespace StringCalculatorApp.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsThatNumber()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("5");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_TwoNumbersSeparatedByComma_ReturnsSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("3,4");
            Assert.Equal(7, result);
        }

        [Fact]
        public void Add_NumbersSeparatedByCommaAndNewline_ReturnsSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1\n2,3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_CustomSingleCharDelimiter_ReturnsSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//;\n2;3");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_NumberGreaterThan1000_IsIgnored()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("2,1001");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_NegativeNumber_ThrowsException()
        {
            var calculator = new StringCalculator();
            var ex = Assert.Throws<ArgumentException>(() => calculator.Add("1,-2,3"));
            Assert.Contains("negatives not allowed", ex.Message);
            Assert.Contains("-2", ex.Message);
        }
    }
}