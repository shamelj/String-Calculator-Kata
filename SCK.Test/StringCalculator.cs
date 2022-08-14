namespace SCK.Test
{
    internal class StringCalculator
    {
        public StringCalculator()
        {
        }

        internal int Add(string input)
        {
            if (input.Equals(""))
                return 0;
            var ArrayOfStingNumbers = input.Split(',');
            var ArrayOfIntegerNumbers = ArrayOfStingNumbers.Select((stringNumber)=> int.Parse(stringNumber));
            var sum = ArrayOfIntegerNumbers.Sum();
            return sum;
        }
    }
}