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
        [InlineData("",0)]
        public void Add_EmptyString_ReturnsZero(string input, int expected )
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2,3", 5)]
        public void Add_MuiltipleNumbers_ReturnsSum(string input, int expected)
        {
            int actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
    }
}