namespace SCK.Test
{
    public class StringCalculatorTest
    {
        StringCalculator calculator;

        public StringCalculatorTest()
        {
            calculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        public void Add_EmptyString_ReturnsZero(string input, int expected)
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2,3", 5)]
        public void Add_CommaSeperatedNumbers_ReturnsSum(string input, int expected)
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2\n3", 6)]
        public void Add_LineSeperatedNumbers_ReturnsSum(string input, int expected)
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1,2\n3", 6)]
        public void Add_NumbersWithVariousDelimiter_ReturnsSum(string input, int expected)
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("///\n1/2", 3)]
        public void Add_NumbersWithSpecifiedDelimiter_ReturnsSum(string input, int expected)
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_NegativeNumbers_ReturnsSum()
        {
            var input = "1,-1,-4";
            Action act = () => calculator.Add(input);
            var exception = Assert.Throws<ArgumentException>(act);
            var actual = exception.Message;
            var expected = "negatives not allowed: -1, -4";
            Assert.Equal(actual, expected);
        }

    }
}