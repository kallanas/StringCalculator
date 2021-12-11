namespace StringCalculator
{
    internal static class DelimiterParser
    {
        private static string[] DefaultDelimiters = new string[] { ",", "\n" };
        
        public static DelimiterResult Parse (string numbers) 
        {
            if (!numbers.StartsWith("//"))
            {
                return new DelimiterResult 
                {
                    Delimiters = DefaultDelimiters,
                    Numbers = numbers
                };
            }

            var delimitersAndNumbers = numbers.Split("\n", 2);

            var customDelimiter = delimitersAndNumbers[0].ToCharArray()[2];
            var numbersPortion = delimitersAndNumbers[1];

            return new DelimiterResult
            {
                Delimiters = new string[] { customDelimiter.ToString(), "\n" },
                Numbers = numbersPortion
            };
        }
    }
}