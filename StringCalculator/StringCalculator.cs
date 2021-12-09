using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            var delimiter = ',';

            if (numbers.StartsWith('/'))
            {
                delimiter = Convert.ToChar(numbers.Substring(2, 1));
                numbers = numbers.Substring(4);
            }

            var arrayOfNumbers = numbers.Split(delimiter, '\n');
            var convertedList = new List<int>(); 

            foreach (var strNumber in arrayOfNumbers)
            {
                var number = int.Parse(strNumber);
                convertedList.Add(number);
            }

            var sum = 0;
            var negatives = new List<int>();

            foreach (var number in convertedList)
            {
                if (number < 0)
                    negatives.Add(number);

                if (number <= 1000)
                    sum += number;
            }

            if (!negatives.Any())
                return sum;
            else
                throw new Exception($"negatives not allowed - {string.Join(",", negatives)}");
            
        }
    }
}
