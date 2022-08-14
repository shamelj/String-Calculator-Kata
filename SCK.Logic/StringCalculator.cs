namespace SCK.Test
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }
        private static readonly string startOfDelimiterString = "//";

        private bool HasSpecificDelimiter(string input)
        {
            return input.StartsWith(startOfDelimiterString);

        }
        public int Add(string input)
        {
            if (input.Equals(""))
                return 0;
            var delimiters = GetDelimiters(input);
            if (HasSpecificDelimiter(input))
            {
                input = input.Split('\n', 2).Last(); // skips delimiter specification line
            }
            var ArrayOfStingNumbers = input.Split(delimiters);

            var ArrayOfIntegerNumbers = ArrayOfStingNumbers.Select((stringNumber) => int.Parse(stringNumber));
            var sum = ArrayOfIntegerNumbers.Sum();
            return sum;
        }
        private char[] GetDelimiters(string input)
        {
            var delimiters = new char[] { ',', '\n' };
            if (input.StartsWith(startOfDelimiterString))
            {
                var delimitersLine = input.Split('\n', 2).First();
                delimiters = delimitersLine.Substring(startOfDelimiterString.Length).ToCharArray();
            }
            return delimiters;
        }
    }
}