namespace FizzBuzzApp.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        [InlineData(33, "Fizz")]
        [InlineData(50, "Buzz")]
        public void GetResult_ReturnsExpectedOutput(int input, string expected)
        {
            var result = FizzBuzz.GetResult(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void GetResult_ThrowsException_WhenOutOfRange(int input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzz.GetResult(input));
        }
    }
}