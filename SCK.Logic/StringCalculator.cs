namespace SCK.Test
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string input)
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