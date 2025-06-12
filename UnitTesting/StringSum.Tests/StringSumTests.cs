namespace StringSum.Tests
{
    public class StringSumTests
    {
        [Fact]
        public void Sum_EmptyStrings_ReturnsZero()
        {
            var result = StringSum.Sum("", "");
            Assert.Equal("0", result);
        }

        [Fact]
        public void Sum_ValidNaturalNumbers_ReturnsCorrectSum()
        {
            var result = StringSum.Sum("3", "5");
            Assert.Equal("8", result);
        }

        [Fact]
        public void Sum_OneInvalidInput_ReturnsSumTreatingInvalidAsZero()
        {
            var result = StringSum.Sum("abc", "4");
            Assert.Equal("4", result);
        }

        [Fact]
        public void Sum_NegativeNumber_TreatsAsZero()
        {
            var result = StringSum.Sum("-1", "3");
            Assert.Equal("3", result);
        }
    }
}