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
            IEnumerable<int> integerNumbers = ParseInput(input);
            ValidateInput(integerNumbers);
            var sum = integerNumbers.Sum();
            return sum;
        }
        private IEnumerable<int> ParseInput(string input)
        {
            var delimiters = GetDelimiters(input);
            if (HasSpecificDelimiter(input))
            {
                input = input.Split('\n', 2).Last(); // skips delimiter specification line
            }
            var ArrayOfStingNumbers = input.Split(delimiters);
            var ArrayOfIntegerNumbers = ArrayOfStingNumbers.Select((stringNumber) => int.Parse(stringNumber));
            return ArrayOfIntegerNumbers;
        }
        private void ValidateInput(IEnumerable<int> integerNumbers)
        {
            var negativeNumbers = integerNumbers.Where(num => num < 0);
            if (negativeNumbers.Any())
            {
                var message = "negatives not allowed: ";
                foreach (var num in negativeNumbers)
                {
                    message += $"{num}, ";
                }
                message = message.Substring(0, message.Length - 2);
                throw new ArgumentException(message);
            }
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